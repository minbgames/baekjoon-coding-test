using System;

class BingoGame
{
    static void Main(string[] args)
    {
        int[,] bingoBoard = new int[5, 5];
        int[] numbersCalled = new int[25];
        bool[,] marked = new bool[5, 5];

        for (int i = 0; i < 5; i++)
        {
            string[] input = Console.ReadLine().Split();
            for (int j = 0; j < 5; j++)
            {
                bingoBoard[i, j] = int.Parse(input[j]);
            }
        }

        for (int i = 0; i < 5; i++)
        {
            string[] input = Console.ReadLine().Split();
            for (int j = 0; j < 5; j++)
            {
                numbersCalled[i * 5 + j] = int.Parse(input[j]);
            }
        }

        for (int count = 0; count < 25; count++)
        {
            MarkNumber(bingoBoard, marked, numbersCalled[count]);
            if (CheckBingo(marked) >= 3)
            {
                Console.WriteLine(count + 1);
                return;
            }
        }
    }

    static void MarkNumber(int[,] board, bool[,] marked, int number)
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (board[i, j] == number)
                {
                    marked[i, j] = true;
                    return;
                }
            }
        }
    }

    static int CheckBingo(bool[,] marked)
    {
        int bingoCount = 0;

        for (int i = 0; i < 5; i++)
        {
            if (IsCompleteRow(marked, i)) bingoCount++;
            if (IsCompleteColumn(marked, i)) bingoCount++;
        }

        if (IsCompleteDiagonal(marked)) bingoCount++;
        if (IsCompleteAntiDiagonal(marked)) bingoCount++;

        return bingoCount;
    }

    static bool IsCompleteRow(bool[,] marked, int row)
    {
        for (int j = 0; j < 5; j++)
        {
            if (!marked[row, j]) return false;
        }
        return true;
    }

    static bool IsCompleteColumn(bool[,] marked, int col)
    {
        for (int i = 0; i < 5; i++)
        {
            if (!marked[i, col]) return false;
        }
        return true;
    }

    static bool IsCompleteDiagonal(bool[,] marked)
    {
        for (int i = 0; i < 5; i++)
        {
            if (!marked[i, i]) return false;
        }
        return true;
    }

    static bool IsCompleteAntiDiagonal(bool[,] marked)
    {
        for (int i = 0; i < 5; i++)
        {
            if (!marked[i, 4 - i]) return false;
        }
        return true;
    }
}