class Program
{
    static void Main(string[] args)
    {
        int m = int.Parse(Console.ReadLine());
        int[] cups = { 1, 0, 0 };

        for (int i = 0; i < m; i++)
        {
            string[] input = Console.ReadLine().Split();
            int x = int.Parse(input[0]) - 1;
            int y = int.Parse(input[1]) - 1;

            (cups[x], cups[y]) = (cups[y], cups[x]);
        }

        for (int i = 0; i < cups.Length; i++)
        {
            if (cups[i] == 1)
            {
                Console.WriteLine(i + 1);
                return;
            }
        }

        Console.WriteLine(-1);
    }
}