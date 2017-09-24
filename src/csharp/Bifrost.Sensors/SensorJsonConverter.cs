using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Bifrost.Sensors
{
    public class SensorJsonConverter
    {
        public IList<ISensor> Deserialize(string sensorJson)
        {
            var sensorList = new List<ISensor>();

            try
            {
                var sensor = JsonConvert.DeserializeObject(sensorJson);

                switch (sensor)
                {
                    case JArray sensorArray:
                        foreach (JObject sensorObject in sensorArray)
                        {
                            sensorList.Add(GetDeserializedSensor(sensorObject));
                        }

                        break;
                    case JObject sensorObject:

                        sensorList.Add(GetDeserializedSensor(sensorObject));
                        break;
                    default:
                        throw new Exception("Json deserialized to unexpected object.");
                }
            }
            catch (JsonReaderException jsonReaderException)
            {
                Debug.WriteLine($"Invalid JSON - this may be among first serial messages. {jsonReaderException.Message}");
                Debug.WriteLine(sensorJson);
            }

            return sensorList;
        }

        private ISensor GetDeserializedSensor(JObject jObject)
        {
            var device = jObject.SelectToken("Device") as JValue;
            var deviceName = device.Value as string;

            Type sensorType = GetSensorType(deviceName);

            return jObject.ToObject(sensorType) as ISensor;
        }

        public Type GetSensorType(string sensorName)
        {
            var classNamespace = GetType().Namespace;
            string sensorTypeName = string.Concat(classNamespace, ".", sensorName);
            return Type.GetType(sensorTypeName, true, true);
        }
    }
}
