using Bifrost.Sensors;
using Bifrost.Uwp.Serial;
using System;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Devices.SerialCommunication;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Linq;
using System.Reflection;
using static Bifrost.Sensors.SensorExtensions;
using Bifrost.ColorSensor.Extensions;
using Windows.UI.Xaml.Media;
using Windows.Media.SpeechSynthesis;

namespace Bifrost.ColorSensor
{
    public sealed partial class MainPage : Page
    {
        private IDevice serialDevice = new Device();

        public MainPage()
        {
            this.InitializeComponent();

            this.Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            var aqs = SerialDevice.GetDeviceSelector();
            var arduinoWatcher = DeviceInformation.CreateWatcher(aqs);

            // Subscribe to device events
            arduinoWatcher.Added += new TypedEventHandler<DeviceWatcher, DeviceInformation>(OnDeviceAdded);
            arduinoWatcher.Removed += new TypedEventHandler<DeviceWatcher, DeviceInformationUpdate>(OnDeviceRemoved);

            arduinoWatcher.Start();
        }

        private async void OnDeviceRemoved(DeviceWatcher sender, DeviceInformationUpdate args)
        {
            serialDevice.CancelReading();

            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                () => pageTitle.Text = "Device removed");
        }

        private async void OnDeviceAdded(DeviceWatcher sender, DeviceInformation args)
        {
            if (args.IsUsbDevice())
            {
                serialDevice.SerialDeviceInformation = args;
                await serialDevice.ReadAndProcessSerialDataAsync(ProcessSerialOutput);
            }
        }

        private Averager averager = new Averager(5);

        private async Task ProcessSerialOutput(string serialOutput)
        {
            var sensorList = new SensorJsonConverter().Deserialize(serialOutput);

            string colorname = "";
            
            if (sensorList.Any())
            {
                try
                {
                    var hcsr04 = sensorList.Single<Hcsr04>();
                    var tcs34725 = sensorList.Single<Tcs34725>();

                    if (hcsr04.IsValidDistance())
                    {
                        averager.AddToSampleArray(hcsr04.Distance);

                        await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                        {
                            rangeDistance.Text = hcsr04.ToDistanceString();
                        });

                        if (hcsr04.IsInRange(20, 60))
                        {
                            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
                            {
                                var matchingColors = typeof(LegoColor)
                                    .GetFields()
                                    .WhereColorComponentInRange<RedComponentLimitsAttribute>(tcs34725.Red)
                                    .WhereColorComponentInRange<GreenComponentLimitsAttribute>(tcs34725.Green)
                                    .WhereColorComponentInRange<BlueComponentLimitsAttribute>(tcs34725.Blue)
                                    .ToList();

                                if (matchingColors?.Count() == 1)
                                {
                                    colorname = matchingColors.First().GetCustomAttribute<ColorNameAttribute>().Name;
                                    
                                    var color = matchingColors.First().GetCustomAttribute<ColorAttribute>().PureColor();

                                    this.myGrid.Background = new SolidColorBrush(color);

                                    if (this.pageTitle.Text != colorname)
                                    {
                                        var thingsToSay = new string[] 
                                        {
                                            $"Looks like you've got a {colorname} block.",
                                            $"I think that's a {colorname} piece.",
                                            $"Is it {colorname}?"
                                        };

                                        var speechSynthesizer = new SpeechSynthesizer();

                                        var r = new Random();
                                        int rInt = r.Next(0, thingsToSay.Length);
                                        
                                        var stream = await speechSynthesizer.SynthesizeTextToStreamAsync(thingsToSay[rInt]);
                                       
                                        media.SetSource(stream, stream.ContentType);
                                        media.Play();
                                    }

                                    this.pageTitle.Text = colorname;
                                }
                            });
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
