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
            var calc = new NumeralCalculator(); // Arrange
                        
            var result = calc.Add("I", "II");   // Act
            var result1 = calc.Add("II", "I");
                        
            Assert.IsTrue(result == "III");     // Assert
            Assert.IsTrue(result1 == "III");
        }

        [TestMethod]
        public void Add_I_and_III_Returns_IV()
        {            
            var calc = new NumeralCalculator(); // Arrange
                        
            var result = calc.Add("I", "III");  // Act
            var result1 = calc.Add("III", "I");
                        
            Assert.IsTrue(result == "IV");      // Assert
            Assert.IsTrue(result1 == "IV");
        }

        [TestMethod]
        public void Add_IV_and_II__Returns_VI()
        {            
            var calc = new NumeralCalculator(); // Arrange
                        
            var result = calc.Add("IV", "II");  // Act
            var result1 = calc.Add("II", "IV");

            Assert.IsTrue(result == "VI");      // Assert
            Assert.IsTrue(result1 == "VI");
        }

        [TestMethod]
        public void Add_MCDXC_and_X__Returns_MD()
        {            
            var calc = new NumeralCalculator();     // Arrange
                        
            var result = calc.Add("MCDXC", "X");    // Act
                        
            Assert.IsTrue(result == "MD");          // Assert
        }

        [TestMethod]
        public void Add_LX_and_X__Returns_LXX()
        {
            var calc = new NumeralCalculator();     // Arrange
                        
            var result = calc.Add("LX", "X");       // Act
                        
            Assert.IsTrue(result == "LXX");         // Assert
        }

        [TestMethod]
        public void Add_LXXIX_and_CXLI__Returns_CCXX()
        {            
            var calc = new NumeralCalculator();     // Arrange
                        
            var result = calc.Add("LXXIX", "CXLI"); // Act
                        
            Assert.IsTrue(result == "CCXX");        // Assert
        }

        [TestMethod]
        public void Add_CXLVII_and_CL__Returns_CCXCVII()
        {            
            var calc = new NumeralCalculator();     // Arrange
                        
            var result = calc.Add("CXLVII", "CL");  // Act
                        
            Assert.IsTrue(result == "CCXCVII");     // Assert
        }

        [TestMethod]
        public void Add_MCDLXXX_and_X__Returns_MCDXC()
        {
            
            var calc = new NumeralCalculator();     // Arrange
                        
            var result = calc.Add("MCDLXXX", "X");  // Act
                        
            Assert.IsTrue(result == "MCDXC");       // Assert
        }

        [TestMethod]
        public void Add_MMCCLXXXIV_and_MCCIX__Returns_MMMCDXCIII()
        {
            //  2284 + 1209
            var calc = new NumeralCalculator();     // Arrange

            var result = calc.Add("MMCCLXXXIV", "MCCIX");  // Act

            Assert.IsTrue(result == "MMMCDXCIII");       // Assert
        }
    }
}
