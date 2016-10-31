using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

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
                    //Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe");
                    Process.Start(@"C:\Program Files\Internet Explorer\iexplore.exe");
                    break;
                case TypeBrowser.Own:
                    IDC_WebBrowser WebBrowser = new IDC_WebBrowser();
                    Data.Browser = WebBrowser;
                    Data.Browser.ShowDialog();
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
