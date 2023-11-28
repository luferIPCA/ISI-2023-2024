using System;

namespace OutroRestfull
{
    /// <summary>
    /// Modelo auxiliar
    /// </summary>
    public class WeatherForecast
    {
        /// <summary>
        /// Data
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Temperatura em Celsius :
        /// <example> temperaturaC = 30</example>
        /// </summary>
        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}
