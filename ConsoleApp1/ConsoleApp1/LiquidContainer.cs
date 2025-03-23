namespace ConsoleApp1;

public class LiquidContainer:Container, IHazardNotifier
{    public bool IsHazardous { get; set; }
    
    public LiquidContainer(double mass, int height, int tareWeight, int depth, string serialNumber, int payload, bool isHazardous) 
        : base(mass, height, tareWeight, depth, serialNumber, payload)
    {
        IsHazardous = isHazardous;
    }

    public void Notify()
    {
        Console.WriteLine("Occurrence of hazardous event: " + SerialNumber);
    }

    public override void LoadContainer(int cargoWeight)
    {
        int maxAllowedCargo = IsHazardous 
            ? (int)(Payload * 0.5)  
            : (int)(Payload * 0.9); 

        if (cargoWeight > maxAllowedCargo)
        {
            Notify();
            throw new OverfillException("Cargo weight cannot be greater than maxAllowedCargo");
        }
            
        Mass = cargoWeight;
        }
        
        
        
    }