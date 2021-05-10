using System;

namespace CSharp6Features.Tests.IndexInitializers
{
    public class Matrix
    {
        private const int ROW_DIMENSION = 0;
        private const int COLUMN_DIMENSION = 1;

        private readonly int[,] _matrix = new int[3, 3];

        public int this[int row, int column]
        {
            get
            {
                AssertRowOutOfRange(row);
                AssertColumnOutOfRange(column);

                return _matrix[row, column];
            }
            set
            {
                AssertRowOutOfRange(row);
                AssertColumnOutOfRange(column);

                _matrix[row, column] = value;
            }
        }

        public int[] this[int row]
        {
            get
            {
                AssertRowOutOfRange(row);

                var rowLength = _matrix.GetLength(COLUMN_DIMENSION);
                var result = new int[rowLength];
                for (var i = 0; i < rowLength; i++)
                {
                    result[i] = _matrix[row, i];
                }

                return result;
            }
            set
            {
                AssertRowOutOfRange(row);

                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                var rowLength = _matrix.GetLength(COLUMN_DIMENSION);
                if (value.Length != rowLength)
                {
                    throw new ArgumentException("Value's length does not match matrix row length.", nameof(value));
                }

                for (var i = 0; i < rowLength; i++)
                {
                    _matrix[row, i] = value[i];
                }
            }
        }

        private void AssertRowOutOfRange(int row)
        {
            if (row < 0 || row > _matrix.GetUpperBound(ROW_DIMENSION))
            {
                throw new ArgumentOutOfRangeException(nameof(row));
            }
        }

        private void AssertColumnOutOfRange(int column)
        {
            if (column < 0 || column > _matrix.GetUpperBound(COLUMN_DIMENSION))
            {
                throw new ArgumentOutOfRangeException(nameof(column));
            }
        }
    }
}
