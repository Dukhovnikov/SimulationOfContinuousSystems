using System.Windows;

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
            IDC_NV.Text = Data.nv.ToString();
            IDC_NR.Text = Data.nr.ToString();
            IDC_NC.Text = Data.nc.ToString();
            IDC_NL.Text = Data.nl.ToString();
            IDC_NJU.Text = Data.nju.ToString();
            IDC_NEU.Text = Data.neu.ToString();
            IDC_NJI.Text = Data.nji.ToString();
            IDC_NEI.Text = Data.nei.ToString();
            IDC_NTB.Text = Data.ntb.ToString();
            IDC_NTU.Text = Data.ntu.ToString();
            IDC_NOU.Text = Data.nou.ToString();
            IDC_NTR.Text = Data.ntr.ToString();
            IDC_NOUI.Text = Data.noui.ToString();
            IDC_NTRI.Text = Data.ntri.ToString();
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
            Data.in_r = new int[Data.nr, 2];
            Data.z_r = new float[Data.nr];
            Close();
        }
    }
}
