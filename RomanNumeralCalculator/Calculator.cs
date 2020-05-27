using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumeralCalculator
{
    public class NumeralCalculator
    {
        public string Add(string first, string second)
        {

            var firstNumerals = first.ToCharArray();
            var secondNumerals = second.ToCharArray();            
            var firstNumbers = new List<int>();
            var secondNumbers = new List<int>();
                        
            foreach (var numeral in firstNumerals)
            {                
                firstNumbers.Add(ConvertToNumber(numeral.ToString()));                
            }
            foreach (var numeral in secondNumerals)
            {
                secondNumbers.Add(ConvertToNumber(numeral.ToString()));
            }

            for (var i = 0; i < firstNumbers.Count - 1; i++)
            {
                if (firstNumbers[i] == 1 && firstNumbers[i + 1] == 5)
                {
                    firstNumbers[i] = 0;
                    firstNumbers[i + 1] = 4;
                }
                if (firstNumbers[i] == 1 && firstNumbers[i + 1] == 10)
                {
                    firstNumbers[i] = 0;
                    firstNumbers[i + 1] = 9;
                }
                if (firstNumbers[i] == 1 && firstNumbers[i + 1] == 50)
                {
                    firstNumbers[i] = 0;
                    firstNumbers[i + 1] = 49;
                }
                if (firstNumbers[i] == 1 && firstNumbers[i + 1] == 100)
                {
                    firstNumbers[i] = 0;
                    firstNumbers[i + 1] = 99;
                }
                if (firstNumbers[i] == 1 && firstNumbers[i + 1] == 500)
                {
                    firstNumbers[i] = 0;
                    firstNumbers[i + 1] = 499;
                }
                if (firstNumbers[i] == 1 && firstNumbers[i + 1] == 1000)
                {
                    firstNumbers[i] = 0;
                    firstNumbers[i + 1] = 999;
                }
            }
            
            for (var i = 0; i < secondNumbers.Count - 1; i++)
            {
                if (secondNumbers[i] == 1 && secondNumbers[i + 1] == 5)
                {
                    secondNumbers[i] = 0;
                    secondNumbers[i + 1] = 4;
                }
                if (secondNumbers[i] == 1 && secondNumbers[i + 1] == 10)
                {
                    secondNumbers[i] = 0;
                    secondNumbers[i + 1] = 9;
                }
                if (secondNumbers[i] == 1 && secondNumbers[i + 1] == 50)
                {
                    secondNumbers[i] = 0;
                    secondNumbers[i + 1] = 49;
                }
                if (secondNumbers[i] == 1 && secondNumbers[i + 1] == 100)
                {
                    secondNumbers[i] = 0;
                    secondNumbers[i + 1] = 99;
                }
                if (secondNumbers[i] == 1 && secondNumbers[i + 1] == 500)
                {
                    secondNumbers[i] = 0;
                    secondNumbers[i + 1] = 499;
                }
                if (secondNumbers[i] == 1 && secondNumbers[i + 1] == 1000)
                {
                    secondNumbers[i] = 0;
                    secondNumbers[i + 1] = 999;
                }
            }

            return ConvertToNumeral(firstNumbers.Sum() + secondNumbers.Sum());
        }

        public int ConvertToNumber(string numeral)
        {
            switch (numeral)
            {
                case "I": return 1;
                case "V": return 5;
                case "X": return 10;
                case "L": return 50;
                case "C": return 100;
                case "D": return 500;
                case "M": return 1000;
                default: return 0;
            }
        }

        public string ConvertToNumeral(int number)
        {
            var numeral = "";
            var remainder = number;
            var M = number / 1000;
            var remainderM = 0;
            var D = number / 500;
            var remainderD = 0;
            var C = number / 100;
            var remainderC = 0;
            var L = number / 50;
            var remainderL = 0;
            var X = number / 10;
            var remainderX = 0;
            var V = number / 5;
            var remainderV = 0;
            var I = (number / 1);
            var remainderI = 0;

            while (remainder > 0)
            {
                if (M > 0)
                {
                    M = number / 1000;
                    remainderM = number % 1000;
                    for (var i = M; M > 0; M--)
                    {
                        numeral = numeral + "M";
                        remainder -= 1000;
                    }
                }

                if (D > 0)
                {
                    D = number / 500;
                    remainderD = number % 500;
                    for (var i = D; D > 0; D--)
                    {
                        numeral = numeral + "D";
                        remainder -= 500;
                    }
                }

                if (C > 0)
                {
                    C = number / 100;
                    remainderC = number % 100;
                    for (var i = C; C > 0; C--)
                    {
                        numeral = numeral + "C";
                        remainder -= 100;
                    }
                }
                if (L > 0)
                {
                    L = number / 50;
                    remainderL = number % 50;
                    for (var i = L; L > 0; L--)
                    {
                        numeral = numeral + "L";
                        remainder -= 50;
                    }
                }
                if (X > 0)
                {
                    X = number / 10;
                    remainderX = number % 10;
                    for (var i = X; X > 0; X--)
                    {
                        numeral = numeral + "X";
                        remainder -= 10;
                    }
                }
                if (V > 0)
                {                    
                    V = number / 5;
                    remainderV = number % 5;                    
                    for (var i = V; V > 0; V--)
                    {
                        numeral = numeral + "V";
                        remainder -= 5;
                    }
                }
                if (I > 0)
                {                    
                    I = number / 1;
                    remainderI = number % I;
                    for (var i = remainder; i > 0; i--)
                    {
                        numeral = numeral + "I";
                        remainder -= 1;
                    }
                    if (numeral.EndsWith("IIII"))
                        numeral = numeral.Replace("IIII", "IV");
                }                                
            }
            return numeral;
        }    
    }
}
