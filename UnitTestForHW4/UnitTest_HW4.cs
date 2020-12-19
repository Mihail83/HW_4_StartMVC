using Microsoft.VisualStudio.TestTools.UnitTesting;
using HW_4_StartMVC.Services;

namespace UnitTestForHW4
{
    [TestClass]
    public class UnitTest_HW4
    {
        [TestMethod]
        public void TestValidatorKelvin_MinValue()
        {
            // Arrange 
            var validator = new ValidatorKelvin();
            //Act
            var boolResult = validator.Valid(0);
            //Assert
            Assert.AreEqual(true, boolResult);
        }
        [TestMethod]
        public void TestValidatorCelsius_MinValue()
        {
            // Arrange 
            var validator = new ValidatorCelsius();
            //Act
            var boolResult = validator.Valid(-273.3);
            //Assert
            Assert.AreEqual(true, boolResult);
        }

        [TestMethod]
        public void TestConvertToFahrenheit_0To32()
        {
            // Arrange 
            var converter = new ConvertToFahrenheit();
            //Act
            var result = converter.Convert(0);
            //Assert
            Assert.AreEqual(32, result);
        }

        [TestMethod]
        public void TestConvertToKelvin_0Tominus27315()
        {
            // Arrange 
            var converter = new ConvertToKelvin();
            //Act
            var result = converter.Convert(0);
            //Assert
            Assert.AreEqual(-273.15, result);
        }
    }
}
