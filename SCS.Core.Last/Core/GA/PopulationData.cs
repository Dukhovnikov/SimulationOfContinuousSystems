using System.Collections.Generic;

namespace SCS.Core.Last.Core.GA
{
    /// <summary>
    /// Класс, который хранит данные о поведении генетического алгоритма.
    /// </summary>
    public class PopulationData
    {
        public List<double> MinValues { get; set; } = new List<double>();
        public List<double> MiddleValues { get; set; } = new List<double>();

    }
}
