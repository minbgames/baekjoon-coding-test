class Program
{
    private static void Main(string[] args)
    {
        List<int> dataList = ReadData();
        FindData(dataList);
        PrintData(dataList);
    }
    
    private static List<int> ReadData()
    {
        List<int> dataList = new List<int>();
        for (int i = 0; i < 9; i++)
            dataList.Add(int.Parse(Console.ReadLine()));
        
        return dataList;
    }
    
    private static void FindData(List<int> dataList)
    {
        int sum = dataList.Sum();
        
        for (int i = 0; i < 9; i++)
        {
            for (int j = i + 1; j < 9; j++)
            {
                if (sum - dataList[i] - dataList[j] == 100)
                {
                    dataList.RemoveAt(j);
                    dataList.RemoveAt(i);
                    return;
                }
            }
        }
    }
    
    private static void PrintData(List<int> dataList)
    {
        dataList.Sort();
        foreach (var data in dataList)
            Console.WriteLine(data);
    }
}