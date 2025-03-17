using System.ComponentModel;

namespace ConsoleApp1;

public class LiquidContainer:Container, IHazardNotifier
{    public bool IsHazardous { get; set; }
    
    public LiquidContainer(double mass, int height, int tareWeight, int depth, string serialNumber, int payload, bool isHazardous) : base(mass, height, tareWeight, depth, serialNumber, payload)
    {
        IsHazardous = isHazardous;
    }



    public void Notify()
    {
        Console.WriteLine("Occurence of hazardous event:" + base.SerialNumber);
    }

    public override void LoadContainer(int cargoWeight)
    {
        if (IsHazardous && cargoWeight <Payload*0.5)
        {
            Mass=cargoWeight;
        }
        else
        {
            Console.WriteLine("Too heavy cargo for hazardous cargo");
        }
        if (!IsHazardous && cargoWeight <Payload*0.9)
        {
            Mass=cargoWeight;
        }
        else
        {
            Console.WriteLine("Too heavy cargo");
        }
        
        
        
    }
}