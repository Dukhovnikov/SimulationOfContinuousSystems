using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
    /// Логика взаимодействия для IDD_FILE.xaml
    /// </summary>
    public partial class IDD_FILE : Window
    {
        public IDD_FILE()
        {
            InitializeComponent();
        }

        private void IDC_FILEOK_BUTTON_Click(object sender, RoutedEventArgs e)
        {
            FileOut(IDC_FILE.Text);
            Close();
        }

        void FileOut(string fileName)
        {
            StreamWriter Out = new StreamWriter(fileName);
            Out.WriteLine(Data.ConvertToFile());
            Out.Close();
        }
    }
}
