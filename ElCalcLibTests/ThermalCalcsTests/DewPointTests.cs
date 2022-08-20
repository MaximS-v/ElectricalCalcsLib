using ElCalcLib;
namespace ElCalcLibTests.ThermalCalcsTests
{
    [TestClass]
    public class DewPointTests
    {
        /// <summary>
        /// Checks the dew point value at 100% humidity
        /// </summary>
        [TestMethod]
        public void DewPoint_100perc_humidity()
        {
            // Arrange
            double temp = 50;
            double RH = 1;
            double expected = temp;

            // Act
            double actual = ThermalCalcs.DewPoint(temp, RH);

            // Assert
            Assert.AreEqual(expected, actual, "Incorrect dew point value at 100% humidity");
        }

        /// <summary>
        /// Checks the dew point value at 50% humidity and 50 degrees Celsius
        /// </summary>
        [TestMethod]
        public void DewPoint_50_50()
        {
            // Arrange
            double temp = 50;
            double RH = 0.5;
            double expected = 37;

            // Act
            double actual = ThermalCalcs.DewPoint(temp, RH);

            // Assert
            Assert.AreEqual(expected, actual, 0.4, "Incorrect dew point value at 50% humidity and 50 deg C");
        }

        /// <summary>
        /// Checks the dew point value at zero temperature
        /// </summary>
        [TestMethod]
        public void DewPoint_zero_temp()
        {
            // Arrange
            double temp = 0;
            double RH = 0.5;
            double expected = 0;

            // Act
            double actual = ThermalCalcs.DewPoint(temp, RH);

            // Assert
            Assert.AreEqual(expected, actual, "Incorrect dew point value at zero temp");
        }

        /// <summary>
        /// Checks the dew point value at negative temperature
        /// </summary>
        [TestMethod]
        public void DewPoint_neg_temp()
        {
            // Arrange
            double temp = -10;
            double RH = 0.5;
            double expected = 0;

            // Act
            double actual = ThermalCalcs.DewPoint(temp, RH);

            // Assert
            Assert.AreEqual(expected, actual, "Incorrect dew point value at negative temp");
        }
    }
}
