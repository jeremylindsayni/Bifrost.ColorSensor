using System;
using Windows.UI;

namespace Bifrost.ColorSensor
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ColorAttribute : Attribute
    {
        public byte Red { get; set; }

        public byte Green { get; set; }

        public byte Blue { get; set; }

        public ColorAttribute(byte red, byte green, byte blue)
        {
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
        }

        public Color PureColor()
        {
            return Color.FromArgb(0xFF, Red, Green, Blue);
        }
    }
}