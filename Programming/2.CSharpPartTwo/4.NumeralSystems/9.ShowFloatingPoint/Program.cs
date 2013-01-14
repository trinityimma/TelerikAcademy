using System;

class Program
{
    // Base10ToBase2Integer(5) -> 101
    static string Base10ToBase2Integer(int d)
    {
        string b = String.Empty;

        for (; d != 0; d /= 2) b = d % 2 + b;

        return b;
    }

    // Base10ToBase2Fraction(.125) -> 001; 0.125 = 1 / 8 = 1 / (2 ^ 3) = 0.001 binary
    static string Base10ToBase2Fraction(float f)
    {
        string b = String.Empty;

        // 0.125 -> 0.25 
        for (f *= 2; f != 0; f *= 2) // 0.25 -> 0.5 -> 1 -> 0; 3 times
        {
            b += (int)f;
            f -= (int)f;
        }

        return b;
    }

    // Sign is 1 bit long
    static int GetSign(float f)
    {
        return f < 0 ? 1 : 0;
    }

    // Exponent is the next 8 bits
    static string GetExponent(string integer, string fraction)
    {
        // 1 -> 0; 2 -> 1; 3 -> 1; 4 -> 2; 5 -> 2; 6 -> 2; 7 -> 2; 8 -> 3; 9 -> 3; ... 15 -> 3; 16 -> 4 ...
        // 0.8 -> -1; 0.4 -> -2; 0.2 -> -3; 0.1 -> -4
        int power;

        // 8 = 2 ^ 3 in binary is 1000 - power is +3 - positive
        if (integer.Length != 0) power = integer.Length - 1; // 1.23, 12.3, but not 0.12 or 0.00123
        else power = -fraction.IndexOf('1') - 1; // Get first non-zero in fraction 0.125 = 1 / 8 in binary is 0.001 - power is -3 - negative

        return Base10ToBase2Integer(127 + power).PadRight(8, '0'); // Convert power to binary, 127 is the middle
    }

    // Mantissa is the last 23 bits
    static string GetMantissa(string integer, string fraction)
    {
        string b;

        if (integer.Length != 0) b = integer.Substring(1) + fraction; // First can't be 0 so it must be 1 (no leading zeros)
        else b = fraction.Substring(fraction.IndexOf('1') + 1); // No integer part - get first non-zero in fraction

        return b.PadRight(23, '0');
    }

    static void Main(string[] args)
    {
        float f = -27.25f; // 32 bits = 1 + 8 + 23 with 24 bits of precision in mantissa

        if (f == 0) return; // TODO: Print 0

        int sign = GetSign(f);
        f = Math.Abs(f); // If the number is negative make it positive for easier calculations

        string integer = Base10ToBase2Integer((int)f); // 123.456 -> 123 in binary
        string fraction = Base10ToBase2Fraction(f - (int)f); // 123.456 -> .456 in binary

        Console.WriteLine(sign);
        Console.WriteLine(GetExponent(integer, fraction));
        Console.WriteLine(GetMantissa(integer, fraction));
    }
}
