namespace ConsoleApp1;

public class SerialNumberGenerator
{
    private static Dictionary<char, int> _lastUsedNumbers = new Dictionary<char, int>
    {
        { 'L', 0 },
        { 'G', 0 },
        { 'C', 0 }
    };

    public static string GenerateSerialNumber(char containerType)
    {
        if (!_lastUsedNumbers.ContainsKey(containerType))
        {
            throw new ArgumentException($"Unknown container type: {containerType}");
        }

        _lastUsedNumbers[containerType]++;
        return $"KON-{containerType}-{_lastUsedNumbers[containerType]}";
    }
}