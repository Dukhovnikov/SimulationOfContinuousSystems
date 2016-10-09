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

        }

        void FileOut(string fileName)
        {
            StreamWriter Out = new StreamWriter(fileName);
            Out.WriteLine(Data.nv + ";" + Data.nr + ";" + Data.nc); 
        }
        void FileIn(string fileName)
        {
            StreamReader file = new StreamReader(fileName);
            string str;
            str = file.ReadLine();
            string[] s = str.Split(';');

            Type curType = typeof(Data);
            FieldInfo[] properties = curType.GetFields(BindingFlags.Static|BindingFlags.Public);
            foreach (FieldInfo property in properties)
            {
                if  (property.FieldType == typeof(int))
                {
                    property.SetValue(Data,)
                }
            }
        }
    }
}
