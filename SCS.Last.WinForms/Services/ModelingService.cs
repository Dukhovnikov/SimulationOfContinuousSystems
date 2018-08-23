using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCS.Last.WinForms.Forms;

namespace SCS.Last.WinForms.Services
{
    public class ModelingService
    {
        public double StartFrequencyDouble { get; set; }
        public double FinishFrequencyDouble { get; set; }

        public int PointsCountInt { get; set; }

        public Points[] GetPoints(Func<double, double> frequencyFunc)
        {
            var points = new Points[PointsCountInt];

            var step = FinishFrequencyDouble / PointsCountInt;
            var currentFrequency = StartFrequencyDouble;

            points[0] = new Points()
            {
                X = StartFrequencyDouble,
                Y = frequencyFunc(currentFrequency)
            };

            currentFrequency += step;
            for (var i = 1; i < PointsCountInt; i++)
            {
                points[i] = new Points()
                {
                    X = currentFrequency,
                    Y = frequencyFunc(currentFrequency)
                };

                currentFrequency += step;
            }

            return points;
        }

        public void Initialize(int pointsCountInt, double startFrequencyDouble, double finishFrequencyDouble)
        {
            this.PointsCountInt = pointsCountInt;
            this.StartFrequencyDouble = startFrequencyDouble;
            this.FinishFrequencyDouble = finishFrequencyDouble;
        }

    }
}
