using System;

namespace Bifrost.Sensors
{
    public class Hcsr04 : AbstractSensor
    {
        private int MINIMUM_DISTANCE_IN_MM = 20;
        private int MAXIMUM_DISTANCE_IN_MM = 4000;

        public int Distance
        {
            get
            {
                return Convert.ToInt32(Properties[nameof(Distance)]);
            }
        }

        public bool IsValidDistance()
        {
            return IsInRange(MINIMUM_DISTANCE_IN_MM, MAXIMUM_DISTANCE_IN_MM);
        }

        public bool IsInRange(int minimum, int maximum)
        {
            if (this.Distance > minimum && this.Distance < maximum)
            {
                return true;
            }

            return false;
        }

        public string ToDistanceString()
        {
            return string.Concat(this.Distance, "mm");
        }
    }
}
