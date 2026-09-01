using System;
using System.Collections.Generic;
using System.Linq;

namespace Question11_OceanFleet
{
    public class Vessel
    {
        public string VesselId { get; set; } = string.Empty;
        public string VesselName { get; set; } = string.Empty;
        public double AverageSpeed { get; set; }
        public string VesselType { get; set; } = string.Empty;

        public Vessel()
        {
        }

        public Vessel(string vesselId, string vesselName, double averageSpeed, string vesselType)
        {
            VesselId = vesselId;
            VesselName = vesselName;
            AverageSpeed = averageSpeed;
            VesselType = vesselType;
        }
    }

    public class VesselUtil
    {
        private List<Vessel> vesselList = new List<Vessel>();

        public void AddVesselPerformance(Vessel vessel)
        {
            vesselList.Add(vessel);
        }

        public Vessel? GetVesselById(string vesselId)
        {
            return vesselList.FirstOrDefault(v => v.VesselId == vesselId);
        }

        public List<Vessel> GetHighPerformanceVessels()
        {
            if (vesselList.Count == 0)
            {
                return new List<Vessel>();
            }

            double maxSpeed = vesselList.Max(v => v.AverageSpeed);
            return vesselList.Where(v => v.AverageSpeed == maxSpeed).ToList();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            VesselUtil util = new VesselUtil();

            int n = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine() ?? "";
                string[] parts = line.Split(':');
                if (parts.Length == 4)
                {
                    string id = parts[0];
                    string name = parts[1];
                    double speed = Convert.ToDouble(parts[2]);
                    string type = parts[3];

                    util.AddVesselPerformance(new Vessel(id, name, speed, type));
                }
            }

            string searchId = Console.ReadLine() ?? "";
            Vessel? found = util.GetVesselById(searchId);

            if (found != null)
            {
                Console.WriteLine($"{found.VesselId} | {found.VesselName} | {found.VesselType} | {found.AverageSpeed} knots");
            }

            Console.WriteLine("High performance vessels are");
            List<Vessel> highVessels = util.GetHighPerformanceVessels();
            foreach (var vessel in highVessels)
            {
                Console.WriteLine($"{vessel.VesselId} | {vessel.VesselName} | {vessel.VesselType} | {vessel.AverageSpeed} knots");
            }
        }
    }
}
