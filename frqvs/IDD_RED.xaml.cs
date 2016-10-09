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
    /// Логика взаимодействия для IDD_RED.xaml
    /// </summary>
    public partial class IDD_RED : Window
    {
        public IDD_RED()
        {
            InitializeComponent();
            HideAll();
        }

        private void IDC_RED_LIST_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OnclkRedList(IDC_RED_LIST.SelectedIndex);
        }
        void HideAll()
        {
            label1.Visibility = Visibility.Hidden;
            label2.Visibility = Visibility.Hidden;
            label3.Visibility = Visibility.Hidden;
            label4.Visibility = Visibility.Hidden;
            label5.Visibility = Visibility.Hidden;
            label6.Visibility = Visibility.Hidden;
            label7.Visibility = Visibility.Hidden;
            label8.Visibility = Visibility.Hidden;
            label9.Visibility = Visibility.Hidden;
            label10.Visibility = Visibility.Hidden;

            IDC_NP1.Visibility = Visibility.Hidden;
            IDC_NP2.Visibility = Visibility.Hidden;
            IDC_NM1.Visibility = Visibility.Hidden;
            IDC_NM2.Visibility = Visibility.Hidden;
            IDC_Z1.Visibility = Visibility.Hidden;
            IDC_Z2.Visibility = Visibility.Hidden;
            IDC_Z3.Visibility = Visibility.Hidden;
            IDC_Z4.Visibility = Visibility.Hidden;
            IDC_Z5.Visibility = Visibility.Hidden;
            IDC_Z6.Visibility = Visibility.Hidden;

        }
        void OnclkRedList(int itemNumber)
        {
            switch (itemNumber)
            {
                case 0:
                    HideAll();
                    IDC_NP1.Visibility = Visibility.Visible;
                    IDC_NP2.Visibility = Visibility.Visible;
                    IDC_NM1.Visibility = Visibility.Visible;
                    label1.Visibility = Visibility.Visible;
                    label2.Visibility = Visibility.Visible;
                    label3.Visibility = Visibility.Visible;
                    break;
                case 1:
                    HideAll();
                    IDC_NP1.Visibility = Visibility.Visible;
                    IDC_NP2.Visibility = Visibility.Visible;
                    IDC_NM1.Visibility = Visibility.Visible;
                    label1.Visibility = Visibility.Visible;
                    label2.Visibility = Visibility.Visible;
                    label3.Visibility = Visibility.Visible;
                    break;
                case 2:
                    HideAll();
                    IDC_NP1.Visibility = Visibility.Visible;
                    IDC_NP2.Visibility = Visibility.Visible;
                    IDC_NM1.Visibility = Visibility.Visible;
                    label1.Visibility = Visibility.Visible;
                    label2.Visibility = Visibility.Visible;
                    label3.Visibility = Visibility.Visible;
                    break;
                case 3:
                    HideAll();
                    break;
                case 4:
                    HideAll();
                    break;
                case 5:
                    HideAll();
                    break;
                case 6:
                    HideAll();
                    break;
                case 7:
                    HideAll();
                    break;
                case 8:
                    HideAll();
                    break;
                case 9:
                    HideAll();
                    break;
                case 10:
                    HideAll();
                    break;
                case 11:
                    HideAll();
                    break;
                case 12:
                    HideAll();
                    break;
                default:
                    break;
            }
        }

        private void IDC_OUT_BUTTON_Click(object sender, RoutedEventArgs e)
        {
            switch (IDC_RED_LIST.SelectedIndex)
            {
                case 0:
                    IDC_NP1.Text = Data.in_r[int.Parse(IDC_N.Text) - 1, 0].ToString();
                    IDC_NM1.Text = Data.in_r[int.Parse(IDC_N.Text) - 1, 1].ToString();
                    IDC_NP2.Text = Data.z_r[int.Parse(IDC_N.Text) - 1].ToString();
                    break;
                default:
                    break;
            }
        }

        private void IDC_IN_BUTTON_Click(object sender, RoutedEventArgs e)
        {
            switch (IDC_RED_LIST.SelectedIndex)
            {
                case 0:
                    Data.in_r[int.Parse(IDC_N.Text) - 1, 0] = int.Parse(IDC_NP1.Text);
                    Data.in_r[int.Parse(IDC_N.Text) - 1, 1] = int.Parse(IDC_NM1.Text);
                    Data.z_r[int.Parse(IDC_N.Text) - 1] = int.Parse(IDC_NP2.Text);
                    break;
                default:
                    break;
            }
        }

        private void IDC_OK_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
