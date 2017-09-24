using System;

namespace Bifrost.Sensors
{
    public class Tcs34725 : AbstractSensor
    {
        public byte Red
        {
            get
            {
                return Convert.ToByte(Properties[nameof(Red)], 16);
            }
        }

        public byte Green
        {
            get
            {
                return Convert.ToByte(Properties[nameof(Green)], 16);
            }
        }

        public byte Blue
        {
            get
            {
                return Convert.ToByte(Properties[nameof(Blue)], 16);
            }
        }

        public byte Clear
        {
            get
            {
                return Convert.ToByte(Properties[nameof(Clear)], 16);
            }
        }

        public override string ToString()
        {
            return string.Concat(Red.ToString("X"), Green.ToString("X"), Blue.ToString("X"));
        }
    }
}
