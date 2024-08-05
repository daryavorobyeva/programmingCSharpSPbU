namespace MatrixMultiplication;

/// <summary>
/// Functions related to matrix multiplication.
/// </summary>
public static class MultiplicationOfTwoMatrices
{
    /// <summary>
    /// Standard matrix multiplication.
    /// </summary>
    /// <param name="firstMatrix"></param>
    /// <param name="secondMatrix"></param>
    /// <returns> The matrix obtained as a result of multiplication. </returns>
    /// <exception cref="ArgumentException"></exception>
    public static Matrix Multiplication(Matrix firstMatrix, Matrix secondMatrix)
    {
        if (!IsMultiplied(firstMatrix, secondMatrix))
        {
            throw new ArgumentException("The dimensions of the matrices do not allow to multiply them.");
        }

        int[,] resultArray = new int[firstMatrix.GetRowCount,secondMatrix.GetColumnCount];
        for (int i = 0; i < firstMatrix.GetRowCount; i++)
        {
            for (int j = 0; j < secondMatrix.GetColumnCount; j++)
            {
                resultArray[i, j] = Enumerable
                    .Range(0, firstMatrix.GetColumnCount)
                    .Sum(k => firstMatrix[i, k] * secondMatrix[k, j]);
            }
        }
        return new Matrix(resultArray);
    }

    /// <summary>
    /// Multiplication of two matrices using parallel computation.
    /// </summary>
    /// <param name="firstMatrix"></param>
    /// <param name="secondMatrix"></param>
    /// <returns> The matrix obtained as a result of multiplication. </returns>
    /// <exception cref="ArgumentException"></exception>
    public static Matrix ParallelMultiplication(Matrix firstMatrix, Matrix secondMatrix)
    {
        if (!IsMultiplied(firstMatrix, secondMatrix))
        {
            throw new ArgumentException("The dimensions of the matrices do not allow to multiply them.");
        }

        int[,] resultArray = new int[firstMatrix.GetRowCount, secondMatrix.GetColumnCount];
        var threadsCount = Math.Min(firstMatrix.GetRowCount, Environment.ProcessorCount);
        var threads = new Thread[threadsCount];
        var rowsPerThread = firstMatrix.GetRowCount / threadsCount + 1;

        for (int i = 0; i < threadsCount; i++)
        {
            var currentThreadNumber = i;
            threads[currentThreadNumber] = new Thread(() =>
            {
                for (var row = rowsPerThread * currentThreadNumber; 
                row < (currentThreadNumber + 1) * rowsPerThread && row < firstMatrix.GetRowCount;
                row++)
                {
                    for (var column = 0; column < secondMatrix.GetColumnCount; column++)
                    {
                        var rowNumber = row;
                        var columnNumber = column;

                        resultArray[rowNumber, columnNumber] = Enumerable
                        .Range(0, firstMatrix.GetColumnCount)
                        .Sum(k => firstMatrix[rowNumber, k] * secondMatrix[k, columnNumber]);
                    }
                }
            });
        }

        foreach (var thread in threads)
        {
            thread.Start();
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        return new Matrix(resultArray);
    }

    /// <summary>
    /// To multiply matrices the number of columns in the first matrix 
    /// must equal the number of rows in the second.
    /// </summary>
    /// <param name="firstMatrix"></param>
    /// <param name="secondMatrix"></param>
    /// <returns></returns>
    public static bool IsMultiplied(Matrix firstMatrix, Matrix secondMatrix)
    {
        return firstMatrix.GetColumnCount == secondMatrix.GetRowCount;
    }
}
