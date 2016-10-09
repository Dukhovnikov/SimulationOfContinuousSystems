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
    /// Логика взаимодействия для IDD_R.xaml
    /// </summary>
    public partial class IDD_R : Window
    {
        #region Добавленные функции
        /// <summary>
        /// Отчистка всех полей формы.
        /// </summary>
        void ClearScr()
        {
            IDC_NMR.Text = "0";
            IDC_NPR.Text = "0";
            IDC_ZR.Text = "0";
        }
        /// <summary>
        /// Возвращает значение идентификатора резистора.
        /// </summary>
        /// <returns></returns>
        int GetIDC_NextNumber()
        {
            return int.Parse(IDC_NEXTR.Text);
        }
        #endregion
        public IDD_R()
        {
            InitializeComponent();
        }

        private void IDC_NEXT_BUTTON_Click(object sender, RoutedEventArgs e)
        {
            Data.in_r[GetIDC_NextNumber() - 1, 0] = int.Parse(IDC_NPR.Text);
            Data.in_r[GetIDC_NextNumber() - 1, 1] = int.Parse(IDC_NMR.Text);
            Data.z_r[GetIDC_NextNumber() - 1] = float.Parse(IDC_ZR.Text);
            IDC_NEXTR.Text = (GetIDC_NextNumber() + 1).ToString();
            if (GetIDC_NextNumber() <= Data.nr)
            {
                ClearScr();
                IDC_NPR.Focus();
            }
            else
            {
                Close();
            }
        }
    }
}
