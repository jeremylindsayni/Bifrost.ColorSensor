using System.Linq;
using System.Reflection;

namespace Bifrost.ColorSensor.Extensions
{
    public static class ColorFieldInfoExtensions
    {
        public static FieldInfo[] WhereColorComponentInRange<T>(this FieldInfo[] fieldInfo, byte colorValue) where T : AbstractComponentLimitsAttribute
        {
            return fieldInfo
                    .Where(m => m.GetCustomAttribute<T>()?.LowerBound < colorValue)
                    .Where(m => m.GetCustomAttribute<T>()?.UpperBound > colorValue)
                    .ToArray();
        }
    }
}
