using System;

namespace Bifrost.ColorSensor
{
    [AttributeUsage(AttributeTargets.Field)]
    public abstract class AbstractComponentLimitsAttribute : Attribute
    {
        public int LowerBound { get; set; }

        public int UpperBound { get; set; }
    }
}