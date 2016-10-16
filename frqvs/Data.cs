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
        public static int nv = 0;
        /// <summary>
        /// Резисторы.
        /// </summary>
        public static int nr = 0;
        /// <summary>
        /// Конедсаторы.
        /// </summary>
        public static int nc = 0;
        /// <summary>
        /// Индуктивности.
        /// </summary>
        public static int nl = 0;
        /// <summary>
        /// ИТУН.
        /// </summary>
        public static int nju = 0;
        /// <summary>
        /// ИНУН.
        /// </summary>
        public static int neu = 0;
        /// <summary>
        /// ИТУТ.
        /// </summary>
        public static int nji = 0;
        /// <summary>
        /// ИНУТ.
        /// </summary>
        public static int nei = 0;
        /// <summary>
        /// Б/п транзиторы.
        /// </summary>
        public static int ntb = 0;
        /// <summary>
        /// У/п транзиторы.
        /// </summary>
        public static int ntu = 0;
        /// <summary>
        /// Опер. усилители.
        /// </summary>
        public static int nou = 0;
        /// <summary>
        /// Трансформаторы.
        /// </summary>
        public static int ntr = 0;
        /// <summary>
        /// Ид. опер. усилители.
        /// </summary>
        public static int noui = 0;
        /// <summary>
        /// Ид. трансформаторы.
        /// </summary>
        public static int ntri = 0;
        /// <summary>
        /// Массив данных для узлов заданного резистора.
        /// </summary>
        public static int[,] in_r;
        /// <summary>
        /// Узел Массив сопротивления резистора.
        /// </summary>
        public static float[] z_r;

        #endregion

        static public string ConvertToStringForFile()
        {
            string s = nv.ToString()+ ";" + nr.ToString() + ";" + nc.ToString() + ";" + nl.ToString() + ";" + nju.ToString() + ";" + neu.ToString() + ";" + nji.ToString() + ";" + nei.ToString() + ";" + ntb.ToString() + ";" + ntu.ToString() + ";" + nou.ToString() + ";" + ntr.ToString() + ";" + noui.ToString() + ";" + ntri.ToString();
            return s;
        }

        static public void ReadFileLine(string line)
        {
            string[] s = line.Split(';');
            nv = int.Parse(s[0]);
            nr = int.Parse(s[1]);
            nc = int.Parse(s[2]);
            nl = int.Parse(s[3]);
            nju = int.Parse(s[4]);
            neu = int.Parse(s[5]);
            nji = int.Parse(s[6]);
            nei = int.Parse(s[7]);
            ntb = int.Parse(s[8]);
            ntu = int.Parse(s[9]);
            nou = int.Parse(s[10]);
            ntr = int.Parse(s[11]);
            noui = int.Parse(s[12]);
            ntri = int.Parse(s[13]);
        }
    }
}
