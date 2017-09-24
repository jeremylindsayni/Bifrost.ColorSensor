using System;

namespace Bifrost.ColorSensor
{
    [AttributeUsage(AttributeTargets.Field)]
    public class RedComponentLimitsAttribute : AbstractComponentLimitsAttribute
    {
        public RedComponentLimitsAttribute(int lowerBound, int upperBound)
        {
            this.LowerBound = lowerBound;
            this.UpperBound = upperBound;
        }
    }
}