using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveCharts;
using LiveCharts.WinForms;

namespace SCS.Last.WinForms.Services
{
    public class VizualizationDataService
    {
        private static readonly Random Random = new Random();

        private static Points[] OptimizeErrorPoints { get; set; }

        public static void SetCaresianChartBeforeAndAfter(CartesianChart cartesianChart ,Points[] points)
        {
            cartesianChart.AxisX.Clear();
            cartesianChart.AxisY.Clear();
            cartesianChart.Series.Clear();

            OptimizeErrorPoints = new Points[points.Length];

            var chartValuesOriginal = new ChartValues<double>();
            var chartValuesBeforeOptimization = new ChartValues<double>();
            var labels = new List<string>();

            var i = -1;
            foreach (var point in points)
            {
                i += 1;

                chartValuesOriginal.Add(point.Y);

                var newY = point.Y + Convert.ToDouble(Random.Next(-1, 1));

                OptimizeErrorPoints[i] = new Points()
                {
                    X = point.X,
                    Y = point.Y - newY
                };

                chartValuesBeforeOptimization.Add(newY);
                //chartValuesBeforeOptimization.Add();

                labels.Add(point.X.ToString(CultureInfo.InvariantCulture));
            }

            var seriesOriginal = new LiveCharts.Wpf.LineSeries()
            {
                Title = "Желаемая",
                Values = chartValuesOriginal
            };

            var seriesBeforeOptimization = new LiveCharts.Wpf.LineSeries()
            {
                Title = "Действительная",
                Values = chartValuesBeforeOptimization
            };

            cartesianChart.Series = new SeriesCollection()
            {
                seriesOriginal,
                seriesBeforeOptimization
            };

            cartesianChart.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Frequency",
                Labels = labels
            });

            cartesianChart.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Sales",
                LabelFormatter = value => value.ToString(CultureInfo.InvariantCulture)
            });

            cartesianChart.LegendLocation = LegendLocation.Right;
        }

        public static void SetCaresianChartOptimizeError(CartesianChart cartesianChart)
        {
            cartesianChart.AxisX.Clear();
            cartesianChart.AxisY.Clear();
            cartesianChart.Series.Clear();

            var chartValues = new ChartValues<double>();
            var labels = new List<string>();

            foreach (var point in OptimizeErrorPoints)
            {
                chartValues.Add(point.Y);
                labels.Add(point.X.ToString(CultureInfo.InvariantCulture));
            }

            var series = new LiveCharts.Wpf.LineSeries()
            {
                Title = "Погрешность",
                Values = chartValues
            };


            cartesianChart.Series = new SeriesCollection()
            {
                series
            };

            cartesianChart.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Frequency",
                Labels = labels
            });

            cartesianChart.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Sales",
                LabelFormatter = value => value.ToString(CultureInfo.InvariantCulture)
            });

            cartesianChart.LegendLocation = LegendLocation.Right;
        }
    }
}
