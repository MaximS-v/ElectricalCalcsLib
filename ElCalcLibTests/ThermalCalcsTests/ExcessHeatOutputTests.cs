using ElCalcLib;

namespace ElCalcLibTests.ThermalCalcsTests
{
    [TestClass]
    public class ExcessHeatOutputTests
    {
        [TestMethod]
        public void ExcessHeatOutput_CorrectValues_Test()
        {
            // Arrange
            double componentsPower = 800;
            double heatTransferCoeff = ThermalCalcs.HeatTransferCoeff["MetallicPainted"];
            double effectiveHeatExchangeArea = 4.13;
            double inTmax = 40;
            double outTmax = 35;
            double expected = 686.4;

            // Action
            double actual = ThermalCalcs.ExcessHeatOutput(componentsPower, heatTransferCoeff, effectiveHeatExchangeArea,
                inTmax, outTmax);

            // Assert
            Assert.AreEqual(expected, actual, 0.1, "Incorrect excess heat output with correct values");
        }

        [TestMethod]
        public void ExcessHeatOutput_inTmax_less_outTmax()
        {
            // Arrange
            double componentsPower = 800;
            double heatTransferCoeff = ThermalCalcs.HeatTransferCoeff["MetallicPainted"];
            double effectiveHeatExchangeArea = 4.13;
            double inTmax = 35;
            double outTmax = 40;
            double expected = Double.MaxValue;

            // Action
            double actual = ThermalCalcs.ExcessHeatOutput(componentsPower, heatTransferCoeff, effectiveHeatExchangeArea,
                inTmax, outTmax);

            // Assert
            Assert.AreEqual(expected, actual, "Incorrect excess heat output with in temp less out temp");
        }
    }
}
