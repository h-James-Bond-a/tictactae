using System;

namespace TicTacToe
{
    class Program
    {
        static char[,] board = new char[3, 3]; // 3x3 game board
        static char currentPlayer = 'X'; // 'X' starts the game

        static void Main(string[] args)
        {
            InitializeBoard();
            bool gameOver = false;

            while (!gameOver)
            {
                DrawBoard();
                Console.WriteLine($"Player {currentPlayer}, enter your move (row [0-2] and column [0-2]):");
                string input = Console.ReadLine();
                int.TryParse(input[0].ToString(), out int row);
                int.TryParse(input[2].ToString(), out int col);

                if (IsValidMove(row, col))
                {
                    MakeMove(row, col);

                    if (IsWinner())
                    {
                        DrawBoard();
                        Console.WriteLine($"Player {currentPlayer} wins!");
                        gameOver = true;
                    }
                    else if (IsBoardFull())
                    {
                        DrawBoard();
                        Console.WriteLine("It's a draw!");
                        gameOver = true;
                    }
                    else
                    {
                        currentPlayer = (currentPlayer == 'X') ? 'O' : 'X'; // Switch player
                    }
                }
                else
                {
                    Console.WriteLine("Invalid move. Please try again.");
                }
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        static void InitializeBoard()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    board[row, col] = '-';
                }
            }
        }

        static void DrawBoard()
        {
            Console.WriteLine("Current board state:");
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Console.Write($"{board[row, col]} ");
                }
                Console.WriteLine();
            }
        }

        static bool IsValidMove(int row, int col)
        {
            return (row >= 0 && row < 3 && col >= 0 && col < 3 && board[row, col] == '-');
        }

        static void MakeMove(int row, int col)
        {
            board[row, col] = currentPlayer;
        }

        static bool IsWinner()
        {
            // Check rows
            for (int row = 0; row < 3; row++)
            {
                if (board[row, 0] == currentPlayer && board[row, 1] == currentPlayer && board[row, 2] == currentPlayer)
                {
                    return true;
                }
            }

            // Check columns
            for (int col = 0; col < 3; col++)
            {
                if (board[0, col] == currentPlayer && board[1, col] == currentPlayer && board[2, col] == currentPlayer)
                {
                    return true;
                }
            }

            // Check diagonals
            if ((board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer) ||
                (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer))
            {
                return true;
            }

            return false;
        }

        static bool IsBoardFull()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (board[row, col] == '-')
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
