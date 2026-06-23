using System;
using System.Collections.Generic;

namespace api.Services
{
    public class RomanNumeralService
    {
        private static readonly Dictionary<char, int> _values = new()
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };

        public int ToInteger(string roman)
        {
            if (string.IsNullOrWhiteSpace(roman))
                throw new ArgumentException("Roman numeral string cannot be empty.");

            int total = 0;
            for (int i = 0; i < roman.Length - 1; i++)
            {
                int current = _values[roman[i]];
                int next = _values[roman[i + 1]];

                if (current < next)
                    total -= current;
                else
                    total += current;
            }

            return total;
        }
    }
}