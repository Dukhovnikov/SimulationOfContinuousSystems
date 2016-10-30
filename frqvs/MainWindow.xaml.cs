using Microsoft.Win32;
using System.IO;
using System.Windows;

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
            OpenFileDialog myDialog = new OpenFileDialog();
            myDialog.Filter = "Таблица(*.csv)|*.csv;";
            myDialog.CheckFileExists = true;
            if (myDialog.ShowDialog() == true)
            {
                StreamReader reader = new StreamReader(myDialog.FileName);
                string text = reader.ReadLine();
                Data.ReadFileLine(text);
                reader.Close();
            }

        }

        private void ID_F_Click(object sender, RoutedEventArgs e)
        {
            IDD_F F = new IDD_F();
            F.ShowDialog();
        }
        
        private void ID_IO_Click(object sender, RoutedEventArgs e)
        {
            IDD_IO IO = new IDD_IO();
            IO.ShowDialog();
        }

        private void ID_INTERNET_Click(object sender, RoutedEventArgs e)
        {
            if (Data.Browser == null)
            {
                Data.typeBrowser = TypeBrowser.System;
            }
            ShowBrowserUseTypeBrowserData(Data.typeBrowser);
        }

        private void ID_FILE_SAVE_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog myDialog = new SaveFileDialog();
            myDialog.Filter = "Таблица(*.csv)|*.csv;";
            if (myDialog.ShowDialog() == true)
            {
                string filename = myDialog.FileName;
                StreamWriter file = new StreamWriter(filename);
                file.WriteLine(Data.ConvertToStringForFile());
                file.Close();
            }
        }

        private void ID_SYS_Click(object sender, RoutedEventArgs e)
        {
            Data.typeBrowser = TypeBrowser.System;
        }

        private void ID_PRIV_Click(object sender, RoutedEventArgs e)
        {
            Data.typeBrowser = TypeBrowser.Own;
        }
    }
}
