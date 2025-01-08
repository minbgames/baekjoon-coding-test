class Program
{
    static void Main(string[] args)
    {
        int testCases = int.Parse(Console.ReadLine());
        List<int> numbers = new List<int>();

        for (int i = 0; i < testCases; i++)
            numbers.Add(int.Parse(Console.ReadLine()));

        List<int> results = SolveEureka(numbers);

        foreach (var result in results)
            Console.WriteLine(result);
    }

    static List<int> GenerateNum(int inputNum)
    {
        List<int> triangleNum = new List<int>();

        int testNum = 1;
        while (true)
        {
            int maxNum = testNum * (testNum + 1) / 2;
            if (maxNum > inputNum) break;
            triangleNum.Add(maxNum);
            testNum++;
        }

        return triangleNum;
    }

    static int IsEureka(int inputNum, List<int> triangleNumbers)
    {
        for (int i = 0; i < triangleNumbers.Count; i++){
            for (int j = 0; j < triangleNumbers.Count; j++){
                int resultNum = inputNum - (triangleNumbers[i] + triangleNumbers[j]);
                if (triangleNumbers.Contains(resultNum))
                    return 1;
            }
        }

        return 0;
    }

    static List<int> SolveEureka(List<int> nums)
    {
        List<int> results = new List<int>();
        foreach (var num in nums)
        {
            List<int> triangleNums = GenerateNum(num);
            results.Add(IsEureka(num, triangleNums));
        }

        return results;
    }
}