public class ExpressPackage : IShippingCalculator
{
    public double CalculateShippingCost(double weight, double distance)
    {
        return (weight * 8) + (distance * 3);
    }
}