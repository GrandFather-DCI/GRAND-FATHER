using System;
using System.Windows;

namespace Xiangqi01
{
    public class GameBoard
    {

        public static ChessPiece[,] board = new ChessPiece[10, 9]; //initialize an actual chessboard to store chesspiece and all the moving method

        public static int posx;
        public static int posy;
        public static int posx2;
        public static int posy2;
        int turn = 0;
        int color = 0;
        int Gameover = 0;
        public int Messagenumber = 0;
        public static int ChoseChess = 0;
        public static bool Selected = false;
        public static bool Moveable = false;



        public void InitializeBoard()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    board[i, j] = new blank(Side.blank);   
                }
            }

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

        }

        public void JudgeSide()  //Determine whether the player select his or her opponent's chesspiece
        {
            if (turn % 2 == 0) color = 1; //For black pieces     
            else color = 2; //For red pieces
        }
        public void SelectPiece(int row, int column)
        {
            if(color == 1)//For black pieces
            {
                if (board[row, column].Side == Side.red)
                {
                    Messagenumber = 1;
                    Message();
                    Selected = false;
                }
                else if (board[row, column].Side == Side.blank)
                {
                    Messagenumber = 3;
                    Message();
                    Selected = false;
                }
                else
                {
                    posy = row;
                    posx = column;
                    ChoseChess = 1;
                    Selected = true;
                    turn++;
                }
            }
            if (color == 2) //For red pieces
            {
                if (board[row, column].Side == Side.black)
                {
                    Messagenumber = 2;
                    Message();
                    Selected = false;
                }
                else if (board[row, column].Side == Side.blank)
                {
                    Messagenumber = 3;
                    Message();
                    Selected = false;
                }
                else
                {
                    posy = row;
                    posx = column;
                    ChoseChess = 1;
                    Selected = true;
                    turn++;
                }
            }

        }


        public void MovePiece(int row, int column)
        {
            posy2 = row;
            posx2 = column;

            if (board[posy, posx].Move(posx, posy, posx2, posy2, board))  
            {
                if (board[posy2, posx2].Type == PieceTypes.General && posy2 < 5)  
                    Gameover = 2;
                if (board[posy2, posx2].Type == PieceTypes.General && posy2 >= 5) 
                    Gameover = 1;

                board[posy2, posx2] = board[posy, posx];
                board[posy, posx] = new blank(Side.blank);
                ChoseChess = 0;
                Moveable = true;
            }
            else if (board[posy, posx] == board[posy2, posx2])  
            {
                ChoseChess = 0;
                Moveable = true;
                turn--;
            }
            else if (board[posy, posx].Side == board[posy2, posx2].Side)
            {
                ChoseChess = 0;
                Moveable = true;
                turn--;
                Messagenumber = 4;
                Message();
            }

            else if (board[posy2, posx2].Side == Side.blank)
            {
                ChoseChess = 0;
                Moveable = true;
                turn--;
                Messagenumber = 3;
                Message();
            }

            else Moveable = false;
        }


        public void Message()
        {

            switch (Messagenumber)
            {
                case 1:
                    MessageBox.Show("Now it's black's turn. Please select a black piece!");
                    Messagenumber = 0;
                    break;
                case 2:
                    MessageBox.Show("Now it's red's turn. Please select a red piece!");
                    Messagenumber = 0;
                    break;
                case 3:
                    MessageBox.Show("Select an empty piece. Please choose again");
                    Messagenumber = 0;
                    break;
                case 4:
                    MessageBox.Show("Sorry,you can't pick pieces from the same team");
                    Messagenumber = 0;
                    break;
            }

            switch (Gameover)
            {
                case 1:
                    MessageBox.Show("Game over! BLACK WIN!");
                    break;
                case 2:
                    MessageBox.Show("Game over! RED WIN!");
                    break;
            }
          }
    }

}
