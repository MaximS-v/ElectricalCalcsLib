namespace ElCalcLib
// Library of electrical calculations
{
    /// <summary>
    /// Thermal calculations
    /// </summary>
    public static class ThermalCalcs
    {

        /// <summary>
        /// Calculates temperature inside the cabinet without cooling and heating systems
        /// </summary>
        /// <param name="componentsPower">Power dissipated by internal components</param>
        /// <param name="heatTransferCoeff">Heat transfer coefficient for electrical cabinets in various materials</param>
        /// <param name="effectiveHeatExchangeArea">Effective heat exchange area of electrical cabinet</param>
        /// <param name="outT">Temperature outside the cabinet</param>
        /// <returns>Temperature inside the cabinet without cooling systems,
        /// if componentsPower == 0 returns outT
        /// if heatTransferCoeff == 0 or effectiveHeatExchangeArea == 0 returns Double.MaxValue</returns>
        public static double InsideTemp(double componentsPower, double heatTransferCoeff,
            double effectiveHeatExchangeArea, double outT)
        {
            if (componentsPower == 0) return outT;
            if (heatTransferCoeff == 0 || effectiveHeatExchangeArea == 0) return Double.MaxValue;
            return componentsPower / (heatTransferCoeff * effectiveHeatExchangeArea) + outT;
        }

        /// <summary>
        /// Defines layout of electrical cabinet about wall and another cabinets
        /// </summary>
        public enum ElCabsLayout
        {
            AllRoundAccess = 1,
            NearWall = 2,
            LastInLine = 3,
            LastInLIneNearWall = 4,
            MiddleInLine = 5,
            MiddleInLineNearWall = 6,
            MiddleInLineNearWallWithClosedTop = 7
        }

        /// <summary>
        /// Heat transfer coefficient for electrical cabinets in various materials, W/m2/deg_cels
        /// </summary>
        public struct HeatTransferCoeff
        {
            public const double MetallicPainted = 5.5;
            public const double Polyester = 3.5;
            public const double StainlessSteel = 3.7;
            public const double Aluminum = 12;
        }

        /// <summary>
        /// Calculates excess heat output of electrical cabinet
        /// </summary>
        /// <param name="componentsPower">Power dissipated by internal components</param>
        /// <param name="heatTransferCoeff">Heat transfer coefficient for electrical cabinets in various materials</param>
        /// <param name="effectiveHeatExchangeArea">Effective heat exchange area of electrical cabinet</param>
        /// <param name="inTmax">Maximum allowable temperature inside the cabinet</param>
        /// <param name="outTmax">Maximum possible temperature outside the cabinet</param>
        /// <returns>The amount of heat power that needs to be removed or Double.MaxValue if outTmax >= inTmax</returns>
        public static double ExcessHeatOutput(double componentsPower, double heatTransferCoeff, 

            double effectiveHeatExchangeArea, double inTmax, double outTmax)
        {
            if (outTmax >= inTmax) return Double.MaxValue;
            return componentsPower - (heatTransferCoeff * effectiveHeatExchangeArea * (inTmax - outTmax));
        }

        /// <summary>
        /// Calculates the effective heat transfer area of electrical cabinet
        /// </summary>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <param name="depth"></param>
        /// <param name="layout"></param>
        /// <returns></returns>
        public static double EffectiveHeatExchangeArea(double height, double width, double depth, ElCabsLayout layout)
        {
            switch (layout)
            {
                case ElCabsLayout.AllRoundAccess:
                    return 1.8 * height * (width + depth) + 1.4 * width * depth;
                case ElCabsLayout.NearWall:
                    return 1.4 * width * (height + depth) + 1.8 * depth * height;
                case ElCabsLayout.LastInLine:
                    return 1.4 * depth * (height + width) + 1.8 * width * height;
                case ElCabsLayout.LastInLIneNearWall:
                    return 1.4 * height * (width + depth) + 1.4 * width * depth;
                case ElCabsLayout.MiddleInLine:
                    return 1.8 * width * height + 1.4 * width * depth + depth * height;
                case ElCabsLayout.MiddleInLineNearWall:
                    return 1.4 * width * (height + depth) + depth * height;
                case ElCabsLayout.MiddleInLineNearWallWithClosedTop:
                    return 1.4 * width * height + 0.7 * width * depth + depth * height;
            }
            return 0;
        }

        /// <summary>
        /// Calculates the required airflow to remove excess heat from the electrical cabinet
        /// by means of forced air cooling at specified outdoor and indoor maximum temperatures
        /// Returns Double.MaxValue, if the outside temperature is greater than or equal to the inside
        /// and it is impossible to remove heat power by air flow
        /// </summary>
        /// <param name="overHeatPower">Excess heat output, W</param>
        /// <param name="inTmax">Maximum allowable temperature inside the cabinet</param>
        /// <param name="outTmax">Maximum possible temperature outside the cabinet</param>
        /// <returns>Required airflow in cubic meters per hour</returns>
        public static double RequiredAirflowValue(double overHeatPower, double inTmax, double outTmax)
        {
            if (outTmax >= inTmax) return Double.MaxValue;
            const double heatTransferCoeff = 3.1;
            return RequiredHeatExchangerPower(overHeatPower, inTmax, outTmax) * heatTransferCoeff;
        }

        /// <summary>
        /// Calculates the required heat exchanger capacity for the electrical cabinet
        /// Returns Double.MaxValue, if the outside temperature is greater than or equal to the inside
        /// and it is impossible to remove heat power by heat exchange
        /// </summary>
        /// <param name="overHeatPower">Excess heat output, W</param>
        /// <param name="inTmax">Maximum allowable temperature inside the cabinet</param>
        /// <param name="outTmax">Maximum possible temperature outside the cabinet</param>
        /// <returns>Required power of the heat exchanger, W per degree</returns>
        public static double RequiredHeatExchangerPower(double overHeatPower, double inTmax, double outTmax)
        {
            if (outTmax >= inTmax) return Double.MaxValue;
            return overHeatPower / (inTmax - outTmax);
        }

        /// <summary>
        /// Calculates dew point
        /// </summary>
        /// <param name="temp">temperature, degrees Celsius</param>
        /// <param name="relativeHumidity">relative humidity, in fractions of 1</param>
        /// <returns>dew point temperature, degrees Celsius</returns>
        public static double DewPoint(double temp, double relativeHumidity)
        {
            if (temp <= 0) return 0;
            const double a = 17.27;
            const double b = 237.7;
            var gamma = (a * temp) / (b + temp) + Math.Log(relativeHumidity);
            return (b * gamma) / (a - gamma);
        }
    }
}