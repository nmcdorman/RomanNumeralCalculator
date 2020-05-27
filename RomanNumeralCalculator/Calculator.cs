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
            var I = number / 1;
            var remainderI = 0;

            while (remainder > 0)
            {
                if (M > 0)
                {
                    M = number / 1000;
                    remainderM = number % 1000;
                    for (var i = M; M > 0; M--)
                        numeral = numeral + "M";
                }

                if (D > 0)
                {
                    D = number / 500;
                    remainderD = number % 500;
                    for (var i = D; D > 0; D--)
                        numeral = numeral + "D";                    
                }

                if (C > 0)
                {
                    C = number / 100;
                    remainderC = number % 100;
                    for (var i = C; C > 0; C--)
                        numeral = numeral + "C";
                }
                if (L > 0)
                {
                    L = number / 50;
                    remainderL = number % 50;
                    for (var i = L; L > 0; L--)
                        numeral = numeral + "L";
                }
                if (X > 0)
                {
                    X = number / 10;
                    remainderX = number % 10;
                    for (var i = X; X > 0; X--)
                        numeral = numeral + "X";
                }
                if (V > 0)
                {                    
                    V = number / 5;
                    remainderV = number % 5;                    
                    for (var i = V; V > 0; V--)
                        numeral = numeral + "V";                        
                }
                if (I > 0)
                {                    
                    I = number / 1;
                    remainderI = number % I;
                    for (var i = I; I > 0; I--)
                        numeral = numeral + "I";
                    if (numeral.EndsWith("IIII"))
                        numeral = numeral.Replace("IIII", "IV");
                }

                remainder = remainderI + remainderC + remainderX + remainderL + remainderC + remainderD + remainderM;
                //switch (number)
                //{
                //    case var n when n >= 1000:
                //        var multiplesOfThousand = number / 1000;
                //        remainderM = number % 1000;
                //        return "M";
                //    case var n when n >= 500:
                //        var multiplesOfFiveHundred = number / 500;
                //            return "D";
                //    case var n when n >= 100:
                //        var multiplesOfOneHundred = number / 100;
                //        return "C";
                //    case var n when n >= 50:
                //        var multiplesOfFifty = number / 50;
                //        return "L";
                //    case var n when n >= 10:
                //        var multiplesOfTen = number / 10;
                //        return "X";                    
                //    case var n when n >= 5:
                //        var multiplesOfFive = number / 5;
                //        return "V";
                //    case var n when n >= 1:
                //        var multiplesOfOne = number / 1;
                //        return "I";
                //    default: return " ";
                //}
            }
            return numeral;
        }    
    }
}
