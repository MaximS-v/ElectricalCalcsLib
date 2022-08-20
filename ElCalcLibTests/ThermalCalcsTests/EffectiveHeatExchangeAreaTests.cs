using ElCalcLib;
using static ElCalcLib.ThermalCalcs;

namespace ElCalcLibTests.ThermalCalcsTests
{
    [TestClass]
    public class EffectiveHeatExchangeAreaTests
    {
        [DataTestMethod]
        [DataRow(0.3, 0.2, 0.15, 1, 0.23)]
        [DataRow(0.3, 0.2, 0.15, 2, 0.21)]
        [DataRow(0.3, 0.2, 0.15, 3, 0.21)]
        [DataRow(0.3, 0.2, 0.15, 4, 0.19)]
        [DataRow(0.3, 0.2, 0.15, 5, 0.2)]
        [DataRow(0.3, 0.2, 0.15, 6, 0.17)]
        [DataRow(0.3, 0.2, 0.15, 7, 0.15)]
        [DataRow(1.2, 1, 0.3, 1, 3.23)]
        [DataRow(1.2, 1, 0.3, 2, 2.75)]
        [DataRow(1.2, 1, 0.3, 3, 3.08)]
        [DataRow(1.2, 1, 0.3, 4, 2.6)]
        [DataRow(1.2, 1, 0.3, 5, 2.94)]
        [DataRow(1.2, 1, 0.3, 6, 2.46)]
        [DataRow(1.2, 1, 0.3, 7, 2.25)]
        [DataRow(2, 1.6, 0.6, 1, 9.26)]
        [DataRow(2, 1.6, 0.6, 2, 7.98)]
        [DataRow(2, 1.6, 0.6, 3, 8.78)]
        [DataRow(2, 1.6, 0.6, 4, 7.5)]
        [DataRow(2, 1.6, 0.6, 5, 8.3)]
        [DataRow(2, 1.6, 0.6, 6, 7.02)]
        [DataRow(2, 1.6, 0.6, 7, 6.35)]
        public void EffectiveHeatExchangeArea_CorrectValues_Tests(double height, double width, double depth,
            ElCabsLayout layout, double expected)
        {
            // Act
            double actual = EffectiveHeatExchangeArea(height, width, depth, layout);

            //Assert
            Assert.AreEqual(expected, actual, 0.01, "Incorrect effective heat exchange area with correct parameters");
        }
    }
}
