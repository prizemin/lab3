using System;
using System.Collections.Generic;

namespace lab3
{
    public class RomanNumber : ICloneable, IComparable
    {
        static private Dictionary<ushort, string> dict = new Dictionary<ushort, string>
    {
        {   1000,   "M" },
        {   900,   "CM" },
        {   500,   "D" },
        {   400,   "CD" },
        {   100,   "C" },
        {   90,   "XC" },
        {   50,   "L" },
        {   40,   "XL" },
        {   10,   "X" },
        {   9,   "IX" },
        {   5,   "V" },
        {   4,   "IV" },
        {   1,   "I" }
    };
        private readonly ushort number;

        public RomanNumber(ushort n)
        {
            if (n <= 0 || n >= 4000)
            {
                throw new RomanNumberException();
            }
            number = n;
        }
        public static RomanNumber operator +(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 is null || n2 is null) throw new RomanNumberException();
            return new RomanNumber((ushort)(n1.number + n2.number));
        }
        public static RomanNumber operator -(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 is null || n2 is null) throw new RomanNumberException();
            if (n1.number <= n2.number) throw new RomanNumberException();
            return new RomanNumber((ushort)(n1.number - n2.number));
        }
        public static RomanNumber operator *(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 is null || n2 is null) throw new RomanNumberException();
            return new RomanNumber((ushort)(n1.number * n2.number));
        }
        public static RomanNumber operator /(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 is null || n2 is null) throw new RomanNumberException();
            if (
                n1.number % n2.number == 0 &&
                n1.number >= n2.number
            )
            {
                return new RomanNumber((ushort)(n1.number / n2.number));
            }
            else
            {
                throw new RomanNumberException();
            }
        }
        private static string toRoman(int number)
        {
            string res = new string("");
            foreach (var val in dict)
            {
                while (number >= val.Key)
                {
                    res += val.Value;
                    number -= val.Key;
                }
            }

            return res;
        }

        public object Clone()
        {
            return new RomanNumber(number);
        }

        public int CompareTo(object obj)
        {
            if (obj is RomanNumber num) return number.CompareTo(num.number);
            else throw new RomanNumberException("Неверное значение аргумента");
        }
        public override string ToString()
        {
            return toRoman(number);
        }
    }
}