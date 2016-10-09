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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace frqvs
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class frqvsDlg : Window
    {
        public frqvsDlg()
        {
            InitializeComponent();
        }

        private void ID_EXIT_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ID_CONS_Click(object sender, RoutedEventArgs e)
        {
            IDD_SIZE SIZE = new IDD_SIZE();
            SIZE.ShowDialog();
            ShowIddR(Data.nr);
        }

        private void ID_RED_Click(object sender, RoutedEventArgs e)
        {
            IDD_RED RED = new IDD_RED();
            RED.ShowDialog();
        }

        private void ID_FILE_Click(object sender, RoutedEventArgs e)
        {
            IDD_FILE FILE = new IDD_FILE();
            FILE.ShowDialog();
        }
    }
}
