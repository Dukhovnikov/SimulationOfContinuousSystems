using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace frqvs
{
    /// <summary>
    /// Логика взаимодействия для IDD_F.xaml
    /// </summary>
    public partial class IDD_F : Window
    {
        int item = 0;
        public IDD_F()
        {
            InitializeComponent();
        }

        private void IDC_F_Checked(object sender, RoutedEventArgs e)
        {
            item = 0;
            IDC_T1.Text = "Значение частоты (кГц)";
        }

        private void IDC_DF_Checked(object sender, RoutedEventArgs e)
        {
            item = 1;
            IDC_T1.Text = "Минимальная частота Fmin(кГц)";
            IDC_T2.Text = "Максимальная частота Fmax(кГц)";
            IDC_T3.Text = "Шаг изменения частоты dF(кГц)";
        }

        private void IDC_KF_Checked(object sender, RoutedEventArgs e)
        {
            item = 2;
            IDC_T1.Text = "Минимальная частота Fmin(кГц)";
            IDC_T2.Text = "Максимальная частота Fmax(кГц)";
            IDC_T3.Text = "Отношение соседних частот K";
        }

        private void IDC_FOK_BUTTON_Click(object sender, RoutedEventArgs e)
        {
            float fmin = float.Parse(IDC_F1.Text);
            float fmax = float.Parse(IDC_F2.Text);
            float df = float.Parse(IDC_F3.Text);
            switch (item)
            {
                case 0:
                    Data.f = new float[1];
                    Data.f[0] = float.Parse(IDC_F1.Text);
                    break;
                case 1:
                    Data.f = new float[Convert.ToInt32(Math.Ceiling((fmax - fmin) / df)) + 1];
                    Data.f[0] = fmin;
                    for (int i = 1; i < Data.f.Length; i++)
                    {
                        Data.f[i] = Data.f[i - 1] + df;
                    }
                    Data.f[Data.f.Length - 1] = fmax;
                    break;
                case 2:
                    break;
                default:
                    break;
            }
            Close();
        }
    }
}
