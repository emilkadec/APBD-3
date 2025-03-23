namespace ConsoleApp1;

public class Container
{
    public double Mass1
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

    public double Mass;
    public int Height;
    public int TareWeight;
    public int Depth;
    public string SerialNumber;
    public int Payload;

    public Container(double mass, int height, int tareWeight, int depth, string serialNumber, int payload)
    {
        Mass = mass;
        Height = height;
        TareWeight = tareWeight;
        Depth = depth;
        SerialNumber = serialNumber;
        Payload = payload;
    }

    public Container()
    {
    }

    public virtual void EmptyContainer()
    {
        Mass = 0;
    }

    public virtual void LoadContainer(int cargoWeight)
    {
        if (cargoWeight > Payload)
        {
            throw new OverfillException("Cargo weight cannot be greater than maxAllowedCargo");
        }
        else
        {
            Mass= cargoWeight;
        }
    }
}