using System;
using System.Collections.Generic;
using System.Linq;

namespace Question5_MetroSmartCardSystem
{
    public class MetroCardManager : MetroOperations
    {
        private Dictionary<int, Station> stations = new Dictionary<int, Station>();
        private Dictionary<int, Commuter> commuters = new Dictionary<int, Commuter>();
        private Dictionary<int, (int stationId, long time)> activeJourneys = new Dictionary<int, (int stationId, long time)>();
        private Dictionary<int, List<double>> commuterFares = new Dictionary<int, List<double>>();
        private Dictionary<int, Dictionary<long, double>> dailyFares = new Dictionary<int, Dictionary<long, double>>();
        private Dictionary<int, Dictionary<string, int>> routeCounts = new Dictionary<int, Dictionary<string, int>>();
        private List<(long exitTime, string zonePair, double fare)> allJourneys = new List<(long exitTime, string zonePair, double fare)>();

        private double baseFare;
        private double perKmRate;
        private double maxDailyCap;

        public MetroCardManager(List<Station> stationsList, double baseFare, double perKmRate, double maxDailyCap)
        {
            this.baseFare = baseFare;
            this.perKmRate = perKmRate;
            this.maxDailyCap = maxDailyCap;

            foreach (var st in stationsList)
            {
                stations[st.stationId] = st;
            }
        }

        private double CalculateDistance(Station s1, Station s2)
        {
            double lat1 = (Math.PI / 180.0) * s1.latitude;
            double lon1 = (Math.PI / 180.0) * s1.longitude;
            double lat2 = (Math.PI / 180.0) * s2.latitude;
            double lon2 = (Math.PI / 180.0) * s2.longitude;

            double dlat = lat2 - lat1;
            double dlon = lon2 - lon1;

            double a = Math.Pow(Math.Sin(dlat / 2.0), 2) +
                       Math.Cos(lat1) * Math.Cos(lat2) *
                       Math.Pow(Math.Sin(dlon / 2.0), 2);

            double c = 2 * Math.Asin(Math.Sqrt(a));
            double r = 6371.0;

            return r * c;
        }

        private long GetDateKey(long epochTime)
        {
            if (epochTime > 100000000000L)
            {
                DateTime dt = DateTimeOffset.FromUnixTimeMilliseconds(epochTime).UtcDateTime;
                return dt.Year * 10000L + dt.Month * 100L + dt.Day;
            }
            return epochTime / 86400000L;
        }

        public void issueCard(int cardNumber, string commuterName, string commuterType)
        {
            if (!commuters.ContainsKey(cardNumber))
            {
                Commuter c = new Commuter
                {
                    cardNumber = cardNumber,
                    commuterName = commuterName,
                    commuterType = commuterType,
                    travelSummary = new TravelSummary()
                };
                commuters[cardNumber] = c;
                commuterFares[cardNumber] = new List<double>();
                dailyFares[cardNumber] = new Dictionary<long, double>();
                routeCounts[cardNumber] = new Dictionary<string, int>();
            }
        }

        public bool tapIn(int cardNumber, int stationId, long epochTime)
        {
            if (!commuters.ContainsKey(cardNumber)) return false;
            if (activeJourneys.ContainsKey(cardNumber)) return false;
            if (!stations.ContainsKey(stationId)) return false;

            activeJourneys[cardNumber] = (stationId, epochTime);
            Commuter c = commuters[cardNumber];
            c.travelSummary.lastEntryStation = stationId;
            c.travelSummary.lastEntryTime = epochTime;
            return true;
        }

        public bool tapOut(int cardNumber, int stationId, long epochTime)
        {
            if (!commuters.ContainsKey(cardNumber)) return false;
            if (!activeJourneys.ContainsKey(cardNumber)) return false;
            if (!stations.ContainsKey(stationId)) return false;

            var journey = activeJourneys[cardNumber];
            int entryStationId = journey.stationId;
            long entryTime = journey.time;

            if (epochTime <= entryTime) return false;
            if (entryStationId == stationId) return false;

            Station entryStation = stations[entryStationId];
            Station exitStation = stations[stationId];

            double distance = CalculateDistance(entryStation, exitStation);
            double durationMinutes = (epochTime - entryTime) / (1000.0 * 60.0);

            double rawFare;
            if (durationMinutes > 120)
            {
                rawFare = baseFare * 3;
            }
            else
            {
                rawFare = baseFare + (distance * perKmRate);
            }

            Commuter commuter = commuters[cardNumber];
            double discountMultiplier = commuter.commuterType switch
            {
                "SENIOR" => 0.50,
                "STUDENT" => 0.75,
                "CHILD" => 0.25,
                _ => 1.00
            };

            double discountedFare = rawFare * discountMultiplier;

            long dateKey = GetDateKey(epochTime);
            if (!dailyFares[cardNumber].ContainsKey(dateKey))
            {
                dailyFares[cardNumber][dateKey] = 0.0;
            }

            double currentDaySpent = dailyFares[cardNumber][dateKey];
            double actualFareCharged = discountedFare;

            if (currentDaySpent + actualFareCharged > maxDailyCap)
            {
                actualFareCharged = Math.Max(0.0, maxDailyCap - currentDaySpent);
            }

            dailyFares[cardNumber][dateKey] += actualFareCharged;
            commuterFares[cardNumber].Add(actualFareCharged);

            commuter.travelSummary.lastExitStation = stationId;
            commuter.travelSummary.lastExitTime = epochTime;
            commuter.travelSummary.totalFarePaid += actualFareCharged;
            commuter.travelSummary.totalTrips++;
            commuter.travelSummary.averageFarePerTrip = commuter.travelSummary.totalFarePaid / commuter.travelSummary.totalTrips;

            string routeKey = $"{entryStation.stationName} to {exitStation.stationName}";
            if (!routeCounts[cardNumber].ContainsKey(routeKey))
            {
                routeCounts[cardNumber][routeKey] = 0;
            }
            routeCounts[cardNumber][routeKey]++;

            string zonePair = $"Zone{entryStation.zone}-Zone{exitStation.zone}";
            allJourneys.Add((epochTime, zonePair, actualFareCharged));

            activeJourneys.Remove(cardNumber);
            return true;
        }

        public Commuter? getCommuterInfo(int cardNumber)
        {
            if (commuters.TryGetValue(cardNumber, out var commuter))
            {
                return commuter;
            }
            return null;
        }

        public List<double> fareHistory(int cardNumber)
        {
            if (!commuterFares.ContainsKey(cardNumber) || commuterFares[cardNumber].Count == 0)
            {
                return new List<double>();
            }

            var list = commuterFares[cardNumber];
            var lastFive = list.Skip(Math.Max(0, list.Count - 5)).ToList();
            return lastFive.OrderByDescending(f => f).ToList();
        }

        public Dictionary<string, double> getZoneWiseRevenue(long startTime, long endTime)
        {
            Dictionary<string, double> result = new Dictionary<string, double>();

            foreach (var j in allJourneys)
            {
                if (j.exitTime >= startTime && j.exitTime <= endTime && j.fare > 0)
                {
                    if (!result.ContainsKey(j.zonePair))
                    {
                        result[j.zonePair] = 0.0;
                    }
                    result[j.zonePair] += j.fare;
                }
            }

            return result.OrderByDescending(kvp => kvp.Value).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }

        public List<string> getFrequentRoute(int cardNumber)
        {
            if (!routeCounts.ContainsKey(cardNumber) || routeCounts[cardNumber].Count == 0)
            {
                return new List<string>();
            }

            return routeCounts[cardNumber]
                .OrderByDescending(kvp => kvp.Value)
                .Take(3)
                .Select(kvp => kvp.Key)
                .ToList();
        }

        public double getDailyPassSavings(int cardNumber, long date)
        {
            double dailyPassCost = maxDailyCap * 0.8;
            double actualFaresPaid = 0.0;

            if (dailyFares.ContainsKey(cardNumber))
            {
                if (dailyFares[cardNumber].ContainsKey(date))
                {
                    actualFaresPaid = dailyFares[cardNumber][date];
                }
                else if (dailyFares[cardNumber].Count > 0)
                {
                    actualFaresPaid = dailyFares[cardNumber].Values.First();
                }
            }

            if (actualFaresPaid == 0.0)
            {
                return 0.0;
            }

            double savings = actualFaresPaid - dailyPassCost;
            return savings > 0 ? savings : 0.0;
        }
    }
}
