class Program
{
    static void Main(string[] args)
    {
        int initialCash = int.Parse(Console.ReadLine());
        string[] priceInputs = Console.ReadLine().Split();
        int[] prices = Array.ConvertAll(priceInputs, int.Parse);

        int junhyunAssets = SimulateBNP(initialCash, prices);
        int seongminAssets = SimulateTiming(initialCash, prices);

        if (junhyunAssets > seongminAssets)
        {
            Console.WriteLine("BNP");
        }
        else if (junhyunAssets < seongminAssets)
        {
            Console.WriteLine("TIMING");
        }
        else
        {
            Console.WriteLine("SAMESAME");
        }
    }

    static int SimulateBNP(int cash, int[] prices)
    {
        int stocks = 0;

        foreach (var price in prices)
        {
            if (cash >= price)
            {
                int buyableStocks = cash / price;
                stocks += buyableStocks;
                cash -= buyableStocks * price;
            }
        }

        return cash + stocks * prices[^1];
    }

    static int SimulateTiming(int cash, int[] prices)
    {
        int stocks = 0;
        int consecutiveUp = 0;
        int consecutiveDown = 0;

        for (int i = 1; i < prices.Length; i++)
        {
            if (prices[i] > prices[i - 1])
            {
                consecutiveUp++;
                consecutiveDown = 0;
            }
            else if (prices[i] < prices[i - 1])
            {
                consecutiveDown++;
                consecutiveUp = 0;
            }
            else
            {
                consecutiveUp = 0;
                consecutiveDown = 0;
            }

            if (consecutiveUp >= 3 && stocks > 0)
            {
                cash += stocks * prices[i];
                stocks = 0;
            }

            if (consecutiveDown >= 3 && cash >= prices[i])
            {
                int buyableStocks = cash / prices[i];
                stocks += buyableStocks;
                cash -= buyableStocks * prices[i];
            }
        }

        return cash + stocks * prices[^1];
    }
}