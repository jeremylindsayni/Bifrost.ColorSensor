using System;

namespace Bifrost.ColorSensor
{
    [AttributeUsage(AttributeTargets.Field)]
    public class BlueComponentLimitsAttribute : AbstractComponentLimitsAttribute
    {
        public BlueComponentLimitsAttribute(int lowerBound, int upperBound)
        {
            this.LowerBound = lowerBound;
            this.UpperBound = upperBound;
        }
    }
}