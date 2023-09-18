using System;


public static class Parser
{
    public static int ParseInt(string input)
    {
        return int.Parse(input);
    }


    public static bool TryParse(string input, out bool result)
    {
        return bool.TryParse(input, out result);
    }
}