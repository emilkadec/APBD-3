using System.ComponentModel;

namespace ConsoleApp1;

public class LiquidContainer:Container, IHazardNotifier
{
    public char Type;

    public void Notify(Exception ex)
    {
        throw new Exception("Occurence of hazardous event:" + base.SerialNumber, ex);
    }
    
}