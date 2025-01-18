using System;
using System.Collections.Generic;

class Program
{
    static int n;
    static int[] numbers;
    static int[] operators;
    static int maxResult = int.MinValue;
    static int minResult = int.MaxValue;

    static void Main(string[] args)
    {
        n = int.Parse(Console.ReadLine());
        numbers = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        operators = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        Calculate(numbers[0], 1);

        Console.WriteLine(maxResult);
        Console.WriteLine(minResult);
    }

    static void Calculate(int currentResult, int index)
    {
        if (index == n)
        {
            maxResult = Math.Max(maxResult, currentResult);
            minResult = Math.Min(minResult, currentResult);
            return;
        }

        for (int i = 0; i < 4; i++)
        {
            if (operators[i] > 0)
            {
                operators[i]--;
                switch (i)
                {
                    case 0:
                        Calculate(currentResult + numbers[index], index + 1);
                        break;
                    case 1:
                        Calculate(currentResult - numbers[index], index + 1);
                        break;
                    case 2:
                        Calculate(currentResult * numbers[index], index + 1);
                        break;
                    case 3:
                        Calculate(currentResult / numbers[index], index + 1);
                        break;
                }
                operators[i]++;
            }
        }
    }
}