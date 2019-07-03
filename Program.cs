using System;
using System.Collections.Generic;

namespace TicTacToe
{
/*
 * A console application representation of TicTacToe
 * using OOP
 * 
 */
    class Program
    {
        const int BOARD_SIZE = 9;

        static void Main(string[] args)
        {
            // Create the board
            var board = new string[,]
            {
               { "1", "2", "3" },
               { "4", "5", "6" },
               { "7", "8", "9" }
            };
            
            var selectedFields = new List<string>();
            // Display the board on the console

            ShowBoard(board);

            //Number of Players
            var players = new string[]
            {
                "X",
                "O"
            };

            var currentPlayer = 0;
            var gameWon = false;

            do
            {
                Console.Write("Player{0}: Choose a field! ", currentPlayer + 1);

                var selectedInput = Console.ReadLine();

                if (Int32.TryParse(selectedInput, out int chosenField))
                {
                    if (!selectedFields.Contains(selectedInput))
                    {
                        var fieldPosition = GetPositionOfSelectedFieldOnBoard(board, chosenField);
                        var row = fieldPosition[0];
                        var column = fieldPosition[1];

                        if (currentPlayer == 0)
                        {
                            board[row, column] = players[currentPlayer];
                            currentPlayer = 1;
                        }
                        else
                        {
                            board[row, column] = players[currentPlayer];
                            currentPlayer = 0;
                        }

                        selectedFields.Add(selectedInput);

                        Console.Clear();

                        ShowBoard(board);

                        // check game status
                        foreach (string player in players)
                        {
                            if (
                                (board[0, 0] == player && board[0, 1] == player && board[0, 2] == player) ||
                                (board[1, 0] == player && board[1, 1] == player && board[1, 2] == player) ||
                                (board[2, 0] == player && board[2, 1] == player && board[2, 2] == player) ||
                                (board[0, 0] == player && board[1, 0] == player && board[2, 0] == player) ||
                                (board[0, 1] == player && board[1, 1] == player && board[2, 1] == player) ||
                                (board[0, 2] == player && board[1, 2] == player && board[2, 2] == player) ||
                                (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player) ||
                                (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player)
                               )
                            {
                                Console.WriteLine("\nPlayer {0} has won!", (player == "X" ? "1" : "2"));
                                gameWon = true;
                                break;
                            }

                        }

                        if (selectedFields.Count == BOARD_SIZE && gameWon != true )
                        {
                            Console.WriteLine("\nGame finished with a Draw\nPress any key to reset.");
                            Console.ReadKey();
                            board = new string[,]
            {
               { "1", "2", "3" },
               { "4", "5", "6" },
               { "7", "8", "9" }
            };
                            selectedFields.Clear();
                            Console.Clear();
                            currentPlayer = 0;
                            ShowBoard(board);
                        }

                        continue;
                    }
                    else
                    {
                        Console.WriteLine("FIeld already selected");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a number!\nIncorrect Input");
                }

            } while (gameWon == false);


        }

            public static void ShowBoard(string[,] board)
            {
                Console.WriteLine(@"
    |    |     
  {0} |  {1} |  {2}      
____|____|_____
    |    |     
  {3} |  {4} |  {5}    
____|____|_____
    |    |     
  {6} |  {7} |  {8}    
    |    |    
            ",
    board[0, 0],
    board[0, 1],
    board[0, 2],
    board[1, 0],
    board[1, 1],
    board[1, 2],
    board[2, 0],
    board[2, 1],
    board[2, 2]);
            }

        public static int[] GetPositionOfSelectedFieldOnBoard(string[,] board, int selectedField)
        {
            int row = -1, column = -1;

            Console.WriteLine(board.Length);
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    var tryParse = Int32.TryParse(board[i, j], out int field);
                    if (tryParse)
                    {
                        if (field == selectedField)
                        {
                            row = i;
                            column = j;
                            break;
                        }

                    }
                }
            }

            Console.WriteLine("Value: {0}, {1}", row, column);

            return new int[] { row, column };
        }

    }

 
}



