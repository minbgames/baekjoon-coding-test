using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        int[,] map = new int[size, size];

        for (int i = 0; i < size; i++)
        {
            string line = Console.ReadLine();
            for (int j = 0; j < size; j++)
            {
                map[i, j] = line[j] - '0';
            }
        }

        List<int> complexSizes = FindComplexes(map, size);

        Console.WriteLine(complexSizes.Count);
        complexSizes.Sort();
        foreach (int sizeOfComplex in complexSizes)
        {
            Console.WriteLine(sizeOfComplex);
        }
    }

    static List<int> FindComplexes(int[,] map, int size)
    {
        List<int> complexSizes = new List<int>();
        bool[,] visited = new bool[size, size];
        int[] dx = { -1, 1, 0, 0 }; // 상, 하, 좌, 우
        int[] dy = { 0, 0, -1, 1 };

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (map[i, j] == 1 && !visited[i, j])
                {
                    int complexSize = DFS(map, visited, i, j, size, dx, dy);
                    complexSizes.Add(complexSize);
                }
            }
        }

        return complexSizes;
    }

    static int DFS(int[,] map, bool[,] visited, int x, int y, int size, int[] dx, int[] dy)
    {
        Stack<(int, int)> stack = new Stack<(int, int)>();
        stack.Push((x, y));
        visited[x, y] = true;
        int houseCount = 0;

        while (stack.Count > 0)
        {
            var (currentX, currentY) = stack.Pop();
            houseCount++;

            for (int i = 0; i < 4; i++)
            {
                int nx = currentX + dx[i];
                int ny = currentY + dy[i];

                if (nx >= 0 && nx < size && ny >= 0 && ny < size && map[nx, ny] == 1 && !visited[nx, ny])
                {
                    visited[nx, ny] = true;
                    stack.Push((nx, ny));
                }
            }
        }

        return houseCount;
    }
}