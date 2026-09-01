using System;

namespace Question7_VehicleDrivingSimulation
{
    public class Vehicle
    {
        protected int numberOfWheels;

        public Vehicle(int numberOfWheels)
        {
            this.numberOfWheels = numberOfWheels;
        }

        public virtual string Drive()
        {
            return $"{numberOfWheels} wheeler driving";
        }
    }

    public class TwoWheeler : Vehicle
    {
        public TwoWheeler() : base(2)
        {
        }
    }

    public class HMV : Vehicle
    {
        public HMV(int numberOfWheels) : base(numberOfWheels)
        {
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicle twoWheeler = new TwoWheeler();
            Vehicle hmv = new HMV(8);

            Console.WriteLine(twoWheeler.Drive());
            Console.WriteLine(hmv.Drive());
        }
    }
}
