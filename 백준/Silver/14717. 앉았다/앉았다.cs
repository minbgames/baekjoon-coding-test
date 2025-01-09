class Program
{
    static void Main(string[] args)
    {
        string[] inputs = Console.ReadLine().Split();
        int A = int.Parse(inputs[0]);
        int B = int.Parse(inputs[1]);
        Console.WriteLine(CalculateWinningProbability(A, B).ToString("F3"));
    }

    static double CalculateWinningProbability(int A, int B)
    {
        var myScore = GetScore(A, B);
        var allCards = Enumerable.Range(1, 10).SelectMany(x => new List<int> { x, x }).ToList();

        allCards.Remove(A);
        allCards.Remove(B);

        int totalCases = 0;
        int winningCases = 0;

        for (int i = 0; i < allCards.Count; i++)
        {
            for (int j = i + 1; j < allCards.Count; j++)
            {
                totalCases++;
                int oppScore = GetScore(allCards[i], allCards[j]);
                if (myScore > oppScore)
                    winningCases++;
            }
        }
        
        return (double)winningCases / totalCases;
    }

    static int GetScore(int card1, int card2)
    {
        if (card1 == card2) return card1 + 100;
        return (card1 + card2) % 10;
    }
}