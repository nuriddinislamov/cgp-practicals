using System;
public class Program
{
    public static void Main()
    {
        try
        {
            int[,] tempA = { { 2, 1, 3 }, { 1, 3, 2 } };
            int[,] tempB = { { 35, 30 }, { 50, 40 }, { 70, 75 } };
            Matrix2D a = new Matrix2D(tempA);
            Matrix2D b = new Matrix2D(tempB);

            Console.WriteLine("Matrix A:");
            Console.WriteLine(a.OutputMatrix());

            Console.WriteLine("Matrix B:");
            Console.WriteLine(b.OutputMatrix());

            Matrix2D result = Matrix2D.Multiply(a, b);
            Console.WriteLine("A x B =");
            Console.WriteLine(result.OutputMatrix());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}


public class Matrix2D
{
    private int[,] matrix;

    public Matrix2D(int[,] toSet)
    {
        matrix = new int[toSet.GetLength(0), toSet.GetLength(1)];
        for (int i = 0; i < toSet.GetLength(0); i++)
        {
            for (int j = 0; j < toSet.GetLength(1); j++)
            {
                matrix[i, j] = toSet[i, j];
            }
        }
    }

    public int NumberOfColumns()
    {
        return matrix.GetLength(1);
    }

    public int NumberOfRows()
    {
        return matrix.GetLength(0);
    }

    public string OutputMatrix()
    {
        string toOut = "";
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                toOut += matrix[i, j].ToString();
                if (j < matrix.GetLength(1) - 1)
                    toOut += ", ";
            }
            toOut += "\n";
        }
        return toOut;
    }

    public static Matrix2D Multiply(Matrix2D matrixA, Matrix2D matrixB)
    {
        if (matrixA.NumberOfColumns() != matrixB.NumberOfRows())
        {
            throw new InvalidOperationException("The matrices cannot be multiplied due to incompatible dimensions.");
        }

        int[,] result = new int[matrixA.NumberOfRows(), matrixB.NumberOfColumns()];

        for (int i = 0; i < result.GetLength(0); i++)
        {
            for (int j = 0; j < result.GetLength(1); j++)
            {
                for (int k = 0; k < matrixA.NumberOfColumns(); k++)
                {
                    result[i, j] += matrixA.matrix[i, k] * matrixB.matrix[k, j];
                }
            }
        }

        return new Matrix2D(result);
    }
}
