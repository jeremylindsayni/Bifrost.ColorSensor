using System;

namespace Bifrost.ColorSensor
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ColorNameAttribute : Attribute
    {
        public string Name { get; set; }

        public ColorNameAttribute(string name)
        {
            this.Name = name;
        }
    }
}