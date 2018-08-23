using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mime;
using SCS.Last.WinForms.Services;
using Telerik.Charting;
using Telerik.WinControls.UI;
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Forms;
using SCS.Core.Last.Core;
using SCS.Core.Last.Core.GA;

namespace SCS.Last.WinForms.Forms
{
        // ReSharper disable once InconsistentNaming
    public partial class SCSLastRedForm : Telerik.WinControls.UI.RadForm
    {
        public SCSLastRedForm()
        {
            InitializeComponent();

            //InitializeCartesianChart();
            InitializeListBoxCodingType();
            InitializeListBoxCrossingType();

            textBoxMutationRate.Enabled = false;
            textBoxBreakGeneration.Enabled = false;
            textBoxInversionRate.Enabled = false;

           
        }

        private void InitializeListBoxCodingType()
        {
            listBoxCodingType.DataSource = DataVisualizationService.GetCodingAndCrossingViews()
                .Select(item => item.ViewsCoding)
                .Distinct()
                .ToList();

            listBoxCodingType.SelectedIndex = 0;
        }

        private void InitializeListBoxCrossingType()
        {
            listBoxCrossingType.SelectedIndex = 1;
        }

        private void InitializeCartesianChart()
        {
            const double step = 0.5;
            const double factor = 1000;
            const int maxStep = 2;
            var temp = 0.0;

            var points = new List<Points>
            {
                new Points()
                {
                    Y = ComputeService.GetPhaseFrequencyСharacteristic(temp),
                    X = 1
                }
            };


            while (temp < maxStep)
            {
                temp += step;

                var frequency = ComputeService.GetPhaseFrequencyСharacteristic(temp * factor);

                points.Add(new Points()
                {
                    X = temp,
                    Y = frequency
                });
            }

            var chartValues = new ChartValues<double>();

            foreach (var point in points)
            {
                chartValues.Add(point.Y);
            }

            var series = new LiveCharts.Wpf.LineSeries()
            {
                Title = "АЧХ",
                Values = chartValues
            };

            //cartesianChartShowData.Series = new SeriesCollection
            //{
            //    new LiveCharts.Wpf.LineSeries
            //    {
            //        Title = "АЧХ",
            //        Values = new ChartValues<double> {10, 6, 5, 2, 7}
            //    }
            //};

            cartesianChartShowData.Series = new SeriesCollection() {series};

            cartesianChartShowData.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Frequency",
                Labels = new[] { "1", "0,5 * 10^3", "1 * 10^3", "1,5 * 10^3", "2 * 10^3" }
            });

            cartesianChartShowData.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Sales",
                LabelFormatter = value => value.ToString(CultureInfo.InvariantCulture)
            });

            cartesianChartShowData.LegendLocation = LegendLocation.Right;
        }

        private void SCSLastRedForm_Load(object sender, EventArgs e)
        {
            //WinApiService.AnimateWindow(this.Handle, 5000, WinApiService.Blend);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOpt_Click(object sender, EventArgs e)
        {
            panelOpt.Visible = true;
            panelExamples.Visible = false;
        }

        private void buttonExamples_Click(object sender, EventArgs e)
        {
            panelExamples.Visible = true;
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            panelOpt.Visible = false;
            panelExamples.Visible = false;

            var modelingService = new ModelingService();
            modelingService.Initialize(int.Parse(textBoxPointsCount.Text), double.Parse(textBoxStartFrequency.Text),
                double.Parse(textBoxFinishFrequency.Text));

            var points = modelingService.GetPoints(ComputeService.GetPhaseFrequencyСharacteristic);
            VizualizationDataService.SetCaresianChartBeforeAndAfter(cartesianChartShowData, points);
            VizualizationDataService.SetCaresianChartOptimizeError(cartesianChartOptError);
        }

        private void listBoxCodingType_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxCrossingType.DataSource = DataVisualizationService.GetCodingAndCrossingViews()
                .Where(item => (listBoxCodingType.SelectedItem.ToString() == item.ViewsCoding))
                .Select(item => item.ViewsСrossing)
                .ToList();

            switch (listBoxCodingType.SelectedIndex)
            {
                case 0: checkBoxMeshSeal.Enabled = false; Vectors.CodingType = Coding.Real; textBoxBitsCount.Enabled = false; break;
                case 1: checkBoxMeshSeal.Enabled = true; Vectors.CodingType = Coding.Integer; textBoxBitsCount.Enabled = true; break;
            }
        }

        private void listBoxCrossingType_SelectedIndexChanged(object sender, EventArgs e)
        {
            GA.AssignedDelegat(listBoxCodingType.SelectedIndex, listBoxCrossingType.SelectedIndex);
        }

        private void checkBoxMutation_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMutation.Checked)
            {
                textBoxMutationRate.Enabled = true;
            }
            else
            {
                textBoxMutationRate.Enabled = false;
                GA.MutationProbability = -1;
                textBoxMutationRate.Text = "";
            }
            
        }

        private void checkBoxInversion_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxInversion.Checked)
            {
                textBoxInversionRate.Enabled = true;
            }
            else
            {
                textBoxInversionRate.Enabled = false;
                GA.InversionProbability = -1;
                textBoxInversionRate.Text = "";
            }
        }

        private void checkBoxPopulationSpike_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPopulationSpike.Checked)
            {
                GA.PopulationSpike = true;
            }
            else
            {
                GA.PopulationSpike = false;
            }
        }

        private void checkBoxMeshSeal_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMeshSeal.Checked)
            {
                GA.PopulationMeshSeal = true;
            }
            else
            {
                GA.PopulationMeshSeal = false;
            }
        }

        private void checkBoxBreakGeneration_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxBreakGeneration.Checked)
            {
                textBoxBreakGeneration.Enabled = true;
            }
            else
            {
                GA.BreakGeneration = -1;
                textBoxBreakGeneration.Enabled = false;
            }
        }

        private void checkBoxClassicMO_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxClassicMO.Checked)
            {
                isUseClassicMO = true;
                groupBoxClassicMO.Enabled = true;
            }
            else
            {
                isUseClassicMO = false;
                groupBoxClassicMO.Enabled = false;
            }
        }
        /// <summary>
        /// Переменная, для определления - использовать/не использовать классические методы оптимизации.
        /// </summary>
        bool isUseClassicMO = false;

        //private void InitializeRedChart()
        //{
        //    const int step = 500;
        //    const int factor = 1000;
        //    const int maxStep = 2000;
        //    var temp = 1;
        //    var points = new List<Points>
        //    {
        //        new Points()
        //        {
        //            Y = ComputeService.GetPhaseFrequencyСharacteristic(temp),
        //            X = 1
        //        }
        //    };


        //    while (temp < maxStep)
        //    {
        //        var frequency = ComputeService.GetPhaseFrequencyСharacteristic(temp * factor);

        //        points.Add(new Points()
        //        {
        //            X = temp,
        //            Y = frequency
        //        });

        //        temp += step;
        //    }

        //    var series = new Telerik.WinControls.UI.LineSeries
        //    {
        //        Spline = true
        //    };

        //    foreach (var point in points)
        //    {
        //        series.DataPoints.Add(point.Y, point.X);
        //    }

        //    this.radChartViewShowGraph.Series.Add(series);

        //    var area = this.radChartViewShowGraph.GetArea<CartesianArea>();
        //    area.ShowGrid = true;
        //    var grid = area.GetGrid<CartesianGrid>();
        //    grid.DrawHorizontalFills = true;
        //    grid.BorderDashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
        //}

        //private void InitializeTestRedChart()
        //{
        //    var series = new Telerik.WinControls.UI.LineSeries
        //    {
        //        Spline = true
        //    };

        //    series.DataPoints.Add(new CategoricalDataPoint(500, "Jan"));
        //    series.DataPoints.Add(new CategoricalDataPoint(300, "Apr"));
        //    series.DataPoints.Add(new CategoricalDataPoint(400, "Jul"));
        //    series.DataPoints.Add(new CategoricalDataPoint(250, "Oct"));

        //    this.radChartViewShowGraph.Series.Add(series);

        //    var area = this.radChartViewShowGraph.GetArea<CartesianArea>();
        //    area.ShowGrid = true;
        //    var grid = area.GetGrid<CartesianGrid>();
        //    grid.DrawHorizontalFills = true;
        //    grid.BorderDashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
        //}
    }
}
