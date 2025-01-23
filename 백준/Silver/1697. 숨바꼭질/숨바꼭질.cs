using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();
        int start = int.Parse(input[0]);
        int target = int.Parse(input[1]);

        int result = FindFastestTime(start, target);
        Console.WriteLine(result);
    }

    static int FindFastestTime(int start, int target)
    {
        if (start == target)
            return 0;

        const int MAX = 100000;
        bool[] visited = new bool[MAX + 1];
        Queue<(int position, int time)> queue = new Queue<(int position, int time)>();

        queue.Enqueue((start, 0));
        visited[start] = true;

        while (queue.Count > 0)
        {
            var (current, time) = queue.Dequeue();

            foreach (int next in new int[] { current - 1, current + 1, current * 2 })
            {
                if (next == target)
                    return time + 1;

                if (next >= 0 && next <= MAX && !visited[next])
                {
                    visited[next] = true;
                    queue.Enqueue((next, time + 1));
                }
            }
        }

        return -1; // 이론적으로 여기에 도달하지 않음
    }
}