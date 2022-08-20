using ElCalcLib;

namespace ElCalcLibTests.ThermalCalcsTests
{
    [TestClass]
    public class InsideTempTests
    {
        [TestMethod]
        public void InsideTemp_ZeroHeatTransferCoeff()
        {
            // Arrange
            double componentsPower = 100;
            double heatTransferCoeff = 0;
            double effectiveHeatExchangeArea = 5;
            double outTmax = 30;
            double expected = Double.MaxValue;

            // Act
            var actual = ThermalCalcs.InsideTemp(componentsPower, heatTransferCoeff, effectiveHeatExchangeArea, outTmax);

            // Assert
            Assert.AreEqual(expected, actual, "Incorrect in temp with zero heat transfer coefficient");
        }

        [TestMethod]
        public void InsideTemp_ZeroEffectiveHeatExchangeArea()
        {
            // Arrange
            double componentsPower = 100;
            double heatTransferCoeff = 5;
            double effectiveHeatExchangeArea = 0;
            double outTmax = 30;
            double expected = Double.MaxValue;

            // Act
            var actual = ThermalCalcs.InsideTemp(componentsPower, heatTransferCoeff, effectiveHeatExchangeArea, outTmax);

            // Assert
            Assert.AreEqual(expected, actual, "Incorrect in temp with zero heat effective heat exchange area");
        }

        [TestMethod]
        public void InsideTemp_ZeroComponentsPower()
        {
            // Arrange
            double componentsPower = 0;
            double heatTransferCoeff = 5;
            double effectiveHeatExchangeArea = 5;
            double outTmax = 30;
            double expected = outTmax;

            // Act
            var actual = ThermalCalcs.InsideTemp(componentsPower, heatTransferCoeff, effectiveHeatExchangeArea, outTmax);

            // Assert
            Assert.AreEqual(expected, actual, "Incorrect in temp with zero heat components power");
        }

        [TestMethod]
        public void InsideTemp_CorrectValues()
        {
            // Arrange
            double componentsPower = 800;
            double heatTransferCoeff = 5.5;
            double effectiveHeatExchangeArea = 4.13;
            double outTmax = 35;
            double expected = 70;

            // Act
            var actual = ThermalCalcs.InsideTemp(componentsPower, heatTransferCoeff, effectiveHeatExchangeArea, outTmax);

            // Assert
            Assert.AreEqual(expected, actual, 0.5, "Incorrect in temp with correct values");
        }
    }
}
