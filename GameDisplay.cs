using System;
namespace GRAND_FATHER
{
    public class GameDisplay
    {
        public static string[,] displayboard = new string[20, 18];



        public void Gamestart()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("***************************************************************");
            Console.WriteLine("*                                                             *");
            Console.WriteLine("*                                                             *");
            Console.WriteLine("*                                                             *");
            Console.WriteLine("*             ★ Welcome to the XiangQi Game！★              *");
            Console.WriteLine("*     Press Any Button to Start Initializing the Gameboard    *");
            Console.WriteLine("*                                                             *");
            Console.WriteLine("*                                                             *");
            Console.WriteLine("*                         Produce  By                         *");
            Console.WriteLine("*                         ★ Cien  ★                         *");
            Console.WriteLine("*                         ★ Lucas ★                         *");
            Console.WriteLine("*                         ★Lucien ★                         *");
            Console.WriteLine("*                         ★Melody ★                         *");
            Console.WriteLine("*                         ★Jeffrey★                         *");
            Console.WriteLine("*                                                             *");
            Console.WriteLine("*                                                             *");
            Console.WriteLine("***************************************************************");
            Console.ReadKey();
            Console.WriteLine();
            Console.Clear();
        }
        public void Storingboard()
        {
            displayboard[0, 0] = "┏-";
            displayboard[18, 0] = "┗-";
            displayboard[0, 16] = "┓";
            displayboard[18, 16] = "┛";
            displayboard[0, 17] = " 0";
            displayboard[18, 17] = " 9";

            for (int i = 1; i < 18; i++)
            {
                if (i % 2 == 0)
                {
                    displayboard[i, 0] = "┣-";
                    displayboard[i, 16] = "┫ ";
                    displayboard[i, 17] = " " + i / 2;

                }
                else
                {
                    displayboard[i, 0] = "┃ ";
                    displayboard[i, 16] = "┃ ";
                }

            }

            for (int j = 1; j < 16; j++)
            {
                displayboard[0, j] = "—";
                displayboard[10, j] = "--";
                displayboard[8, j] = "--";
                displayboard[18, j] = "—";
            }

            for (int k = 1; k < 16; k++)
            {


                displayboard[1, k] = "┃ ";
                displayboard[2, k] = "╋-";
                displayboard[3, k] = "┃ ";
                displayboard[4, k] = "╋-";
                displayboard[5, k] = "┃ ";
                displayboard[6, k] = "╋-";
                displayboard[7, k] = "┃ ";
                displayboard[9, k] = "  ";
                displayboard[11, k] = "┃ ";
                displayboard[12, k] = "╋-";
                displayboard[13, k] = "┃ ";
                displayboard[14, k] = "╋-";
                displayboard[15, k] = "┃ ";
                displayboard[16, k] = "╋-";
                displayboard[17, k] = "┃ ";

                if (k % 2 != 0)
                {
                    displayboard[1, k] = "  ";
                    displayboard[2, k] = "  ";
                    displayboard[3, k] = "  ";
                    displayboard[4, k] = "  ";
                    displayboard[5, k] = "  ";
                    displayboard[6, k] = "  ";
                    displayboard[7, k] = "  ";
                    displayboard[9, k] = "  ";
                    displayboard[11, k] = "  ";
                    displayboard[12, k] = "  ";
                    displayboard[13, k] = "  ";
                    displayboard[14, k] = "  ";
                    displayboard[15, k] = "  ";
                    displayboard[16, k] = "  ";
                    displayboard[17, k] = "  ";
                }
            }

            displayboard[1, 6] = "┃";
            displayboard[3, 6] = "┃";
            displayboard[15, 6] = "┃";
            displayboard[17, 6] = "┃";
            displayboard[9, 5] = "楚";
            displayboard[9, 6] = "河";
            displayboard[9, 10] = "汉";
            displayboard[9, 11] = "界";
            displayboard[1, 8] = "╲┃╱";
            displayboard[3, 8] = "╱┃╲";
            displayboard[15, 8] = "╲┃╱";
            displayboard[17, 8] = "╱┃╲";

            DrawingBoard();
        }


        public static void DrawingBoard()
        {

            Console.Clear();

            for (int a = 0; a < 19; a++)
            {
                Console.BackgroundColor = ConsoleColor.White;
                for (int b = 0; b < 18; b++)
                {

                    if (GameBoard.board[a / 2, b / 2] == null)
                        Console.ForegroundColor = ConsoleColor.Blue;
                    else if (GameBoard.board[a / 2, b / 2].Side == Side.red)
                    {
                        if (b % 2 == 1 || a % 2 == 1)
                            Console.ForegroundColor = ConsoleColor.Blue;
                        else Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    }
                    else if (GameBoard.board[a / 2, b / 2].Side == Side.black)
                    {
                        if (b % 2 == 1 || a % 2 == 1)
                            Console.ForegroundColor = ConsoleColor.Blue;
                        else Console.ForegroundColor = ConsoleColor.Black;
                    }


                    Console.Write(GameDisplay.displayboard[a, b]);
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            Console.WriteLine(" 0   1   2   3   4   5   6   7   8 ");


        }


        public static void ErrorMessage()
        {
            switch (GameBoard.ErrorNumber)
            {
                case 1:
                    Console.WriteLine("You select an empty place,please select again");
                    return;


                case 2:
                    Console.WriteLine("Your input is invalid!!");
                    Console.WriteLine("Please enter only 2 numebrs!");
                    return;

                case 3:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Your destination is the same as your starting point!!!!");
                    Console.WriteLine("Please choose again!");
                    return;

                case 4:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Your move is invalid!");
                    Console.WriteLine("Please select your destination again!");
                    Console.Write("\n");
                    return;

                case 5:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You select the wrong side!");
                    Console.WriteLine("Please select your side and enter again!");
                    Console.Write("\n");
                    return;
            }
        }

        public static void SelectPieceDisplay()
        {
            if (GameBoard.turn % 2 == 0)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("\n");
                Console.WriteLine("-------It's BLACK turn!!!-------\nWhich piece do you want to move?(PLEASE INPUT TWO NUMBERS. Like: 11)");
            }
            if (GameBoard.turn % 2 == 1)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("\n");
                Console.WriteLine("-------It's RED turn!!!-------\nWhich piece do you want to move?(PLEASE INPUT TWO NUMBERS. Like: 98)");
            }
            Console.WriteLine("First number is for Y-axis (0-9)\nSecond number is for X-axis (0-8)");
        }

        public static void SelectPositionDisplay()
        {
            if (GameBoard.turn % 2 == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
            }
            if (GameBoard.turn % 2 == 1)
            {
                Console.ForegroundColor = ConsoleColor.Black;
            }

            Console.WriteLine("Please enter the position you want to move:");
        }
    
    }
}