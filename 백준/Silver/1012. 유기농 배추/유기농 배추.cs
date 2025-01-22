using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int t = int.Parse(Console.ReadLine());
        for (int testCase = 0; testCase < t; testCase++)
        {
            string[] dimensions = Console.ReadLine().Split();
            int m = int.Parse(dimensions[0]);
            int n = int.Parse(dimensions[1]);
            int k = int.Parse(dimensions[2]);

            int[,] field = new int[m, n];
            for (int i = 0; i < k; i++)
            {
                string[] position = Console.ReadLine().Split();
                int x = int.Parse(position[0]);
                int y = int.Parse(position[1]);
                field[x, y] = 1;
            }

            int result = CountWorms(field, m, n);
            Console.WriteLine(result);
        }
    }

    static int CountWorms(int[,] field, int m, int n)
    {
        bool[,] visited = new bool[m, n];
        int wormCount = 0;

        for (int x = 0; x < m; x++)
        {
            for (int y = 0; y < n; y++)
            {
                if (field[x, y] == 1 && !visited[x, y])
                {
                    BFS(field, visited, m, n, x, y);
                    wormCount++;
                }
            }
        }

        return wormCount;
    }

    static void BFS(int[,] field, bool[,] visited, int m, int n, int startX, int startY)
    {
        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };

        Queue<(int, int)> queue = new Queue<(int, int)>();
        queue.Enqueue((startX, startY));
        visited[startX, startY] = true;

        while (queue.Count > 0)
        {
            var (x, y) = queue.Dequeue();

            for (int i = 0; i < 4; i++)
            {
                int nx = x + dx[i];
                int ny = y + dy[i];

                if (nx >= 0 && ny >= 0 && nx < m && ny < n && field[nx, ny] == 1 && !visited[nx, ny])
                {
                    visited[nx, ny] = true;
                    queue.Enqueue((nx, ny));
                }
            }
        }
    }
}