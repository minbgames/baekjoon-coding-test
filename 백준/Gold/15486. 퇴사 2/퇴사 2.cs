using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] T = new int[n + 1];
        int[] P = new int[n + 1];
        int[] dp = new int[n + 2];

        for (int i = 1; i <= n; i++)
        {
            string[] input = Console.ReadLine().Split();
            T[i] = int.Parse(input[0]);
            P[i] = int.Parse(input[1]);
        }

        Console.WriteLine(CalculateMaxProfit(n, T, P, dp));
    }

    static int CalculateMaxProfit(int n, int[] T, int[] P, int[] dp)
    {
        for (int i = n; i >= 1; i--)
        {
            int nextDay = i + T[i];
            
            if (nextDay <= n + 1)
                dp[i] = Math.Max(dp[i + 1], P[i] + dp[nextDay]);
            else
                dp[i] = dp[i + 1];
        }

        return dp[1];
    }
}