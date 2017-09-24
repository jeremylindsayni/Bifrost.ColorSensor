using System;
using System.Collections.Generic;
using System.Linq;

namespace Bifrost.Sensors
{
    public static class SensorExtensions
    {
        public static T Single<T>(this IList<ISensor> sensorList) where T : ISensor
        {
            return (T)sensorList.Single(m => string.Equals(m.Device, typeof(T).Name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
