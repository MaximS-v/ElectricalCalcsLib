using ElCalcLib;

namespace ElCalcLibTests.ThermalCalcsTests

{
    [TestClass]
    public class RequiredHeatExchangerPowerTests
    {
        /// <summary>
        /// Checks the method RequiredHeatExchangerPower
        /// at equal external and internal temperatures
        /// </summary>
        [TestMethod]
        public void RequiredHeatExchangerPower_outTemp_equal_inTemp()
        {
            // Arrange
            double outTemp = 50;
            double inTemp = 50;
            double overHeatPower = 100;
            double expected = double.MaxValue;

            // Act
            double actual = ThermalCalcs.RequiredHeatExchangerPower(overHeatPower, inTemp, outTemp);

            // Assert
            Assert.AreEqual(expected, actual, "Incorrect heat exchanger power at equal temperatures");
        }

        /// <summary>
        /// Checks the method RequiredHeatExchangerPower
        /// when the outside temperature is higher than the inside
        /// </summary>
        [TestMethod]
        public void RequiredHeatExchangerPower_outTemp_exc_inTemp()
        {
            // Arrange
            double outTemp = 60;
            double inTemp = 50;
            double overHeatPower = 100;
            double expected = double.MaxValue;

            // Act
            double actual = ThermalCalcs.RequiredHeatExchangerPower(overHeatPower, inTemp, outTemp);

            // Assert
            Assert.AreEqual(expected, actual, "Incorrect heat exchanger power at out temp exc in temp");
        }

        /// <summary>
        /// Checks the method RequiredHeatExchangerPower
        /// with correct parameters
        /// </summary>
        [TestMethod]
        public void RequiredHeatExchangerPower_correct()
        {
            // Arrange
            double outTemp = 50;
            double inTemp = 60;
            double overHeatPower = 100;
            double expected = 10;

            // Act
            double actual = ThermalCalcs.RequiredHeatExchangerPower(overHeatPower, inTemp, outTemp);

            // Assert
            Assert.AreEqual(expected, actual, "Incorrect heat exchanger power at correct parameters");
        }
    }

}