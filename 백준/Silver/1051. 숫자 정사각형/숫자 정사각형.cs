class Program
{
    static void Main(string[] args)
    {
        string[] dimensions = Console.ReadLine().Split();
        int n = int.Parse(dimensions[0]);
        int m = int.Parse(dimensions[1]);

        char[,] matrix = new char[n, m];
        for (int i = 0; i < n; i++)
        {
            string row = Console.ReadLine();
            for (int j = 0; j < m; j++)
            {
                matrix[i, j] = row[j];
            }
        }

        int maxSquareSize = FindLargestSquare(n, m, matrix);

        Console.WriteLine(maxSquareSize);
    }

    static int FindLargestSquare(int n, int m, char[,] matrix)
    {
        int maxSize = 1;

        for (int size = 2; size <= Math.Min(n, m); size++)
        {
            for (int i = 0; i <= n - size; i++)
            {
                for (int j = 0; j <= m - size; j++)
                {
                    if (IsSquare(matrix, i, j, size))
                    {
                        maxSize = Math.Max(maxSize, size * size);
                    }
                }
            }
        }

        return maxSize;
    }

    static bool IsSquare(char[,] matrix, int x, int y, int size)
    {
        char value = matrix[x, y];
        return matrix[x, y + size - 1] == value &&
               matrix[x + size - 1, y] == value &&
               matrix[x + size - 1, y + size - 1] == value;
    }
}