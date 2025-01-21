using System;
using System.Collections.Generic;

class Program
{
    static List<int>[] graph;
    static bool[] visited;

    static void Main(string[] args)
    {
        string[] inputs = Console.ReadLine().Split();
        int n = int.Parse(inputs[0]);
        int m = int.Parse(inputs[1]);

        graph = new List<int>[n + 1];
        visited = new bool[n + 1];

        for (int i = 1; i <= n; i++)
        {
            graph[i] = new List<int>();
        }

        for (int i = 0; i < m; i++)
        {
            string[] edge = Console.ReadLine().Split();
            int u = int.Parse(edge[0]);
            int v = int.Parse(edge[1]);

            graph[u].Add(v);
            graph[v].Add(u);
        }

        int connectedComponents = 0;

        for (int i = 1; i <= n; i++)
        {
            if (!visited[i])
            {
                DFS(i);
                connectedComponents++;
            }
        }

        Console.WriteLine(connectedComponents);
    }

    static void DFS(int node)
    {
        visited[node] = true;

        foreach (int neighbor in graph[node])
        {
            if (!visited[neighbor])
            {
                DFS(neighbor);
            }
        }
    }
}