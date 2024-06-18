using System;
using System.Numerics;

public static class BigIntegerExtensions
{
    public static string ToReadableString(this BigInteger value)
    {
        if (value >= 1_000_000_000)
        {
            return ((double)value / 1_000_000_000).ToString("0.##") + "B";
        }
        else if (value >= 1_000_000)
        {
            return ((double)value / 1_000_000).ToString("0.##") + "M";
        }
        else if (value >= 1_000)
        {
            return ((double)value / 1_000).ToString("0.##") + "K";
        }
        else
        {
            return value.ToString();
        }
    }
}
