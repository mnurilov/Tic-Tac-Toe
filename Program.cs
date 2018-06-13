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

        //public string name;
        
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
            Console.WriteLine("Welcome to Tic Tac Toe\n");
            
            Console.Write("Press enter to play");

            Console.ReadLine();
        }

        static bool hasWon() 
        {
            return false;
        }

        static bool choiceValid(string choice) 
        {
            if (Convert.ToInt32(choice) >= 1 && Convert.ToInt32(choice) <= 9) 
            {
                return true;
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
                Console.WriteLine("Player 1 make your move\n");
            }
            else if (Player2.turn == true) 
            {
                Console.WriteLine("Player 2 make your move\n");    
            }
        }

        static void changeGameBoard(Player player, int cell) 
        {
            gameBoard[cell] = player.mark; 
        }

        static void Main(string[] args)
        {
            Console.Title = "Tic Tac Toe";

            Introduction();

            Console.Clear();

            InitalizeGameBoard();

            string choice;

            

            Player1.turn = true;

            Player1.mark = "X";

            Player2.mark = "O";


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
                }
                else if (Player2.turn == true)
                {
                    changeGameBoard(Player2, Convert.ToInt32(choice));
                }
            }
        }
    }
}
