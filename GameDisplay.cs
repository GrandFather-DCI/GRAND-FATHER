using System;
namespace GRAND_FATHER
{
    public class GameDisplay
    {
        public static string[,] displayboard = new string[20, 18];  //Create a displayboard which will present on the console table
        
        

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
        public void Storingboard()//Print the chessboard in displayboard
        {       
            displayboard[0, 0] = "┏-";
            displayboard[18, 0] = "┗-";
            displayboard[0, 16] = "┓";
            displayboard[18, 16] = "┛";
            displayboard [0, 17] = " 0\tBLACK";//To remind user the upper half chessboard is belong to black player
            displayboard[18, 17] = " 9\tRED";//To remind user the bottom half chessboard is belong to red player

            for (int i = 1; i < 18; i++)
            {
                if (i % 2 == 0)
                {
                    displayboard[i, 0] = "┣-";
                    displayboard[i, 16] = "┫ " ;
                    displayboard[i, 17] = " " + i/2;

                }
                else
                {
                    displayboard[i, 0] = "┃ ";
                    displayboard[i, 16] = "┃ " ;
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

            GameBoard.DrawingBoard();
        }



   
        

    


   
    }
    
}