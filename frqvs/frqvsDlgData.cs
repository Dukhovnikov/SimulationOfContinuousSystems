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

        void ShowBrowserUseTypeBrowserData( TypeBrowser type)
        {
            switch (type)
            {
                case TypeBrowser.System:
                    IDC_WebBrowser WebBrowser = new IDC_WebBrowser();
                    Data.Browser = WebBrowser;
                    break;
                case TypeBrowser.Own:
                    IDD_INT INT = new IDD_INT();
                    Data.Browser = INT;
                    break;
                default:
                    break;
            }
            Data.Browser.ShowDialog();
        }
        #endregion
    }
}
