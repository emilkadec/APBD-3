namespace ConsoleApp1;

public class GasContainer:Container, IHazardNotifier
{
    public int Pressure;

    public GasContainer(int mass, int height, int tareWeight, int depth, string serialNumber, int payload, int pressure) 
        : base(mass, height, tareWeight, depth, serialNumber, payload)
    {
        Pressure = pressure;
    }
    
        public override void EmptyContainer()
    {
        this.Mass = base.Mass * 0.05;
    }
    
    public override void LoadContainer(int cargoWeight)
    {
        if (cargoWeight > Payload)
        {
            Notify();
            throw new OverfillException("Mass cannot be greater than payload");
        }
            
        Mass = cargoWeight;
    }

    public void Notify()
    {
        Console.WriteLine("Occurence of hazardous event:" + base.SerialNumber);
    }
    
    
}