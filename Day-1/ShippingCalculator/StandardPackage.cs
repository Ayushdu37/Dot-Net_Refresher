public class StandardPackage : IShippingCalculator
{
    public double CalculateShippingCost(double weight, double distance)
    {
        return (weight * 5) + (distance * 2);
    }
}