using System;
using System.Reflection.Metadata.Ecma335;

namespace Tic_Tac_Toe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            int turn = 1;
            string[,] myArray2D =
            {
                {"1", "2", "3"},
                {"4", "5", "6"},
                {"7", "8", "9"},
            };

            do
            {
                Console.Clear();
                PrintTicTacToe(myArray2D);
                if (turn == 1)
                {
                    Console.WriteLine(@"Type the number you want to place your turn on. Type ""Quit"" at the end of the game to exit.");
                }

                do
                {
                    GetInput(turn, myArray2D);
                    Console.Clear();
                    PrintTicTacToe(myArray2D);

                    if(turn == 9 && !DoIWin(myArray2D, turn))
                    {
                        Console.WriteLine("It's a tie!");
                        break;
                    }
                    turn++;
                } while (!DoIWin(myArray2D, turn) && turn < 10) ;

                if ((turn == 9 && !DoIWin(myArray2D, turn)))
                {

                }
                else
                {
                    PrintWinner(turn);
                }

                RestartGame(myArray2D);
                turn = 1;
                Console.WriteLine("Do you want to play another game? ");
                input = Console.ReadLine();
             
            } while (!input.Equals("Quit"));
            
        }

        //This function prints the tictactoe board
        public static void PrintTicTacToe(string[,] array2D)
        {
            string spacer = "   |   |   ";
            string line = "---|---|---";

            Console.WriteLine($" {array2D[0,0]} | {array2D[0,1]} | {array2D[0,2]}");
            Console.WriteLine(line);
            Console.WriteLine($" {array2D[1, 0]} | {array2D[1, 1]} | {array2D[1, 2]}");
            Console.WriteLine(line);
            Console.WriteLine($" {array2D[2, 0]} | {array2D[2, 1]} | {array2D[2, 2]}");
        }
 
        //This functions tells "True" if there is a winner and "False" if the game is still ongoing
        public static bool DoIWin(string[,] array2D, int turn)
        {
            if (turn <= 5)
            {
                return false; 
            }    
            else
            {
                if (array2D[0,0] == array2D[0, 1] && array2D[0,1] == array2D[0,2])
                    return true;
                if (array2D[1,0] == array2D[1, 1] && array2D[1,1] == array2D[1,2])
                    return true;
                if (array2D[2,0] == array2D[2,1] && array2D[2,1] == array2D[2,2])
                    return true;
                if (array2D[0,0] == array2D[1,0] && array2D[1,0] == array2D[2,0])
                    return true;
                if (array2D[0, 1] == array2D[1,1] && array2D[1,1] == array2D[2,1])
                    return true;
                if (array2D[0, 2] == array2D[1,2] && array2D[1,2] == array2D[2,2])
                    return true;
                if (array2D[0, 0] == array2D[1, 1] && array2D[1, 1] == array2D[2, 2])
                    return true;
                if (array2D[0, 2] == array2D[1, 1] && array2D[1, 1] == array2D[2, 0])
                    return true;
                return false;
            }
        }
        
        //This method returns who is the Player given the turn
        public static string Player(int turn)
        {
            if (turn % 2 != 0)
                return "1";
            else
                return "2";
        }

        //This function gives "True" if the input is valid and "False" if the field is taken already.
        public static bool CheckInput(int input, string[,] my2DArray)
        {
            foreach (string i in my2DArray)
            {
                if (input.ToString() == i)
                {
                    return true;
                }     
            }
            return false;
        }

        //This method writes on Console the winner
        public static void PrintWinner (int turn)
        {
            if (turn % 2 != 0)
                Console.WriteLine("Congratulations Player 2!");
            else
                Console.WriteLine("Congratulations Player 1!");
        }

        //This method Gets the Input from the player and returns the array
        public static void GetInput(int turn, string[,] array2D)
        {
            int integerInput;
            string result;
            bool boolResult;
            do
            {
                Console.WriteLine($"Player {Player(turn)}: Choose your field! ");

                result = Console.ReadLine();
                boolResult = int.TryParse(result, out integerInput);

                if (boolResult == false)
                {
                    Console.WriteLine("Incorrect input! Please enter a valid number");
                }
                else if (!CheckInput(integerInput, array2D))
                {
                    Console.WriteLine("Incorrect input! Please use another field.");
                }

            } while (!boolResult || !CheckInput(integerInput, array2D));

            switch (Player(turn))
            {
                case "1":
                    switch (integerInput)
                    {
                        case 1: array2D[0, 0] = "O"; break;
                        case 2: array2D[0, 1] = "O"; break;
                        case 3: array2D[0, 2] = "O"; break;
                        case 4: array2D[1, 0] = "O"; break;
                        case 5: array2D[1, 1] = "O"; break;
                        case 6: array2D[1, 2] = "O"; break;
                        case 7: array2D[2, 0] = "O"; break;
                        case 8: array2D[2, 1] = "O"; break;
                        case 9: array2D[2, 2] = "O"; break;
                    }
                    break;
                case "2":
                    switch (integerInput)
                    {
                        case 1: array2D[0, 0] = "X"; break;
                        case 2: array2D[0, 1] = "X"; break;
                        case 3: array2D[0, 2] = "X"; break;
                        case 4: array2D[1, 0] = "X"; break;
                        case 5: array2D[1, 1] = "X"; break;
                        case 6: array2D[1, 2] = "X"; break;
                        case 7: array2D[2, 0] = "X"; break;
                        case 8: array2D[2, 1] = "X"; break;
                        case 9: array2D[2, 2] = "X"; break;
                    }
                    break;
            }

        }

        //This function restarts the game by assigning the array back to the original fields.
        public static void RestartGame(string[,] array2D)
        {
            int count = 1;
            for (int i=0; i<3; i++)
            {
                for (int j=0; j<3; j++)
                {
                    array2D[i, j] = count.ToString();
                    count++;
                }
            }
        }
    }
}
