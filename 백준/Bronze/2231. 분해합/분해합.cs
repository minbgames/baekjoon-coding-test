class Program
{
    static void Main(string[] args)
    {
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine(FindGenerator(number));
    }

    private static int FindGenerator(int num)
    {
        for (int i = 0; i < num; i++)
        {
            if (Calculate(i) == num) return i;
        }

        return 0;
    }

    private static int Calculate(int num)
    {
        int sum = num;
        while (num > 0)
        {
            sum += num % 10;
            num /= 10;
        }

        return sum;
    }
}