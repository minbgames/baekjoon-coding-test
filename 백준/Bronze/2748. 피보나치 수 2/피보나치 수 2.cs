using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        long[] dp = new long[91];

        dp[0] = 0;
        dp[1] = 1;

        for (int i = 2; i <= n; i++)
        {
            dp[i] = dp[i - 1] + dp[i - 2];
        }

        Console.WriteLine(dp[n]);
    }
}