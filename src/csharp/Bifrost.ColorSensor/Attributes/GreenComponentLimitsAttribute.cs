using System;

namespace Bifrost.ColorSensor
{
    [AttributeUsage(AttributeTargets.Field)]
    public class GreenComponentLimitsAttribute : AbstractComponentLimitsAttribute
    {
        public GreenComponentLimitsAttribute(int lowerBound, int upperBound)
        {
            this.LowerBound = lowerBound;
            this.UpperBound = upperBound;
        }
    }
}