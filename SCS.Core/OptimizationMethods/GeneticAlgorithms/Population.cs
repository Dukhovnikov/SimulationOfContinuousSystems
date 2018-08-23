using System;
using System.Collections.Generic;
using System.Linq;

namespace SCS.Core.OptimizationMethods.GeneticAlgorithms
{
    public class Population
    {
        /// <summary>
        /// Класс реализующий популяцию, как набор особей.
        /// </summary>
        private Vector[] PopulationData { get; set; }
        
        /// <summary>
        /// Получает число особей, содержащихся в популяции.
        /// </summary>
        public int Count => PopulationData.Length;
        
        /// <summary>
        /// Возвращает особь с минимальным значением.
        /// </summary>
        public Vector Min => PopulationData.Min();
        /// <summary>
        /// Возвращает особь с максимальным значением.
        /// </summary>
        public Vector Max => PopulationData.Max();

        /// <summary>
        /// Сортирует заданную популяцию в порядке ворастания.
        /// </summary>
        public void Sort() => Array.Sort(PopulationData);
    }
}