using System;

namespace SCS.Last.WinForms.Services
{
    public class ComputeService
    {
        public static double GetPhaseFrequencyСharacteristic(double frequency)
        {
            var rezult = (7.2 * 100000) / (frequency * Math.Sqrt(8.1 * 100000 + frequency * frequency) *
                                           Math.Sqrt(1.44 * 10000 + 3.894 * frequency * frequency));

            return double.IsInfinity(rezult) ? int.MaxValue : rezult;
        }


    }
}