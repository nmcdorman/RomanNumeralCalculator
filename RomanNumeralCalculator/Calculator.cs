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
                {5, "V" },
                {10, "X" },
                {50, "L"},
                {100, "C"},
                {500, "D" },
                {1000, "M" }
            };
        }

        public string GetNumeral(long number)
        {
            var remainder = number;
            var M = (remainder / 1000);
            remainder -= GetNumber("M") * M;            
            var D = remainder / 500;
            remainder -= GetNumber("D") * D;
            var C = remainder / 100;
            remainder -= GetNumber("C") * C;
            var L = remainder / 50;
            remainder -= GetNumber("L") * L;
            var X = remainder / 10;
            remainder -= GetNumber("X") * X;
            var V = remainder / 5;
            remainder -= GetNumber("V") * V;
            var I = remainder / 1;
            remainder -= GetNumber("I") * I;

            var numeral = "";
            for (var i = M; M > 0; M--) numeral += "M";
            for (var i = D; D > 0; D--) numeral += "D";
            for (var i = C; C > 0; C--) numeral += "C";
            for (var i = L; L > 0; L--) numeral += "L";
            for (var i = X; X > 0; X--) numeral += "X";
            for (var i = V; V > 0; V--) numeral += "V";
            for (var i = I; I > 0; I--) numeral += "I";

            var remainderD = M % 1000;
            var remainderC = D % 500;
            var remainderL = C % 100;
            var remainderX = L % 50;
            var remainderV = X % 10;
            var remainderI = V % 5;

            remainder = remainderD + remainderC + remainderL
                            + remainderX + remainderV + remainderI;

            numeral = numeral.Replace("IIII", "IV");
            numeral = numeral.Replace("XXXX", "XL");
            numeral = numeral.Replace("CCCC", "CD");

            return numeral;
        }

        public long GetNumber(string numeral)
        {
            var numerals = GetNumerals();
            var numeralArray = numeral.ToCharArray();
            long number = 0;

            if (numerals.ContainsValue(numeral))
                number = numerals.FirstOrDefault(n => n.Value == numeral).Key;
            else
            {
                if (numeral.Length == 1)
                    number = GetNumber(numeralArray[0].ToString());
                else
                {
                    for (var i = numeral.Length - 1; i >= 0; i--)
                    {
                        if (i == 0)
                        {
                            number += GetNumber(numeralArray[i].ToString());
                        }
                        else
                        {
                            if ((numeralArray[i].ToString() == "M" && numeralArray[i - 1].ToString() == "C")
                                || (numeralArray[i].ToString() == "D" && numeralArray[i - 1].ToString() == "C")
                                || (numeralArray[i].ToString() == "C" && numeralArray[i - 1].ToString() == "X")
                                || (numeralArray[i].ToString() == "L" && numeralArray[i - 1].ToString() == "X")
                                || (numeralArray[i].ToString() == "X" && numeralArray[i - 1].ToString() == "I")
                                || (numeralArray[i].ToString() == "V" && numeralArray[i - 1].ToString() == "I"))
                                number += (GetNumber(numeralArray[i].ToString())
                                            - GetNumber(numeralArray[i - 1].ToString()))
                                            - GetNumber(numeralArray[i - 1].ToString());
                            else
                                number += GetNumber(numeralArray[i].ToString());

                        }
                    }
                }
            }
            return number;
        }
    }
}