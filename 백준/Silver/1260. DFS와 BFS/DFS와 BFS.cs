using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<int>[] graph;
    static bool[] visited;

    static void Main(string[] args)
    {
        string[] inputs = Console.ReadLine().Split();
        int n = int.Parse(inputs[0]);
        int m = int.Parse(inputs[1]);
        int v = int.Parse(inputs[2]);

        graph = new List<int>[n + 1];
        for (int i = 1; i <= n; i++)
        {
            graph[i] = new List<int>();
        }

        for (int i = 0; i < m; i++)
        {
            string[] edge = Console.ReadLine().Split();
            int a = int.Parse(edge[0]);
            int b = int.Parse(edge[1]);

            graph[a].Add(b);
            graph[b].Add(a);
        }

        for (int i = 1; i <= n; i++)
        {
            graph[i].Sort();
        }

        visited = new bool[n + 1];
        List<int> dfsResult = new List<int>();
        DFS(v, dfsResult);
        Console.WriteLine(string.Join(" ", dfsResult));

        visited = new bool[n + 1];
        List<int> bfsResult = BFS(v);
        Console.WriteLine(string.Join(" ", bfsResult));
    }

    static void DFS(int node, List<int> result)
    {
        visited[node] = true;
        result.Add(node);

        foreach (int neighbor in graph[node])
        {
            if (!visited[neighbor])
            {
                DFS(neighbor, result);
            }
        }
    }

    static List<int> BFS(int start)
    {
        Queue<int> queue = new Queue<int>();
        List<int> result = new List<int>();

        queue.Enqueue(start);
        visited[start] = true;

        while (queue.Count > 0)
        {
            int node = queue.Dequeue();
            result.Add(node);

            foreach (int neighbor in graph[node])
            {
                if (!visited[neighbor])
                {
                    visited[neighbor] = true;
                    queue.Enqueue(neighbor);
                }
            }
        }

        return result;
    }
}