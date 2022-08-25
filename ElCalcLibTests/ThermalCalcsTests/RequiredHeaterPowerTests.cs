using ElCalcLib;

namespace ElCalcLibTests.ThermalCalcsTests
{
    [TestClass]
    public class RequiredHeaterPowerTests
    {
        [TestMethod]
        public void RequiredHeaterPowerTests_outTemp_exc_inTemp()
        {
            // Arrange
            double componentsPower = 800;
            double inTMin = 10;
            double outTMin = 15;
            double effectiveHeatExchangeArea = 4.13;
            double heatTransferCoeff = 5.5;
            double expected = 0;

            // Act
            double actual = ThermalCalcs.RequiredHeaterPower(componentsPower, inTMin, outTMin, 
                effectiveHeatExchangeArea, heatTransferCoeff);

            // Assert
            Assert.AreEqual(expected, actual, "Incorrect required heater power with out temp exc in temp");
        }

        [TestMethod]
        public void RequiredHeaterPowerTests_heater_not_need()
        {
            // Arrange
            double componentsPower = 120;
            double inTMin = 15;
            double outTMin = 10;
            double effectiveHeatExchangeArea = 4.13;
            double heatTransferCoeff = 5.5;
            double expected = 0;

            // Act
            double actual = ThermalCalcs.RequiredHeaterPower(componentsPower, inTMin, outTMin,
                effectiveHeatExchangeArea, heatTransferCoeff);

            // Assert
            Assert.AreEqual(expected, actual, "Incorrect required heater power with heater not need");
        }

        [TestMethod]
        public void RequiredHeaterPowerTests_correct_values()
        {
            // Arrange
            double componentsPower = 800;
            double inTMin = 10;
            double outTMin = -40;
            double effectiveHeatExchangeArea = 4.13;
            double heatTransferCoeff = 5.5;
            double expected = 336;

            // Act
            double actual = ThermalCalcs.RequiredHeaterPower(componentsPower, inTMin, outTMin,
                effectiveHeatExchangeArea, heatTransferCoeff);

            // Assert
            Assert.AreEqual(expected, actual, 0.5, "Incorrect required heater power with correct values");
        }
    }
}
