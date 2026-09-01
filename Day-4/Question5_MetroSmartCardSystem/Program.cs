using System;
using System.Collections.Generic;
using System.Globalization;

namespace Question5_MetroSmartCardSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? firstLine = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(firstLine)) return;

            string[] header = firstLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int numberOfRequests = int.Parse(header[0]);
            double baseFare = double.Parse(header[1], CultureInfo.InvariantCulture);
            double perKmRate = double.Parse(header[2], CultureInfo.InvariantCulture);
            double maxDailyCap = double.Parse(header[3], CultureInfo.InvariantCulture);

            int numberOfStations = int.Parse(Console.ReadLine() ?? "0");
            List<Station> stations = new List<Station>();

            for (int i = 0; i < numberOfStations; i++)
            {
                string[] stParts = (Console.ReadLine() ?? "").Split(' ', StringSplitOptions.RemoveEmptyEntries);
                stations.Add(new Station
                {
                    stationId = int.Parse(stParts[0]),
                    stationName = stParts[1],
                    zone = int.Parse(stParts[2]),
                    latitude = double.Parse(stParts[3], CultureInfo.InvariantCulture),
                    longitude = double.Parse(stParts[4], CultureInfo.InvariantCulture)
                });
            }

            MetroCardManager manager = new MetroCardManager(stations, baseFare, perKmRate, maxDailyCap);

            for (int i = 0; i < numberOfRequests; i++)
            {
                string? line = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string cmd = parts[0];

                if (cmd == "issueCard")
                {
                    int cardNum = int.Parse(parts[1]);
                    string name;
                    string type;

                    if (parts[2].StartsWith("\"") && !parts[2].EndsWith("\"") && parts.Length > 4)
                    {
                        name = (parts[2] + " " + parts[3]).Trim('\"');
                        type = parts[4];
                    }
                    else
                    {
                        name = parts[2].Trim('\"');
                        type = parts[3];
                    }

                    manager.issueCard(cardNum, name, type);
                }
                else if (cmd == "tapIn")
                {
                    int cardNum = int.Parse(parts[1]);
                    int stationId = int.Parse(parts[2]);
                    long epoch = long.Parse(parts[3]);
                    Console.WriteLine(manager.tapIn(cardNum, stationId, epoch).ToString().ToLower());
                }
                else if (cmd == "tapOut")
                {
                    int cardNum = int.Parse(parts[1]);
                    int stationId = int.Parse(parts[2]);
                    long epoch = long.Parse(parts[3]);
                    Console.WriteLine(manager.tapOut(cardNum, stationId, epoch).ToString().ToLower());
                }
                else if (cmd == "commuterInfo")
                {
                    int cardNum = int.Parse(parts[1]);
                    Commuter? c = manager.getCommuterInfo(cardNum);
                    if (c != null)
                    {
                        Console.WriteLine($"{c.cardNumber} {c.commuterName} {c.commuterType} {c.travelSummary.lastEntryStation} {c.travelSummary.lastExitStation} {c.travelSummary.lastEntryTime} {c.travelSummary.lastExitTime} {c.travelSummary.totalFarePaid.ToString("0.0#", CultureInfo.InvariantCulture)} {c.travelSummary.totalTrips} {c.travelSummary.averageFarePerTrip.ToString("0.0#", CultureInfo.InvariantCulture)}");
                    }
                }
                else if (cmd == "fareHistory")
                {
                    int cardNum = int.Parse(parts[1]);
                    List<double> fares = manager.fareHistory(cardNum);
                    foreach (var f in fares)
                    {
                        Console.WriteLine(f.ToString("0.0#", CultureInfo.InvariantCulture));
                    }
                }
                else if (cmd == "zoneRevenue")
                {
                    long start = long.Parse(parts[1]);
                    long end = long.Parse(parts[2]);
                    var revenue = manager.getZoneWiseRevenue(start, end);
                    foreach (var kvp in revenue)
                    {
                        Console.WriteLine($"{kvp.Key}:{kvp.Value.ToString("0.0#", CultureInfo.InvariantCulture)}");
                    }
                }
                else if (cmd == "frequentRoute")
                {
                    int cardNum = int.Parse(parts[1]);
                    var routes = manager.getFrequentRoute(cardNum);
                    foreach (var r in routes)
                    {
                        Console.WriteLine(r);
                    }
                }
                else if (cmd == "dailySavings")
                {
                    int cardNum = int.Parse(parts[1]);
                    long date = long.Parse(parts[2]);
                    double savings = manager.getDailyPassSavings(cardNum, date);
                    Console.WriteLine(savings.ToString("0.0#", CultureInfo.InvariantCulture));
                }
            }
        }
    }
}
