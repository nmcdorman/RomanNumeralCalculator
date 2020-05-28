using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumeralCalculator;

namespace RomanNumeralCalculator.UnitTests
{
    [TestClass]
    public class RomanNumeralCalculatorTests
    {
        [TestMethod]
        public void Add_I_and_II_Returns_III()
        {
            // Arrange
            var calc = new NumeralCalculator();

            // Act
            var result = calc.Add("I", "II");
            var result1 = calc.Add("II", "I");

            // Assert
            Assert.IsTrue(result == "III");
            Assert.IsTrue(result1 == "III");
        }

        [TestMethod]
        public void Add_I_and_III_Returns_IV()
        {
            // Arrange
            var calc = new NumeralCalculator();

            // Act
            var result = calc.Add("I", "III");
            var result1 = calc.Add("III", "I");

            // Assert
            Assert.IsTrue(result == "IV");
            Assert.IsTrue(result1 == "IV");
        }

        [TestMethod]
        public void Add_IV_and_II__Returns_VI()
        {
            // Arrange
            var calc = new NumeralCalculator();

            // Act
            var result = calc.Add("IV", "II");
            var result1 = calc.Add("II", "IV");

            // Assert
            Assert.IsTrue(result == "VI");
            Assert.IsTrue(result1 == "VI");
        }

        [TestMethod]
        public void Add_MCDXC_and_X__Returns_MD()
        {
            // Arrange
            var calc = new NumeralCalculator();

            // Act
            var result = calc.Add("MCDXC", "X");

            // Assert
            Assert.IsTrue(result == "MD");
            
        }
    }
}
