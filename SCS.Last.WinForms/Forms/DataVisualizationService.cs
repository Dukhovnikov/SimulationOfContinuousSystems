using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCS.Last.WinForms.Forms
{
    internal class VisualizationGA
    {
        /// <summary>
        /// Вид кодирования.
        /// </summary>
        public string ViewsCoding { get; set; }
        /// <summary>
        /// Вид скрещивания
        /// </summary>
        public string ViewsСrossing { get; set; }

        public VisualizationGA(string viewsCoding, string viewsСrossing)
        {
            this.ViewsCoding = viewsCoding;
            this.ViewsСrossing = viewsСrossing;
        }
    }

    internal class DataVisualizationService
    {
        /// <summary>
        /// Функция создает Методы и их классификацию.
        /// </summary>
        public static List<VisualizationGA> GetCodingAndCrossingViews()
        {
            return new List<VisualizationGA>
            {
                new VisualizationGA("Вещественное", "Одноточечное скрещивание"),
                new VisualizationGA("Вещественное", "BLXa - скрещивание"),
                new VisualizationGA("Целочисленное", "Одноточечное скрещивание"),
                new VisualizationGA("Целочисленное", "Двухточечное скрещивание"),
                new VisualizationGA("Целочисленное", "Однородное скрещивание"),
            };
        }
    }
}
