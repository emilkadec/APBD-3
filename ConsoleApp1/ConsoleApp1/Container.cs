namespace ConsoleApp1;

public class Container
{
    public int Mass1
    {
        get => Mass;
        set => Mass = value;
    }

    public int Height1
    {
        get => Height;
        set => Height = value;
    }

    public int TareWeight1
    {
        get => TareWeight;
        set => TareWeight = value;
    }

    public int Weight1
    {
        get => Weight;
        set => Weight = value;
    }

    public int Depth1
    {
        get => Depth;
        set => Depth = value;
    }

    public string SerialNumber1
    {
        get => SerialNumber;
        set => SerialNumber = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int Payload1
    {
        get => Payload;
        set => Payload = value;
    }

    public int Mass;
    public int Height;
    public int TareWeight;
    public int Weight;
    public int Depth;
    public string SerialNumber;
    public int Payload;

    public Container(int mass, int height, int tareWeight, int weight, int depth, string serialNumber, int payload)
    {
        Mass = mass;
        Height = height;
        TareWeight = tareWeight;
        Weight = weight;
        Depth = depth;
        SerialNumber = serialNumber;
        Payload = payload;
    }

    public Container()
    {
    }

    public void EmptyContainer()
    {
        Mass = 0;
    }

    public void LoadContainer(int cargoWeight)
    {
        if (cargoWeight > Payload)
        {
            throw new Exception($"Cargo weight {cargoWeight} is greater than payload.");
        }
        else
        {
            Mass= cargoWeight;
        }
    }
}