using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class TicTacToe
{
    static char[] board = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

    static void Main()
    {
        int player = 1, input, status = -1;
        PrintBoard();

        while (status == -1)
        {
            player = (player % 2 == 0) ? 2 : 1;
            char mark = (player == 1) ? 'X' : 'O';
            Console.WriteLine("Please enter Number For Player {0}", player);

            while (!int.TryParse(Console.ReadLine(), out input) || input < 1 || input > 9 || board[input] == 'X' || board[input] == 'O')
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 9 that is not already taken.");
            }

            board[input] = mark;
            PrintBoard();

            int result = CheckWin();

            if (result == 1)
            {
                Console.WriteLine("Player {0} is the Winner!", player);
                return;
            }
            else if (result == 0)
            {
                Console.WriteLine("It's a draw!");
                return;
            }

            player++;
        }
    }

    static void PrintBoard()
    {
        Console.Clear();
        Console.WriteLine("\n\n");
        Console.WriteLine("=== TIC TAC TOE ===\n\n");
        Console.WriteLine("     |     |     ");
        Console.WriteLine("  {0}  |  {1}  |  {2}  ", board[1], board[2], board[3]);
        Console.WriteLine("_____|_____|_____");
        Console.WriteLine("     |     |     ");
        Console.WriteLine("  {0}  |  {1}  |  {2}  ", board[4], board[5], board[6]);
        Console.WriteLine("_____|_____|_____");
        Console.WriteLine("     |     |     ");
        Console.WriteLine("  {0}  |  {1}  |  {2}  ", board[7], board[8], board[9]);
        Console.WriteLine("     |     |     ");
        Console.WriteLine("\n\n");
    }

    static int CheckWin()
    {
        // Check for winning conditions
        if (board[1] == board[2] && board[2] == board[3]) return 1;
        if (board[1] == board[4] && board[4] == board[7]) return 1;
        if (board[7] == board[8] && board[8] == board[9]) return 1;
        if (board[3] == board[6] && board[6] == board[9]) return 1;
        if (board[1] == board[5] && board[5] == board[9]) return 1;
        if (board[3] == board[5] && board[5] == board[7]) return 1;
        if (board[2] == board[5] && board[5] == board[8]) return 1;
        if (board[4] == board[5] && board[5] == board[6]) return 1;

        // Check for a draw
        int count = 0;
        for (int i = 1; i <= 9; i++)
        {
            if (board[i] == 'X' || board[i] == 'O') count++;
        }
        if (count == 9) return 0;

        // Continue the game
        return -1;
    }
}
