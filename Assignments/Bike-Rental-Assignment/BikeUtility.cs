using System.Collections.Generic;

public class BikeUtility
{
    public void AddBikeDetails(string model, string brand, int pricePerDay)
    {
        Bike bike = new Bike();

        bike.Model = model;
        bike.Brand = brand;
        bike.PricePerDay = pricePerDay;

        int key = Program.bikeDetails.Count + 1;

        Program.bikeDetails.Add(key, bike);
    }

    public SortedDictionary<string, List<Bike>> GroupBikesByBrand()
    {
        SortedDictionary<string, List<Bike>> grouped =
            new SortedDictionary<string, List<Bike>>();

        foreach (KeyValuePair<int, Bike> item in Program.bikeDetails)
        {
            Bike bike = item.Value;

            if (!grouped.ContainsKey(bike.Brand))
            {
                grouped[bike.Brand] = new List<Bike>();
            }

            grouped[bike.Brand].Add(bike);
        }

        return grouped;
    }
}