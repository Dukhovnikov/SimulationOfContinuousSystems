using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frqvs
{
    public partial class frqvsDlg
    {
        #region Функции
        /// <summary>
        /// Если нужно, выполняет открытие формы для ввода резисторов.
        /// </summary>
        void ShowIddR(int NR)
        {
            if (NR>0)
            {
                IDD_R form = new IDD_R();
                form.ShowDialog();
            }
        }
        #endregion
    }
}
