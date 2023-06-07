using System;

class Program
{
    static int[] board = new int[9];
    static Random rand = new Random();

    static void Main()
    {
        for (int i = 0; i < 9; i++)
        {
            board[i] = 0;
        }

        int userTurn = -1;

        while (true)
        {
            while (userTurn == -1 || userTurn < 0 || userTurn > 8 || board[userTurn] != 0)
            {
                Console.Write("Enter a number between 0 and 8: ");
                try
                {
                    userTurn = int.Parse(Console.ReadLine());

                    // Check if the input is within the valid range
                    if (userTurn < 0 || userTurn > 8)
                    {
                        Console.WriteLine("Invalid input. Please enter a number between 0 and 8.");
                        continue; // Restart the loop to prompt for input again
                    }

                    // Check if the selected area is unselected
                    if (board[userTurn] != 0)
                    {
                        Console.WriteLine("Invalid input. Please choose an unselected area.");
                        continue; // Restart the loop to prompt for input again
                    }

                    Console.WriteLine($"You chose: {userTurn}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }

            board[userTurn] = 1;




            // To Let Comp Only Choose the unselected area
            int compTurn;
            do
            {
                compTurn = rand.Next(9);
            } while (board[compTurn] != 0);
            board[compTurn] = 2;

            printBoard();

            if (checkForWinner())
            {
                Console.WriteLine("Congratulations! You won!");
                break;
            }

            bool isBoardFull = true;
            for (int i = 0; i < 9; i++)
            {
                if (board[i] == 0)
                {
                    isBoardFull = false;
                    break;
                }
            }

            if (isBoardFull)
            {
                Console.WriteLine("It's a draw!");
                break;
            }

            userTurn = -1;
        }
    }

    static bool checkForWinner()
    {
        // Top row
        if (board[0] == board[1] && board[1] == board[2] && board[0] != 0)
            return true;

        // Second row
        if (board[3] == board[4] && board[4] == board[5] && board[3] != 0)
            return true;
        // Third row
        if (board[6] == board[7] && board[7] == board[8] && board[6] != 0)
            return true;

        // First column
        if (board[0] == board[3] && board[3] == board[6] && board[0] != 0)
            return true;

        // Second column
        if (board[1] == board[4] && board[4] == board[7] && board[1] != 0)
            return true;

        // Third column
        if (board[2] == board[5] && board[5] == board[8] && board[2] != 0)
            return true;

        // Diagonal top-left to bottom-right
        if (board[0] == board[4] && board[4] == board[8] && board[0] != 0)
            return true;

        // Diagonal top-right to bottom-left
        if (board[2] == board[4] && board[4] == board[6] && board[2] != 0)
            return true;

        return false;
    }

    static void printBoard()
    {
        Console.WriteLine("Board:");
        for (int i = 0; i < 9; i++)
        {
            if (board[i] == 0)
                Console.Write("-");
            else if (board[i] == 1)
                Console.Write("X");
            else if (board[i] == 2)
                Console.Write("O");

            if (i % 3 == 2)
                Console.WriteLine();
        }
    }
}


