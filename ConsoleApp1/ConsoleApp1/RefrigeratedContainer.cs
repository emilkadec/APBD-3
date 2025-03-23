namespace ConsoleApp1;

public class RefrigeratedContainer:Container
{
    public string ProductType;
    public double Temperature;
        
    public static Dictionary<string, double> ProductMinTemperatures = new Dictionary<string, double>
    {
        { "Bananas", 13.3 },
        { "Chocolate", 18 },
        { "Fish", -10 },
        { "Meat", -15 },
        { "Ice Cream", -18 },
        { "Frozen Vegetables", -8 },
        { "Cheese", 4 },
        { "Dairy", 2 }
    };

    public RefrigeratedContainer(double mass, int height, int tareWeight, int depth, string serialNumber, int payload, string productType, double temperature) 
        : base(mass, height, tareWeight, depth, serialNumber, payload)
    {
        if (!ProductMinTemperatures.TryGetValue(productType, out double requiredTemperature))
        {
            throw new ArgumentException($"Unknown product type: {productType}");
        }
        if (temperature > requiredTemperature)
        {
            throw new ArgumentException($"Temperature {temperature}°C is too high for {productType}. Required: {requiredTemperature}°C or lower.");
        }
        ProductType = productType;
        Temperature = temperature;
    }


    public override void LoadContainer(int cargoWeight)
    {
        if (cargoWeight > Payload)
        {
            throw new OverfillException("Mass cannot be greater than payload.");
        }
            
        if (Mass > 0 && Mass != cargoWeight)
        {
            Console.WriteLine($"Warning: Container already contains {Mass}kg of {ProductType}. Adding {cargoWeight}kg more.");
        }
            
        Mass = cargoWeight;
    }
}