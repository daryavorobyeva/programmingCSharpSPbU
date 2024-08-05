namespace MatrixMultiplication;

/// <summary>
/// The class represents a rectangular matrix with integers.
/// </summary>
public class Matrix
{
    private readonly int[,] matrix;

    public int GetRowCount => matrix.GetLength(0);
    public int GetColumnCount => matrix.GetLength(1);
    
    public Matrix(int[,] array)
    {
        matrix = (int[,])array.Clone();
    }

    public int this[int row, int colomn]
    {
        get { return matrix[row, colomn]; }
    }
}
