using System;
using System.Collections;

namespace SCS.Core.Last.Core
{
    /// <summary>
    /// Вид кодирования.
    /// </summary>
    public enum Coding
    {
        /// <summary>
        /// Целочисленное.
        /// </summary>
        Integer,
        /// <summary>
        /// Вещественное.
        /// </summary>
        Real
    }


    public class Vectors : IComparable<Vectors>
    {
        /// <summary>
        /// Реализация интерфейса IComparable, для сортировки векторов.
        /// </summary>
        public int CompareTo(Vectors other)
        {
            if (Function == null) throw new ArgumentException("Не зада исследуемая функция.");
            return FitnessFunction.CompareTo(other.FitnessFunction);
        }

        // Реализуем интерфейс IComparable<T>
        //public int CompareTo(Vectors other)
        //{
        //    if (this.FitnessFunction > other.FitnessFunction)
        //        return 1;
        //    if (this.FitnessFunction < other.FitnessFunction)
        //        return -1;
        //    else
        //        return 0;
        //}

        /// <summary>
        /// Итератор, выполняющий перебор элементов популяции.
        /// </summary>
        public IEnumerator GetEnumerator()
        {
            for (var i = 0; i < Size; i++)
            {
                yield return (this[i]);
            }
        }

        /// <summary>
        /// Исследуемая функция в виде лямбда выражения.
        /// </summary>
        public static Delegate Function { get; set; }

        /// <summary>
        /// Приспособленность особи / Значение функции в точке.
        /// </summary>
        public double FitnessFunction
        {
            get
            {
                switch (CodingType)
                {
                    case Coding.Integer:
                        Vectors rezult = new Vectors(StartPoint.Size);

                        for (int i = 0; i < StartPoint.Size; i++)
                        {
                            rezult[i] = this[i] * (EndPoint[i] - StartPoint[i]) / (Math.Pow(2, BitsCount) - 1) + StartPoint[i];
                        }

                        return (double)Function.DynamicInvoke(rezult.Vector);

                    case Coding.Real:
                        return (double)Function.DynamicInvoke(Vector);
                    default:
                        throw new IndexOutOfRangeException("Не задан тип кодирования для особи.");
                }
            }
        }

        /// <summary>
        /// Начальная точка.
        /// </summary>
        public static Vectors StartPoint { get; set; }

        /// <summary>
        /// Конечная точка.
        /// </summary>
        public static Vectors EndPoint { get; set; }

        /// <summary>
        /// Количество разрядов для целочисленной кодировки.
        /// </summary>
        public static byte BitsCount { get; set; }

        /// <summary>
        /// Тип кодирования.
        /// </summary>
        public static Coding CodingType { get; set; } = Coding.Real;


        /// <summary>
        /// Вектор.
        /// </summary>
        public double[] Vector { get; }


        /// <summary>
        /// Пустой вектор, размерностью i.
        /// </summary>
        public Vectors(int i)
        {
            Vector = new double[i];
            for (var j = 0; j < i; j++) Vector[j] = 0;
        }


        /// <summary>
        /// Заполнение вектора путем передачи массива.
        /// </summary>
        public Vectors(params double[] vector)
        {
            this.Vector = new double[vector.Length];
            this.Vector = vector;
        }

        /// <summary>
        /// Коснтруктор, инициализирущий вектор посредством другого вектора.
        /// </summary>
        public Vectors(Vectors vector)
        {
            this.Vector = new double[vector.Size];
            for (var i = 0; i < vector.Size; i++)
            {
                this.Vector[i] = vector[i];
            }
        }

        /// <summary>
        /// Коснтруктор, инициализирущий вектор посредством массива строк.
        /// </summary>
        public Vectors(string[] vector)
        {
            this.Vector = new double[vector.Length];
            for (var i = 0; i < vector.Length; i++)
            {
                this.Vector[i] = Convert.ToDouble(vector[i]);
            }
        }

        /// <summary>
        /// Коснтруктор, инициализирущий вектор посредством строки, где каждая точка разделена пробелом.
        /// </summary>
        public Vectors(string textVector)
        {
            if (textVector.Contains(".")) textVector = textVector.Replace(".", ",");
            var newVector = textVector.Split(' ');
            Vector = new double[newVector.Length];
            for (var i = 0; i < newVector.Length; i++) { Vector[i] = Convert.ToDouble(newVector[i]); }
        }

        /// <summary>
        /// Операция разности векоторв.
        /// </summary>
        public static Vectors operator -(Vectors v1, Vectors v2) 
        {
            var v3 = new Vectors(v1.Size);
            for (var i = 0; i < v1.Size; i++) v3[i] = v1[i] - v2[i];
            return v3;
        }


        /// <summary>
        /// Инвертируем значения полей вектора.
        /// </summary>
        public static Vectors operator -(Vectors v1) 
        {
            for (var i = 0; i < v1.Size; i++) v1[i] *= -1;
            return v1;
        }


        /// <summary>
        /// Операция сложения векторов.
        /// </summary>
        public static Vectors operator +(Vectors v1, Vectors v2) 
        {
            var v3 = new Vectors(v1.Size);
            for (var i = 0; i < v1.Size; i++) v3.Vector[i] = v1.Vector[i] + v2.Vector[i];
            return v3;
        }

        /// <summary>
        /// Сложение числа с вектором.
        /// </summary>
        public static Vectors operator +(double C, Vectors v1)
        {
            var v3 = new Vectors(v1.Size);
            for (var i = 0; i < v1.Size; i++) v3.Vector[i] = C + v1.Vector[i];
            return v3;
        }


        /// <summary>
        /// Операция умножения числа на вектор.
        /// </summary>
        public static Vectors operator *(double C, Vectors v1)
        {
            var v3 = new Vectors(v1.Size);
            for (var i = 0; i < v1.Size; i++) v3.Vector[i] = C * v1.Vector[i];
            return v3; 
        }


        /// <summary>
        /// Операция умножения вектора на вектор.
        /// </summary>
        public static double operator *(Vectors v1, Vectors v2)
        {
            double v3 = 0;
            for (var i = 0; i < v1.Size; i++) v3 += v1[i] * v2[i];
            return v3;
        }

        public static Vectors operator /(Vectors v1, double C)
        {
            var v3 = new Vectors(v1.Size);
            for (var i = 0; i < v3.Size; i++) v3[i] = v1[i] / C;
            return v3;
        }

        /// <summary>
        /// Умножение вектора на транспонированный вектор.
        /// </summary>
        public static Matrix Multiplication(Vectors v1, Vectors v2)
        {
            Matrix M = new Matrix(v1.Size);
            if (v1.Size != v2.Size) throw new ArgumentException("Число столбцов матрицы А не равно числу строк матрицы В.");
            for (var i = 0; i < M.Size; i++)
                for (var j = 0; j < M.Size; j++)
                    M[i, j] = v1[i] * v2[j];
            return M;
        }

        /// <summary>
        /// Строковое представление вектора.
        /// </summary>
        public override string ToString()
        {
            var vector = "";
            for (var i = 0; i < Size - 1; i++) vector += this[i] + " : ";
            vector += this[Size - 1];
            return vector;
        }

        /// <summary>
        /// Вычисление истинного значения вектора при целочисленном кодировании.
        /// </summary>
        public Vectors ToReal()
        {
            var realVector = new Vectors(Size);
            for (var i = 0; i < Size; i++)
            {
                realVector[i] = this[i] * (EndPoint[i] - StartPoint[i]) / (Math.Pow(2, BitsCount) - 1) + StartPoint[i];
            }
            return realVector;
        }

        /// <summary>
        ///Норма вектора.
        /// </summary>
        public double Norma
        {
            get
            {
                double sum = 0;
                for (var i = 0; i < Size; i++) sum += Math.Pow(this[i], 2);
                return Math.Sqrt(sum);
            }
        }
        /// <summary>
        /// Значение ячейки вектора.
        /// </summary>
        public double this[int index]
        {
            get => Vector[index];
            set => Vector[index] = value;
        }
        /// <summary>
        /// Длина вектора.
        /// </summary>
        public int Size => Vector.Length;
    }
}
