using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frqvs
{
    /// <summary>
    /// Статический класс хранения глобальных данных.
    /// </summary>
    static class Data
    {
        #region Данные
        /// <summary>
        /// Число узлов.
        /// </summary>
        public static int nv;
        /// <summary>
        /// Резисторы.
        /// </summary>
        public static int nr;
        /// <summary>
        /// Конедсаторы.
        /// </summary>
        public static int nc;
        /// <summary>
        /// Индуктивности.
        /// </summary>
        public static int nl;
        /// <summary>
        /// ИТУН.
        /// </summary>
        public static int nju;
        /// <summary>
        /// ИНУН.
        /// </summary>
        public static int neu;
        /// <summary>
        /// ИТУТ.
        /// </summary>
        public static int nji;
        /// <summary>
        /// ИНУТ.
        /// </summary>
        public static int nei;
        /// <summary>
        /// Б/п транзиторы.
        /// </summary>
        public static int ntb;
        /// <summary>
        /// У/п транзиторы.
        /// </summary>
        public static int ntu;
        /// <summary>
        /// Опер. усилители.
        /// </summary>
        public static int nou;
        /// <summary>
        /// Трансформаторы.
        /// </summary>
        public static int ntr;
        /// <summary>
        /// Ид. опер. усилители.
        /// </summary>
        public static int noui;
        /// <summary>
        /// Ид. трансформаторы.
        /// </summary>
        public static int ntri;
        /// <summary>
        /// Массив данных для узлов заданного резистора.
        /// </summary>
        public static int[,] in_r;
        /// <summary>
        /// Узел Массив сопротивления резистора.
        /// </summary>
        public static float[] z_r;

        #endregion

        static public string ConvertToFile()
        {
            string s = nv.ToString()+ ";" + nr.ToString() + ";" + nc.ToString() + ";" + nl.ToString() + ";" + nju.ToString() + ";" + neu.ToString() + ";" + nji.ToString() + ";" + nei.ToString() + ";" + ntb.ToString() + ";" + ntu.ToString() + ";" + nou.ToString() + ";" + ntr.ToString() + ";" + noui.ToString() + ";" + ntri.ToString();
            return s;
        }
    }
}
