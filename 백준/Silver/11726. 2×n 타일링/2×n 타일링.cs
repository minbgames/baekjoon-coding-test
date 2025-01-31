using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        if (n == 1)
        {
            Console.WriteLine(1);
            return;
        }
        if (n == 2)
        {
            Console.WriteLine(2);
            return;
        }

        int[] dp = new int[n + 1];
        dp[1] = 1;
        dp[2] = 2;

        for (int i = 3; i <= n; i++)
        {
            dp[i] = (dp[i - 1] + dp[i - 2]) % 10007;  // 10007로 나눈 나머지 저장
        }

        Console.WriteLine(dp[n]);
    }
}