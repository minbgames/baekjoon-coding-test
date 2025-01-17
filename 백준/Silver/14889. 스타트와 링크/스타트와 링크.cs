using System;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[,] s = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split(' ');
            for (int j = 0; j < n; j++)
            {
                s[i, j] = int.Parse(input[j]);
            }
        }

        Console.WriteLine(FindMinDifference(n, s));
    }

    static int FindMinDifference(int n, int[,] s)
    {
        bool[] selected = new bool[n];
        return CalculateMinDifference(n, s, selected, 0, 0);
    }

    static int CalculateMinDifference(int n, int[,] s, bool[] selected, int index, int count)
    {
        if (count == n / 2)
        {
            return CalculateTeamDifference(n, s, selected);
        }

        if (index >= n)
        {
            return int.MaxValue;
        }

        selected[index] = true;
        int include = CalculateMinDifference(n, s, selected, index + 1, count + 1);

        selected[index] = false;
        int exclude = CalculateMinDifference(n, s, selected, index + 1, count);

        return Math.Min(include, exclude);
    }

    static int CalculateTeamDifference(int n, int[,] s, bool[] selected)
    {
        int startSum = 0, linkSum = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (selected[i] && selected[j])
                {
                    startSum += s[i, j];
                }
                else if (!selected[i] && !selected[j])
                {
                    linkSum += s[i, j];
                }
            }
        }

        return Math.Abs(startSum - linkSum);
    }
}