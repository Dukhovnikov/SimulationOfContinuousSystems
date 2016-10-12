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
    /// Логика взаимодействия для IDD_INT.xaml
    /// </summary>
    public partial class IDD_INT : Window
    {
        public IDD_INT()
        {
            InitializeComponent();
        }

        private void IDC_EXIT_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
