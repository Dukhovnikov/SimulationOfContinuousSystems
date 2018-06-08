using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SCS.Core
{
    public class Vector
    {

        /// <summary>
        /// Итератор, выполняющий перебор элементов популяции.
        /// </summary>
        public IEnumerator GetEnumerator()
        {
            for (var i = 0; i < Size; i++)
            {
                yield return this[i];
            }
        }

        /// <summary>
        /// Вектор.
        /// </summary>
        private double[] DataVector { get; }


        /// <summary>
        /// Пустой вектор, размерностью i.
        /// </summary>
        public Vector(int i)
        {
            DataVector = new double[i];
            for (var j = 0; j < i; j++) DataVector[j] = 0;
        }


        /// <summary>
        /// Заполнение вектора путем передачи массива.
        /// </summary>
        public Vector(params double[] dataVector)
        {
            this.DataVector = new double[dataVector.Length];
            this.DataVector = dataVector;
        }

        /// <summary>
        /// Коснтруктор, инициализирущий вектор посредством другого вектора.
        /// </summary>
        public Vector(Vector vector)
        {
            this.DataVector = new double[vector.Size];
            for (var i = 0; i < vector.Size; i++)
            {
                this.DataVector[i] = vector[i];
            }
        }

        /// <summary>
        /// Коснтруктор, инициализирущий вектор посредством массива строк.
        /// </summary>
        public Vector(IReadOnlyList<string> vector)
        {
            this.DataVector = new double[vector.Count];
            for (var i = 0; i < vector.Count; i++)
            {
                this.DataVector[i] = Convert.ToDouble(vector[i]);
            }
        }

        /// <summary>
        /// Коснтруктор, инициализирущий вектор посредством строки, где каждая точка разделена пробелом.
        /// </summary>
        public Vector(string textVector)
        {
            if (textVector.Contains(".")) textVector = textVector.Replace(".", ",");
            
            var newVector = textVector.Split(' ');
            DataVector = new double[newVector.Length];
            
            for (var i = 0; i < newVector.Length; i++) { DataVector[i] = Convert.ToDouble(newVector[i]); }
        }

        /// <summary>
        /// Операция разности векоторв.
        /// </summary>
        public static Vector operator -(Vector v1, Vector v2) 
        {
            var v3 = new Vector(v1.Size);
            
            for (var i = 0; i < v1.Size; i++) v3[i] = v1[i] - v2[i];
            
            return v3;
        }


        /// <summary>
        /// Инвертируем значения полей вектора.
        /// </summary>
        public static Vector operator -(Vector v1) 
        {
            for (var i = 0; i < v1.Size; i++) v1[i] *= -1;
            return v1;
        }


        /// <summary>
        /// Операция сложения векторов.
        /// </summary>
        public static Vector operator +(Vector v1, Vector v2) 
        {
            var v3 = new Vector(v1.Size);
            for (var i = 0; i < v1.Size; i++) v3.DataVector[i] = v1.DataVector[i] + v2.DataVector[i];
            return v3;
        }

        /// <summary>
        /// Сложение числа с вектором.
        /// </summary>
        public static Vector operator +(double c, Vector v1)
        {
            var v3 = new Vector(v1.Size);
            for (var i = 0; i < v1.Size; i++) v3.DataVector[i] = c + v1.DataVector[i];
            return v3;
        }


        /// <summary>
        /// Операция умножения числа на вектор.
        /// </summary>
        public static Vector operator *(double c, Vector v1)
        {
            var v3 = new Vector(v1.Size);
            for (var i = 0; i < v1.Size; i++) v3.DataVector[i] = c * v1.DataVector[i];
            return v3; 
        }


        /// <summary>
        /// Операция умножения вектора на вектор.
        /// </summary>
        public static double operator *(Vector v1, Vector v2)
        {
            double v3 = 0;
            for (var i = 0; i < v1.Size; i++) v3 += v1[i] * v2[i];
            return v3;
        }

        public static Vector operator /(Vector v1, double c)
        {
            var v3 = new Vector(v1.Size);
            for (var i = 0; i < v3.Size; i++) v3[i] = v1[i] / c;
            return v3;
        }

        /// <summary>
        /// Умножение вектора на транспонированный вектор.
        /// </summary>
        public static Matrix Multiplication(Vector v1, Vector v2)
        {
            var m = new Matrix(v1.Size);
            if (v1.Size != v2.Size) throw new ArgumentException("Число столбцов матрицы А не равно числу строк матрицы В.");
            for (var i = 0; i < m.Size; i++)
                for (var j = 0; j < m.Size; j++)
                    m[i, j] = v1[i] * v2[j];
            return m;
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

        
/*        public double Norma()
        {
            var sum = 0.0;
            for (var i = 0; i < Size; i++)
            {
                sum += this[i] * this[i];
            }

            return sum;
        }*/

        /// <summary>
        ///Норма вектора.
        /// </summary>
        public double Norma() => DataVector.Sum(number => number * number);
        
        /// <summary>
        /// Значение ячейки вектора.
        /// </summary>
        public double this[int index]
        {
            get => DataVector[index];
            set => DataVector[index] = value;
        }
        /// <summary>
        /// Длина вектора.
        /// </summary>
        public int Size => DataVector.Length;
    }
}
