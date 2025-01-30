using System;

class Program
{
    static void Main()
    {
        string[] inputs = Console.ReadLine().Split();
        int N = int.Parse(inputs[0]);
        int S = int.Parse(inputs[1]);
        int M = int.Parse(inputs[2]);

        int[] V = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        bool[,] dp = new bool[N + 1, M + 1];
        dp[0, S] = true;

        for (int i = 0; i < N; i++)
        {
            for (int v = 0; v <= M; v++)
            {
                if (!dp[i, v]) continue;

                int volUp = v + V[i];
                int volDown = v - V[i];

                if (volUp <= M) dp[i + 1, volUp] = true;
                if (volDown >= 0) dp[i + 1, volDown] = true;
            }
        }

        for (int v = M; v >= 0; v--)
        {
            if (dp[N, v])
            {
                Console.WriteLine(v);
                return;
            }
        }

        Console.WriteLine(-1);
    }
}