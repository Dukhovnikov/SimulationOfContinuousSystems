using System;
using SCS.Core.OptimizationMethods;

namespace SCS.Core
{
    public class Matrix
    {
        /// <summary>
        /// Двумерный массив.
        /// </summary>
        private readonly double[,] _matrix;


        /// <summary>
        /// Задает пустую матрицу размером N.
        /// </summary>
        public Matrix(int n)
        {
            _matrix = new double[n, n];
        }


        /// <summary>
        /// Задает матрицу с помощью двумерного массива.
        /// </summary>
        public Matrix(double[,] matrix)
        {
            this._matrix = matrix;
        }


        /// <summary>
        /// Получение значение ячейки матрицы.
        /// </summary>
        public double this[int row, int column]
        {
            get => _matrix[row, column];
            set => _matrix[row, column] = value;
        }


        /// <summary>
        /// Сложение матриц.
        /// </summary>
        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            var m3 = new Matrix(m1.Size);
            
            for (var i = 0; i < m3.Size; i++)
                for (var j = 0; j < m3.Size; j++)
                    m3[i, j] = m1[i, j] + m2[i, j];
            return m3;
        }


        /// <summary>
        /// Разность матриц.
        /// </summary>
        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            var m3 = new Matrix(m1.Size);
            
            for (var i = 0; i < m3.Size; i++)
                for (var j = 0; j < m3.Size; j++)
                    m3[i, j] = m1[i, j] - m2[i, j];
            return m3;
        }


        /// <summary>
        /// Умножение матрицы на число.
        /// </summary>
        public static Matrix operator *(double c, Matrix m1)
        {
            var m3 = new Matrix(m1.Size);
            
            for (var i = 0; i < m3.Size; i++)
                for (var j = 0; j < m3.Size; j++)
                    m3[i, j] = c * m1[i, j];
            return m3;
        }


        /// <summary>
        /// Умножение матрицы на вектор.
        /// </summary>
        public static Vector operator *(Matrix m, Vector v)
        {
            if (m.Size != v.Size)
                throw new ArgumentException("Число столбцов матрицы А не равно числу элементов вектора В.");
            
            var vector = new Vector(v.Size);
            
            for (var i = 0; i < vector.Size; i++)
                for (var j = 0; j < vector.Size; j++)
                    vector[i] += m[i, j] * v[j];
            return vector;
        }

        /// <summary>
        /// Умножение матриц.
        /// </summary>
        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            var matrix = new Matrix(m1.Size);
            
            for (var i = 0; i < matrix.Size; i++)
                for (var j = 0; j < matrix.Size; j++)
                    for (var k = 0; k < matrix.Size; k++)
                        matrix[i, j] += m1[i, k] * m2[k, j];
            return matrix;
        }

        /// <summary>
        /// Деление матрицы на константу.
        /// </summary>
        public static Matrix operator /(Matrix m, double c)
        {
            var matrix = new Matrix(m.Size);
            
            for (var i = 0; i < m.Size; i++)
                for (var j = 0; j < m.Size; j++)
                    matrix[i, j] = m[i, j] / c;
            return matrix;
        }

        /// <summary>
        /// Возвращает матрицу без указанных строки и столбца. Исходная матрица не изменяется.
        /// </summary>
        private Matrix Exclude(int row, int column)
        {
            if (row > Size || column > Size)
                throw new IndexOutOfRangeException("Строка или столбец не принадлежат матрице.");
            
            var m1 = new Matrix(Size - 1);
            var x = 0;
            
            for (var i = 0; i < Size; i++)
            {
                var y = 0;
                if (i == row) { x++; continue; }
                for ( var j = 0; j < Size; j++)
                {
                    if (j == column) { y++; continue; }
                    m1[i - x, j - y] = this[i, j];
                }
            }
            return m1;
        }

        /// <summary>
        /// Единичная матрица размером NxN.
        /// </summary>
        public static Matrix E(int n)
        {
            var matrix = new Matrix(n);
            for (var i = 0; i < n; i++)
                for (var j = 0; j < n; j++)
                    matrix[i, j] = 1;
            return matrix;
        }

        /// <summary>
        /// Детерминант матрицы.
        /// </summary>
/*        public double Determinant
        {
            get
            {
                var m1 = this;
                
                if (m1.Size == 1) return m1[0, 0];
                if (m1.Size == 2) return m1[0, 0] * m1[1, 1] - m1[0, 1] * m1[1, 0];
                if (m1.Size == 3) return m1[0, 0] * m1[1, 1] * m1[2, 2] + m1[0, 1] * m1[1, 2] * m1[2, 0] + m1[0, 2] * m1[1, 0] * m1[2, 1] - m1[0, 2] * m1[1, 1] * m1[2, 0] - m1[0, 0] * m1[1, 2] * m1[2, 1] - m1[0, 1] * m1[1, 0] * m1[2, 2];
                
                double det = 0;
                
                for (var i = 0; i < m1.Size; i++)
                {
                    det += Math.Pow(-1, i) * m1[0, i] * m1.Exclude(0, i).Determinant;
                }
                
                return det;
            }
        }*/


        /// <summary>
        /// Определитель матрицы.
        /// </summary>
        public static double Determinant(Matrix m1)
        {
            if (m1.Size == 1) return m1[0, 0];
            if (m1.Size == 2) return m1[0, 0] * m1[1, 1] - m1[0, 1] * m1[1, 0];
            if (m1.Size == 3)
                return m1[0, 0] * m1[1, 1] * m1[2, 2] + m1[0, 1] * m1[1, 2] * m1[2, 0] +
                       m1[0, 2] * m1[1, 0] * m1[2, 1] - m1[0, 2] * m1[1, 1] * m1[2, 0] -
                       m1[0, 0] * m1[1, 2] * m1[2, 1] - m1[0, 1] * m1[1, 0] * m1[2, 2];
            
            double det = 0;
            for (var i = 0; i < m1.Size; i++)
            {
                det += Math.Pow(-1, i) * m1[0, i] * Determinant(m1.Exclude(0, i));
            }
            
            return det;
        }


        /// <summary>
        /// Обратная матрица. Обратная матрица существует только для квадратных, невырожденных, матриц.
        /// </summary>
/*        public Matrix Inverse
        {
            get
            {
                Matrix matrix = new Matrix(Size);
                double determinant = Determinant;
                if (determinant == 0) return matrix; /// Если определитель == 0 - матрица вырожденная
                for (int i = 0; i < Size; i++)
                {
                    for (int j = 0; j < Size; j++)
                    {
                        Matrix tmp = Exclude(i, j);
                        matrix[j, i] = (Math.Pow(-1, i + 1 + j + 1) / Determinant()) * tmp.Determinant;
                    }
                }
                return matrix;
            }
        }*/


        /// <summary>
        /// Обратная матрица. Обратная матрица существует только для квадратных, невырожденных, матриц.
        /// </summary>
        public static Matrix Inverse(Matrix m, int round = 0)
        {
            var matrix = new Matrix(m.Size);
            var determinant = Matrix.Determinant(m);

            if (determinant == 0) return matrix; //Если определитель == 0 - матрица вырожденная

            for (var i = 0; i < m.Size; i++)
            {
                for (var j = 0; j < m.Size; j++)
                {
                    var tmp = m.Exclude(i, j);

                    matrix[j, i] = round == 0
                        ? (Math.Pow(-1, i + 1 + j + 1) / determinant) * Matrix.Determinant(tmp)
                        : Math.Round(((1 / determinant) * Matrix.Determinant(tmp)), round, MidpointRounding.ToEven);
                }
            }
            return matrix;
        }


        /// <summary>
        /// Транспонирование матицы.
        /// </summary>
        //public Matrix Transpose
        //{
        //    get
        //    {
        //        Matrix matrix = new Matrix(Size);
        //        for (int i = 0; i < Size; i++)
        //            for (int j = 0; j < Size; j++)
        //                matrix[j, i] = this[i, j];
        //        return matrix;
        //    }
        //}


        /// <summary>
        /// Транспонирование матицы.
        /// </summary>
        public static Matrix Transpose(Matrix matrix)
        {
            var transposeMatrix = new Matrix(matrix.Size);

            for (var i = 0; i < matrix.Size; i++)
                for (var j = 0; j < matrix.Size; j++)
                    matrix[j, i] = matrix[i, j];

            return transposeMatrix;
        }

        /// <summary>
        /// Размерность матрицы.
        /// </summary>
        public int Size => _matrix.GetLength(0);
    }
}
