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
    /// Логика взаимодействия для IDD_SIZE.xaml
    /// </summary>
    public partial class IDD_SIZE : Window
    {
        public IDD_SIZE()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            Data.nv = int.Parse(IDC_NV.Text);
            Data.nr = int.Parse(IDC_NR.Text);
            Data.nc = int.Parse(IDC_NC.Text);
            Data.nl = int.Parse(IDC_NL.Text);
            Data.nju = int.Parse(IDC_NJU.Text);
            Data.neu = int.Parse(IDC_NEU.Text);
            Data.nji = int.Parse(IDC_NJI.Text);
            Data.nei = int.Parse(IDC_NEI.Text);
            Data.ntb = int.Parse(IDC_NTB.Text);
            Data.ntu = int.Parse(IDC_NTU.Text);
            Data.nou = int.Parse(IDC_NOU.Text);
            Data.ntr = int.Parse(IDC_NTR.Text);
            Data.noui = int.Parse(IDC_NOUI.Text);
            Data.ntri = int.Parse(IDC_NTRI.Text);
            Data.in_r = new int[Data.nr + 1, 2];
            Data.z_r = new float[Data.nr + 1];
            Close();
        }
    }
}
