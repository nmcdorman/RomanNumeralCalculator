using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace RomanNumeralCalculator
{
    public class NumeralCalculator
    {
        public string Add(string first, string second)
        {
            return GetNumeral(GetNumber(first) + GetNumber(second));            
        }        

        public Dictionary<long, string> GetNumerals()
        {
            return new Dictionary<long, string>()
            {
                {1, "I" },
                {4, "IV" },
                {5, "V" },
                {9, "IX" },
                {10, "X" },
                {40, "XL"},
                {50, "L"},
                {90, "XC"},
                {100, "C"},
                {400, "CD" },
                {500, "D" },
                {900, "DM" },
                {1000, "M" }
            };
        }

        public string GetNumeral(long number)
        {            
            return GetNumerals()[number];
        }

        public long GetNumber(string numeral)
        {
            var numerals = GetNumerals();
            var numeralArray = numeral.ToCharArray();

            if (numerals.ContainsValue(numeral))
            {
                return numerals.FirstOrDefault(n => n.Value == numeral).Key;

            }
            else
            {                
                long number = 0;

                if (numeral.Length == 2)
                {                    
                    number = GetNumber(numeralArray[0].ToString());
                }
                else 
                {
                    for (var i = 0; i < numerals.Count - 1; i++)
                    {                    
                        var sequence = numeralArray[i].ToString() + numeralArray[i + 1].ToString();
                        number += GetNumber(sequence);
                    }                    
                }
                return number;
            }

        }
    }
}
