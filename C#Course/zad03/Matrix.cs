using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace C_Course.zad03
{
    //3.5
    class Matrix<T> where T : IComparable, IFormattable, IAdditionOperators<T, T, T>, IMultiplyOperators<T, T, T>
    {
        private T[,] _matrix;

        public Matrix(int rows, int columns) { _matrix = new T[rows, columns]; }

        public Matrix(T[,] matrix) { _matrix = matrix; }

        public int GetLength(int dimmension)
        {
            return _matrix.GetLength(dimmension);
        }

        public T[,] GetMatrix() { return _matrix; }

        public T GetVal(int row, int column)
        {
            return _matrix[row, column];
        }

        public Matrix<T> Add(Matrix<T> matrix) { return this + matrix; }

        public Matrix<T> Mult(Matrix<T> matrix) { return this * matrix; }

        public static Matrix<T> operator +(Matrix<T> a, Matrix<T> b)
        {
            if (a.GetLength(0) != b.GetLength(0) || a.GetLength(1) != b.GetLength(1))
                throw new ArithmeticException("Matrixes must have equal number of rows and columns");

            int resultRows = a.GetLength(0);
            int resultColumns = a.GetLength(1);
            T[,] result = new T[resultRows, resultColumns];

            for (int i = 0; i < resultRows; i++)
                for (int j = 0; j < resultColumns; j++)
                    result[i, j] = a.GetVal(i, j) + b.GetVal(i, j);
            return new(result);
        }

        public static Matrix<T> operator *(Matrix<T> a, Matrix<T> b)
        {
            if (a.GetLength(1) != b.GetLength(0))
                throw new ArithmeticException("Number of columns in matrix given by the first argument must be equal to" +
                                                " number of rows in matrix given by the second argument");

            int resultRows = a.GetLength(0);
            int resultColumns = b.GetLength(1);
            T[,] result = new T[resultRows, resultColumns];

            for (int i = 0; i < resultRows; i++)
                for (int j = 0; j < resultColumns; j++)
                    for (int k = 0; k < a.GetLength(1); k++)
                        result[i, j] += a.GetVal(i, k) * b.GetVal(k, j);

            return new(result);
        }

        override public string ToString()
        {
            string result = "";
            for (int i = 0; i < GetLength(0); i++)
            {
                result += "[ ";
                for (int j = 0; j < GetLength(1) - 1; j++)
                {
                    result += GetVal(i, j).ToString() + ", ";
                }
                result += GetVal(i, GetLength(1) - 1).ToString() + " ]\n";
            }
            return result;
        }

        class SquareMatrix<T> : Matrix<T> where T : IComparable, IFormattable, IAdditionOperators<T, T, T>, IMultiplyOperators<T, T, T>
        {
            public SquareMatrix(T[,] matrix) : base(matrix)
            {
                if (matrix.GetLength(0) != matrix.GetLength(1))
                    throw new ArgumentException("Matrix must have equal number of rows and columns");
            }

            public SquareMatrix(int order) : base(order, order) { }

            public bool IsDiagonal()
            {
                for (int i = 0; i < this.GetLength(0); i++)
                {
                    for (int j = 0; j < this.GetLength(1); j++)
                    {
                        if (i != j && !this.GetVal(i, j).Equals(0))
                            return false;
                    }
                }

                return true;
            }
        }

    }
}
