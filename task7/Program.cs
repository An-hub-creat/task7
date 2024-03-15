using System;

class Program
{
    static int[,] board = new int[8, 8];
    static int[] queenPlacement = new int[8];
    static int maxFreeField = 0;
    static Random rnd = new Random();

    static void Main(string[] args)
    {
        PlaceQueens();
        DisplayBoard();
    }

    static void PlaceQueens()
    {
        for (int i = 0; i < 8; i++)
        {
            int maxFree = 0;
            int colWithMaxFree = 0;

            for (int j = 0; j < 8; j++)
            {
                if (board[i, j] == 0)
                {
                    int freeFields = CountFreeFields(i, j);
                    if (freeFields > maxFree)
                    {
                        maxFree = freeFields;
                        colWithMaxFree = j;
                    }
                }
            }

            board[i, colWithMaxFree] = 1;
            queenPlacement[i] = colWithMaxFree;
        }
    }

    static int CountFreeFields(int row, int col)
    {
        int count = 0;

        for (int i = 0; i < 8; i++)
        {
            if (board[row, i] == 0) // Check row
                count++;

            if (board[i, col] == 0) // Check column
                count++;

            int diagRow = row - i;
            int diagCol = col - i;
            if (diagRow >= 0 && diagRow < 8 && diagCol >= 0 && diagCol < 8 && board[diagRow, diagCol] == 0) // Check diagonal \
                count++;

            diagRow = row + i;
            diagCol = col - i;
            if (diagRow >= 0 && diagRow < 8 && diagCol >= 0 && diagCol < 8 && board[diagRow, diagCol] == 0) // Check diagonal /
                count++;
        }

        return count - 4; // Subtract the intersections counted twice
    }

    static void DisplayBoard()
    {
        Console.WriteLine("Board with Queens Placed:");
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (board[i, j] == 1)
                    Console.Write(" Q ");
                else
                    Console.Write(" - ");
            }
            Console.WriteLine();
        }
    }
}