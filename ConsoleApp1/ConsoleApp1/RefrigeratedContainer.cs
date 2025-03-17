namespace ConsoleApp1;

public class RefrigeratedContainer:Container
{
    public string Type;
    public double Temperature;

    public RefrigeratedContainer(double mass, int height, int tareWeight, int depth, string serialNumber, int payload, string type, double temperature) : base(mass, height, tareWeight, depth, serialNumber, payload)
    {
        Type = type;
        Temperature = temperature;
    }
}