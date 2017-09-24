using System;

namespace Bifrost.Sensors
{
    public class Dht11 : AbstractSensor
    {
        public int Temperature
        {
            get
            {
                return Convert.ToInt32(Properties[nameof(Temperature)]);
            }
        }

        public int Humidity
        {
            get
            {
                return Convert.ToInt32(Properties[nameof(Humidity)]);
            }
        }
    }
}
