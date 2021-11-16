using System;

namespace GRAND_FATHER
{
    public class GameBoard
    {

        public static ChessPiece[,] board = new ChessPiece[10, 9]; //Create an actual chessboard to store chesspiece and all the moving method is based on this board

        public static int posx;
        public static int posy;
        public static int posx2;
        public static int posy2;
        public static int turn = 0;
        public int Gameover = 0;

        public void InitializeBoard()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    board[i, j] = null;//Fill the board with "null" at the beginning to initialize the board
                }
            }
            //Create chesspieces on the actual board
            board[0, 0] = new Chariot(Side.black);
            board[0, 1] = new Horse(Side.black);
            board[0, 2] = new Elephant(Side.black);
            board[0, 3] = new Advisor(Side.black);
            board[0, 4] = new General(Side.black);
            board[0, 5] = new Advisor(Side.black);
            board[0, 6] = new Elephant(Side.black);
            board[0, 7] = new Horse(Side.black);
            board[0, 8] = new Chariot(Side.black);
            board[2, 1] = new Cannon(Side.black);
            board[2, 7] = new Cannon(Side.black);
            board[3, 0] = new Soldier(Side.black);
            board[3, 2] = new Soldier(Side.black);
            board[3, 4] = new Soldier(Side.black);
            board[3, 6] = new Soldier(Side.black);
            board[3, 8] = new Soldier(Side.black);


            board[9, 0] = new Chariot(Side.red);
            board[9, 1] = new Horse(Side.red);
            board[9, 2] = new Elephant(Side.red);
            board[9, 3] = new Advisor(Side.red);
            board[9, 4] = new General(Side.red);
            board[9, 5] = new Advisor(Side.red);
            board[9, 6] = new Elephant(Side.red);
            board[9, 7] = new Horse(Side.red);
            board[9, 8] = new Chariot(Side.red);
            board[7, 1] = new Cannon(Side.red);
            board[7, 7] = new Cannon(Side.red);
            board[6, 0] = new Soldier(Side.red);
            board[6, 2] = new Soldier(Side.red);
            board[6, 4] = new Soldier(Side.red);
            board[6, 6] = new Soldier(Side.red);
            board[6, 8] = new Soldier(Side.red);

            //Using "ToString()" method which were stored in Chesspiece object to present Chinese Character on the displayboard
            GameDisplay.displayboard[0, 0] = board[0, 0].ToString();
            GameDisplay.displayboard[0, 2] = board[0, 1].ToString();
            GameDisplay.displayboard[0, 4] = board[0, 2].ToString();
            GameDisplay.displayboard[0, 6] = board[0, 3].ToString();
            GameDisplay.displayboard[0, 8] = board[0, 4].ToString();
            GameDisplay.displayboard[0, 10] = board[0, 5].ToString();
            GameDisplay.displayboard[0, 12] = board[0, 6].ToString();
            GameDisplay.displayboard[0, 14] = board[0, 7].ToString();
            GameDisplay.displayboard[0, 16] = board[0, 8].ToString();
            GameDisplay.displayboard[4, 2] = board[2, 1].ToString();
            GameDisplay.displayboard[4, 14] = board[2, 7].ToString();
            GameDisplay.displayboard[6, 0] = board[3, 0].ToString();
            GameDisplay.displayboard[6, 4] = board[3, 2].ToString();
            GameDisplay.displayboard[6, 8] = board[3, 4].ToString();
            GameDisplay.displayboard[6, 12] = board[3, 6].ToString();
            GameDisplay.displayboard[6, 16] = board[3, 8].ToString();


            GameDisplay.displayboard[18, 0] = board[9, 0].ToString();
            GameDisplay.displayboard[18, 2] = board[9, 1].ToString();
            GameDisplay.displayboard[18, 4] = board[9, 2].ToString();
            GameDisplay.displayboard[18, 6] = board[9, 3].ToString();
            GameDisplay.displayboard[18, 8] = board[9, 4].ToString();
            GameDisplay.displayboard[18, 10] = board[9, 5].ToString();
            GameDisplay.displayboard[18, 12] = board[9, 6].ToString();
            GameDisplay.displayboard[18, 14] = board[9, 7].ToString();
            GameDisplay.displayboard[18, 16] = board[9, 8].ToString();
            GameDisplay.displayboard[14, 2] = board[7, 1].ToString();
            GameDisplay.displayboard[14, 14] = board[7, 7].ToString();
            GameDisplay.displayboard[12, 0] = board[6, 0].ToString();
            GameDisplay.displayboard[12, 4] = board[6, 2].ToString();
            GameDisplay.displayboard[12, 8] = board[6, 4].ToString();
            GameDisplay.displayboard[12, 12] = board[6, 6].ToString();
            GameDisplay.displayboard[12, 16] = board[6, 8].ToString();
            DrawingBoard();

        }


        public static void DrawingBoard()//Print the displayboard on console
        {

            Console.Clear();

            for (int a = 0; a < 19; a++)
            {
                Console.BackgroundColor = ConsoleColor.White;//define the background color of console table.
                for (int b = 0; b < 18; b++)
                {

                    if (board[a / 2, b / 2] == null)
                        Console.ForegroundColor = ConsoleColor.Blue;//define the color of displayboard
                    else if (board[a / 2, b / 2].Side == Side.red)//define the color of red pieces, only when the piece's side is belong to red side,the following sentences would work
                    {
                        if (b % 2 == 1 || a % 2 == 1)
                            Console.ForegroundColor = ConsoleColor.Blue;
                        else Console.ForegroundColor = ConsoleColor.DarkRed;
                    }
                    else if (board[a / 2, b / 2].Side == Side.black)
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
            Console.WriteLine(" 0   1   2   3   4   5   6   7   8 ");//presenting at the bottom of chessboard to declare the coordinates for player to choose


        }

        public void JudgeSide()
        {
            if (turn % 2 == 0)//The first turn is black player's turn
            {
                while ((board[(posy) / 2, (posx) / 2] == null || board[(posy) / 2, (posx) / 2].Side == Side.red))//Judge whether the black player select red player's chesspiece or select an empty place
                {
                    Console.ForegroundColor = ConsoleColor.Red;//All the alert messages should be red to draw players attention
                    Console.WriteLine("You select the wrong piece!");
                    Console.WriteLine("Please press enter and select your side and enter again!");
                    ClearWrongInput();//To clear the error input to let console looks concise
                    SelectPiece();//Ask player to select again
                }
            }
            if (turn % 2 == 1)
            {
                while ((board[(posy) / 2, (posx) / 2] == null || board[(posy) / 2, (posx) / 2].Side == Side.black))//Judge whether the black player select red player's chesspiece or select an empty place
                {
                    Console.ForegroundColor = ConsoleColor.Red;//All the alert messages should be red to draw players attention
                    Console.WriteLine("You select the wrong piece!");
                    Console.WriteLine("Please select your side and enter again!");
                    ClearWrongInput();//To clear the error input to let console looks concise
                    SelectPiece();//Ask player to select again
                }
            }
            turn++;
        }

        public void InValidMove()//Judge whether the destination's coordinate is the as the starting point's coordinate, and let player to select pieces again once this condition happened
        {
            while (posx == posx2 && posy == posy2)
            {
                turn--;//When the player have made invalid input, "turn" will minus 1 in order to let this player to have his or her turn again
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Your destination is the same as your starting point!!!!");
                Console.WriteLine("Please press enter and choose again!");
                ClearWrongInput();
                SelectPiece();
                JudgeSide();
                SelectPosition();
            }
        }
        public void SelectPiece()//Method of selecting pieces
        {
            if (turn % 2 == 0)//When this is black player's turn
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("\n");
                Console.WriteLine("-------It's BLACK turn!!!-------\nWhich piece do you want to move?(PLEASE INPUT TWO NUMBERS. Like: 11)");
            }
            if (turn % 2 == 1)//When this is red player's turn
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n");
                Console.WriteLine("-------It's RED turn!!!-------\nWhich piece do you want to move?(PLEASE INPUT TWO NUMBERS. Like: 98)");
            }
            Console.WriteLine("First number is for Y-axis (0-9)\nSecond number is for X-axis (0-8)");//Mindful tip to remind player how to input 


            string position = Console.ReadLine();//receive player's input 

            while (position[0] > '9' || position[0] < '0' || position[1] > '8' || position[1] < '0' || position.Length != 2)//Judge whether the player have input a coordinate which outside the chessboard
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This piece does not exist! Please press enter and enter again");
                ClearWrongInput();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please select your piece and please input only 2 numbers!");
                position = Console.ReadLine();

            }

            //Receive player's input and convert its input's coordinates for JudgeMoveRule to judge the move is valid or not 
            string position1, position2;
            position1 = position.Substring(0, 1);
            position2 = position.Substring(1);
            posy = Convert.ToInt32(position1) * 2;
            posx = Convert.ToInt32(position2) * 2;

        }



        public void SelectPosition()
        {
            if (turn % 2 == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
            }
            if (turn % 2 == 1)
            {
                Console.ForegroundColor = ConsoleColor.Black;
            }

            Console.WriteLine("Please enter the position you want to move:");
            string position = Console.ReadLine();//receive player's input 

             while (position[0] > '9' || position[0] < '0' || position[1] > '8' || position[1] < '0' || position.Length != 2)//Judge whether the player have input a coordinate which outside the chessboard
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This piece does not exist! Please press enter and enter again");
                ClearWrongInput();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please select your destination and please input only 2 numbers!");
                position = Console.ReadLine();
            }
            
            //Receive player's input and convert its input's coordinates for JudgeMoveRule to judge the move is valid or not 
            string position1, position2;

            position1 = position.Substring(0, 1);
            position2 = position.Substring(1);
            posy2 = Convert.ToInt32(position1) * 2;
            posx2 = Convert.ToInt32(position2) * 2;
        }

        public void MovePiece(int posy, int posx, int posy2, int posx2)
        {
            //Once the destination is general and this move is valid, the game will over
            if (GameDisplay.displayboard[posy2, posx2] == "帅" || GameDisplay.displayboard[posy2, posx2] == "将")
                Gameover = 1;

            if (GameBoard.board[posy2 / 2, posx2 / 2] == GameBoard.board[posy / 2, posx / 2])//When the destination is as the same as starting point , jump to InValidMove and execute its mothod
            {
                InValidMove();
            }
            GameDisplay.displayboard[posy2, posx2] = GameDisplay.displayboard[posy, posx];//The Character of the starting point on the displayboard move to the destination,and display on displayboard
            GameBoard.board[posy2 / 2, posx2 / 2] = GameBoard.board[posy / 2, posx / 2];//The chesspiece in actual board move to the destination on actual board
            GameBoard.board[posy / 2, posx / 2] = null;//Use null to replace the starting point in actual board
            //The following sentences is to recover the displaboard once a piece have moved
            if (posy == 0)
            {
                if (posx == 0) GameDisplay.displayboard[posy, posx] = "┏-";
                else if (posx == 16) GameDisplay.displayboard[posy, posx] = "┓";
                else GameDisplay.displayboard[posy, posx] = "—";
            }
            else if (posy == 18)
            {
                if (posx == 0) GameDisplay.displayboard[posy, posx] = "┗-";
                else if (posx == 16) GameDisplay.displayboard[posy, posx] = "┛";
                else GameDisplay.displayboard[posy, posx] = "—";
            }
            else if (posx == 0)
            {
                if (posy > 0 && posy < 18) GameDisplay.displayboard[posy, posx] = "┣-";
            }
            else if (posx == 16)
            {
                if (posy > 0 && posy < 18) GameDisplay.displayboard[posy, posx] = "┫ ";
            }
            else if (posy == 8)
            {
                if (posx > 0 && posx < 16) GameDisplay.displayboard[posy, posx] = "--";
            }
            else if (posy == 10)
            {
                if (posx > 0 && posx < 16) GameDisplay.displayboard[posy, posx] = "--";
            }
            else GameDisplay.displayboard[posy, posx] = "╋-";

            DrawingBoard();

        }

        public void JudgeMoveRules()//Judge whether the move is valid or not, if the move is invalid, ask player to select again
        {

            while (MovesJudge() == false)
            {   
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nYour move is invalid!");
                Console.WriteLine("Please press enter and enter again!");
                ClearWrongInput();
                turn -- ;
                SelectPiece();
                JudgeSide();
                SelectPosition();

            }
        }


        public bool MovesJudge()//While JudgeMoveRules is pass, which means this move is valid, then determine whether this move satisfy the selected piece's corresponding moving method or not
        {
            if (board[posy / 2, posx / 2].Move() == false) { return false; }
            else return true;

        }

        public void ClearWrongInput()//To delete error messages once player's input is invalid,because once the player have input error coordinates many times,the console will look messy
        {
                Console.Write("\n");
                Console.ReadKey();
                Console.Clear();
                DrawingBoard();
        }
    }

}
