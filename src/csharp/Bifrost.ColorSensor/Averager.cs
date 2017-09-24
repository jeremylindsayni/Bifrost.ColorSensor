using System.Linq;

namespace Bifrost.ColorSensor
{
    public class Averager
    {
        public int SampleSize { get; set; }

        public int[] SampleArray;

        public Averager(int sampleSize)
        {
            this.SampleSize = sampleSize;
            this.SampleArray = new int[SampleSize];
        }

        public void AddToSampleArray(int sample)
        {
            for (int i = SampleSize - 1; i > 0; i--)
            {
                SampleArray[i] = SampleArray[i - 1];
            }

            SampleArray[0] = sample;
        }

        public double Average()
        {
            var arrayWithNonZeroEntries = SampleArray.Where(m => m != 0).ToArray();

            return arrayWithNonZeroEntries.Average();
        }
    }
}
