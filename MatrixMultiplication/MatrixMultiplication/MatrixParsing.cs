namespace MatrixMultiplication;

public static class MatrixParsing
{
    /// <summary>
    /// Reads from a file and creates a matrix.
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    /// <exception cref="InvalidDataException"></exception>
    public static Matrix ParseFileToMatrix(string filePath)
    {
        ArgumentNullException.ThrowIfNull(filePath);

        var lines = File.ReadAllLines(filePath);
        var resultMatrix = new int[lines.Length, lines[0].Split(' ').Length];

        for (var i = 0; i < lines.Length; ++i)
        {
            if (lines[i] == string.Empty)
            {
                throw new InvalidDataException("Empty line.");
            }

            var line = lines[i].Trim().Split(' ').Select(int.Parse).ToArray();

            if (line.Length != resultMatrix.GetLength(1))
            {
                throw new InvalidDataException("The matrix is not completely filled.");
            }

            for (var j = 0; j < line.Length; ++j)
            {
                resultMatrix[i, j] = line[j];
            }
        }

        return new Matrix(resultMatrix);
    }

    /// <summary>
    /// Writing the resulting matrix to a file.
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="matrix"></param>
    public static void WriteInFile(string filePath, Matrix matrix)
    {
        using StreamWriter writer = new StreamWriter(filePath);

        for (var i = 0; i < matrix.GetRowCount; ++i)
        {
            for (var j = 0; j < matrix.GetColumnCount; ++j)
            {
                writer.Write($"{matrix[i, j]} ");
            }

            writer.Write(Environment.NewLine);
        }
    }
}
