namespace ConsoleApp1;

public class OverfillException:Exception
{
    public OverfillException(String message):base("OverfillException")
    {
    }
}