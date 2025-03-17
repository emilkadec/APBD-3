namespace ConsoleApp1;

public class GasContainer:Container, IHazardNotifier
{
    public int Pressure;

    public GasContainer(int mass, int height, int tareWeight, int weight, int depth, string serialNumber, int payload, int pressure) : base(mass, height, tareWeight, depth, serialNumber, payload)
    {
        Pressure = pressure;
    }

    override
        public void EmptyContainer()
    {
        base.Mass = base.Mass * 0.05;
    }

    public void Notify(Exception ex)
    {
        throw new Exception("Occurence of hazardous event:" + base.SerialNumber, ex);
    }
    
    
}