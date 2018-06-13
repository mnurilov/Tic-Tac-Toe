using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _49_Tic_Tac_Toe
{
    class Player
    {
        public bool turn;

        public string mark;

        public bool victory = false;

        public string name;

    }

    class Program
    {
        public static int gameBoardLength = 9;
        public static string[] gameBoard = new string[gameBoardLength];
        public static Player Player1 = new Player();
        public static Player Player2 = new Player();

        static void InitalizeGameBoard()
        {
            for (int i = 0; i < gameBoardLength; i++)
            {
                gameBoard[i] = (i + 1).ToString();
            }
        }

        /* Game Board
          1 | 2 | 3
          ---------
          4 | 5 | 6
          ---------
          7 | 8 | 9
        */
        static void PrintGameBoard()
        {
            Console.WriteLine("     " + gameBoard[0] + " | " + gameBoard[1] + " | " + gameBoard[2]);

            Console.WriteLine("     " + "---------");

            Console.WriteLine("     " + gameBoard[3] + " | " + gameBoard[4] + " | " + gameBoard[5]);

            Console.WriteLine("     " + "---------");

            Console.WriteLine("     " + gameBoard[6] + " | " + gameBoard[7] + " | " + gameBoard[8]);

            Console.WriteLine();
        }

        static void Introduction()
        {
            Console.Title = "Tic Tac Toe";

            Console.WriteLine("Welcome to Tic Tac Toe\n");

            Console.WriteLine("Please enter your names\n");

            Console.Write("Player 1, Name: ");

            Player1.name = Console.ReadLine();

            Console.WriteLine();

            Console.Write("Player 2, Name: ");

            Player2.name = Console.ReadLine();

            Console.Clear();
        }

        static bool gameBoardCheck(int first, int second, int third, Player player)
        {
            if (gameBoard[first - 1] == player.mark && gameBoard[second - 1] == player.mark && gameBoard[third - 1] == player.mark)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void initializePlayers() 
        {
            Player1.turn = true;

            Player1.mark = "X";

            Player2.mark = "O";
        }

        static bool whichPlayerWon(Player player)
        {
            if (gameBoardCheck(1, 2, 3, player))
            {
                return true;
            }
            else if (gameBoardCheck(4, 5, 6, player))
            {
                return true;
            }
            else if (gameBoardCheck(7, 8, 9, player))
            {
                return true;
            }
            else if (gameBoardCheck(1, 4, 7, player))
            {
                return true;
            }
            else if (gameBoardCheck(2, 5, 8, player))
            {
                return true;
            }
            else if (gameBoardCheck(3, 6, 9, player))
            {
                return true;
            }
            else if (gameBoardCheck(1, 5, 9, player))
            {
                return true;
            }
            else if (gameBoardCheck(3, 5, 7, player))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool ifXorO(int arrayCount, Player player1, Player player2) 
        {
            if ((gameBoard[arrayCount - 1] == player1.mark) || (gameBoard[arrayCount - 1] == player2.mark))
            {
                return true;    
            }
            else
            { 
                return false;
            }
        }

        static bool hasTie() 
        {
            if (ifXorO(1, Player1, Player2) && ifXorO(2, Player1, Player2) && ifXorO(3, Player1, Player2)
                 && ifXorO(4, Player1, Player2) && ifXorO(5, Player1, Player2) && ifXorO(6, Player1, Player2)
                  && ifXorO(7, Player1, Player2) && ifXorO(8, Player1, Player2) && ifXorO(9, Player1, Player2)) 
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        static bool hasWon()
        {
            if (whichPlayerWon(Player1))
            {
                Player1.victory = true;
                return true;
            }
            else if (whichPlayerWon(Player2))
            {
                Player2.victory = true;
                return true;
            }
            else if (hasTie() == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool choiceValid(string choice)
        {
            int choiceIntValue;

            if (int.TryParse(choice, out choiceIntValue))
            {
                if (choiceIntValue >= 1 && choiceIntValue <= 9)
                {
                    if (gameBoard[choiceIntValue - 1] == "X" || gameBoard[choiceIntValue - 1] == "O")
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        static void invalidCellChoice()
        {
            Console.WriteLine("Invalid choice, please try again\n");
        }

        static void whoseTurn()
        {
            if (Player1.turn == true)
            {
                Console.WriteLine("{0} make your move\n", Player1.name);
            }
            else if (Player2.turn == true)
            {
                Console.WriteLine("{0} make your move\n", Player2.name);
            }
        }

        static void changeGameBoard(Player player, int cell)
        {
            gameBoard[cell] = player.mark;
        }

        static void victoryStatement(Player player1, Player player2)
        {
            Console.WriteLine("Congratulations {0}, you have beaten {1} at the most skill intensive game in the world, Tic Tac Toe!\n",
                player1.name, player2.name);
        }

        static void Main(string[] args)
        {
            Introduction();

            InitalizeGameBoard();

            initializePlayers();

            string choice = "";

            //Game Loop
            while (hasWon() == false)
            {
                Console.Clear();
                whoseTurn();
                PrintGameBoard();
                choice = Console.ReadLine();

                while (choiceValid(choice) == false)
                {
                    Console.Clear();
                    invalidCellChoice();
                    PrintGameBoard();
                    choice = Console.ReadLine();
                }

                if (Player1.turn == true)
                {
                    changeGameBoard(Player1, (Convert.ToInt32(choice) - 1));
                    Player1.turn = false;
                    Player2.turn = true;
                }

                else if (Player2.turn == true)
                {
                    changeGameBoard(Player2, (Convert.ToInt32(choice) - 1));
                    Player2.turn = false;
                    Player1.turn = true;
                }
            }

            if (Player1.victory == true)
            {
                Console.Clear();
                victoryStatement(Player1, Player2);
                PrintGameBoard();
                Console.ReadKey();
            }
            else if (Player2.victory == true)
            {
                Console.Clear();
                victoryStatement(Player2, Player1);
                PrintGameBoard();
                Console.ReadKey();
            }
            else if (Player1.victory == false && Player2.victory == false) 
            {
                Console.Clear();
                Console.WriteLine("You two are equals in the dastardly complex game, Tic Tac Toe\n");
                PrintGameBoard();
                Console.ReadKey();
            }
        }
    }
}