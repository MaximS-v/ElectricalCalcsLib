using ElCalcLib;

namespace ElCalcLibTests.ThermalCalcsTests
{
    [TestClass]
    public class RequiredAirflowValueTests
    {
        /// <summary>
        /// Checks the method RequiredAirflowValue
        /// at equal external and internal temperatures
        /// </summary>
        [TestMethod]
        public void RequiredAirflowValue_outTemp_equal_inTemp()
        {
            // Arrange
            double outTemp = 50;
            double inTemp = 50;
            double overHeatPower = 100;
            double expected = double.MaxValue;

            // Act
            double actual = ThermalCalcs.RequiredAirflowValue(overHeatPower, inTemp, outTemp);

            // Assert
            Assert.AreEqual(expected, actual, "Incorrect airflow value at equal temperatures");
        }

        /// <summary>
        /// Checks the method RequiredAirflowValue
        /// when the outside temperature is higher than the inside
        /// </summary>
        [TestMethod]
        public void RequiredAirflowValue_outTemp_exc_inTemp()
        {
            // Arrange
            double outTemp = 60;
            double inTemp = 50;
            double overHeatPower = 100;
            double expected = double.MaxValue;

            // Act
            double actual = ThermalCalcs.RequiredAirflowValue(overHeatPower, inTemp, outTemp);

            // Assert
            Assert.AreEqual(expected, actual, "Incorrect airflow value at out temp exc in temp");
        }

        /// <summary>
        /// Checks the method RequiredAirflowValue
        /// when the outside temperature is less than the inside
        /// </summary>
        [TestMethod]
        public void RequiredAirflowValue_correct()
        {
            // Arrange
            double outTemp = 50;
            double inTemp = 60;
            double overHeatPower = 100;
            double expected = 31;

            // Act
            double actual = ThermalCalcs.RequiredAirflowValue(overHeatPower, inTemp, outTemp);

            // Assert
            Assert.AreEqual(expected, actual, "Incorrect airflow value at correct parameters");
        }
    }
}
