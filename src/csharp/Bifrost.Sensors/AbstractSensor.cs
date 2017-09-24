using System.Collections.Generic;

namespace Bifrost.Sensors
{
    public class AbstractSensor : ISensor
    {
        public string Protocol { get; set; }

        public string Device { get; set; }

        public IDictionary<string, string> Properties { get; set; }
    }
}