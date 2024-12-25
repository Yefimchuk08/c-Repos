using System;
using System.Linq;

class Program
{
    static void Main()
    {
        // Task 1
        int[] A = new int[5];
        double[,] B = new double[3, 4];
        Console.WriteLine("Enter 5 numbers for array A:");
        for (int i = 0; i < 5; i++) A[i] = int.Parse(Console.ReadLine());
        Random rnd = new Random();
        for (int i = 0; i < 3; i++) for (int j = 0; j < 4; j++) B[i, j] = rnd.NextDouble() * 100;

        Console.WriteLine("Array A: " + string.Join(" ", A));
        Console.WriteLine("Array B:");
        for (int i = 0; i < 3; i++) Console.WriteLine(string.Join(" ", Enumerable.Range(0, 4).Select(j => B[i, j].ToString("F2"))));

        var allElements = A.Select(x => (double)x).Concat(B.Cast<double>());
        double max = allElements.Max(), min = allElements.Min();
        double sum = allElements.Sum(), product = allElements.Aggregate(1.0, (acc, x) => acc * x);
        int evenSumA = A.Where(x => x % 2 == 0).Sum();
        double oddColSumB = Enumerable.Range(0, 4).Where(c => c % 2 != 0).Sum(c => Enumerable.Range(0, 3).Sum(r => B[r, c]));

        Console.WriteLine($"Max: {max}, Min: {min}, Sum: {sum}, Product: {product}, EvenSumA: {evenSumA}, OddColSumB: {oddColSumB}");

        // Task 2
        int[,] C = new int[5, 5];
        for (int i = 0; i < 5; i++) for (int j = 0; j < 5; j++) C[i, j] = rnd.Next(-100, 101);
        var flatC = C.Cast<int>().ToList();
        int maxC = flatC.Max(), minC = flatC.Min();
        int minIndex = flatC.IndexOf(minC), maxIndex = flatC.IndexOf(maxC);
        if (minIndex > maxIndex) (minIndex, maxIndex) = (maxIndex, minIndex);
        int betweenSum = flatC.Skip(minIndex + 1).Take(maxIndex - minIndex - 1).Sum();
        Console.WriteLine($"Sum between min and max: {betweenSum}");

        // Task 3
        Console.WriteLine("Enter a string to encrypt:");
        string input = Console.ReadLine();
        int shift = 3;
        string Encrypt(string text, int s) => new string(text.Select(ch => char.IsLetter(ch) ? (char)(ch + (char.IsLower(ch) ? s : -s)) : ch).ToArray());
        string encrypted = Encrypt(input, shift);
        string decrypted = Encrypt(encrypted, -shift);
        Console.WriteLine($"Encrypted: {encrypted}");
        Console.WriteLine($"Decrypted: {decrypted}");

        // Task 4
        int[,] matrix1 = { { 1, 2 }, { 3, 4 } };
        int[,] matrix2 = { { 5, 6 }, { 7, 8 } };
        int number = 2;
        var multiplied = MultiplyMatrixByNumber(matrix1, number);
        var added = AddMatrices(matrix1, matrix2);
        var multipliedMatrices = MultiplyMatrices(matrix1, matrix2);

        Console.WriteLine("Matrix multiplied by number:");
        PrintMatrix(multiplied);
        Console.WriteLine("Sum of matrices:");
        PrintMatrix(added);
        Console.WriteLine("Product of matrices:");
        PrintMatrix(multipliedMatrices);

        // Task 5
        Console.WriteLine("Enter an arithmetic expression (+, -):");
        string expression = Console.ReadLine();
        int result = expression.Split(new[] { '+', '-' })
                               .Select(int.Parse)
                               .Aggregate((x, y) => expression.Contains('-') ? x - y : x + y);
        Console.WriteLine($"Result: {result}");
    }

    static int[,] MultiplyMatrixByNumber(int[,] matrix, int number)
    {
        int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
        int[,] result = new int[rows, cols];
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                result[i, j] = matrix[i, j] * number;
        return result;
    }

    static int[,] AddMatrices(int[,] matrix1, int[,] matrix2)
    {
        int rows = matrix1.GetLength(0), cols = matrix1.GetLength(1);
        int[,] result = new int[rows, cols];
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                result[i, j] = matrix1[i, j] + matrix2[i, j];
        return result;
    }

    static int[,] MultiplyMatrices(int[,] matrix1, int[,] matrix2)
    {
        int rows1 = matrix1.GetLength(0), cols1 = matrix1.GetLength(1);
        int rows2 = matrix2.GetLength(0), cols2 = matrix2.GetLength(1);
        int[,] result = new int[rows1, cols2];
        for (int i = 0; i < rows1; i++)
            for (int j = 0; j < cols2; j++)
                for (int k = 0; k < cols1; k++)
                    result[i, j] += matrix1[i, k] * matrix2[k, j];
        return result;
    }

    static void PrintMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
                Console.Write(matrix[i, j] + " ");
            Console.WriteLine();
        }
    }
}
