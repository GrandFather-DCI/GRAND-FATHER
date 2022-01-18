using System;

namespace GRAND_FATHER
{
    public class GameBoard
    {

        public static ChessPiece[,] board = new ChessPiece[10, 9]; //initialize an actual chessboard to store chesspiece and all the moving method
       
        public static int posx;
        public static int posy;
        public static int posx2;
        public static int posy2;
        public static int turn = 0;
        public  int Gameover = 0;
        public static int ErrorNumber = 0;

        

        public void InitializeBoard()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    board[i, j] = null; //new blank(Side.blank);//初始化null
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
            GameDisplay.DrawingBoard();

        }



        public void JudgeSide()//Determine whether the player select his or her opponent's chesspiece or select an empty place
        {

            if (turn % 2 == 0)
            {
                while ((board[(posy) / 2, (posx) / 2].Side == Side.red))
                {
                    ErrorNumber = 5;
                    GameDisplay.ErrorMessage();
                    SelectPiece();
                }
            }
            if (turn % 2 == 1)
            {
                while (( board[(posy) / 2, (posx) / 2].Side == Side.black))
                {
                    ErrorNumber = 5;
                    GameDisplay.ErrorMessage();
                    SelectPiece();
                }
            }
            turn++;
        }


        public void SelectPiece()//Method of selecting piece
        {
            GameDisplay.SelectPieceDisplay();
           
            string position = Console.ReadLine();

            while (position.Length != 2 || position[0] > '9' || position[0] < '0' || position[1] > '8' || position[1] < '0'  )
            {
                ErrorNumber = 2;
                GameDisplay.ErrorMessage();
                position = Console.ReadLine();

            }

            tab : string position1, position2;
            position1 = position.Substring(0, 1);
            position2 = position.Substring(1);
            posy = Convert.ToInt32(position1) * 2;
            posx = Convert.ToInt32(position2) * 2;

            if(board[(posy)/2 , (posx)/ 2] == null)
            {
                ErrorNumber = 1;
                GameDisplay.ErrorMessage();
                position = Console.ReadLine();
                goto tab;
            }

        }



        public void SelectPosition()//Method of selecting destination
        {
            GameDisplay.SelectPositionDisplay();
  
            string position = Console.ReadLine();

            while (position.Length != 2 || position[0] > '9' || position[0] < '0' || position[1] > '8' || position[1] < '0'  )
            {
                ErrorNumber = 2;
                GameDisplay.ErrorMessage();
                position = Console.ReadLine();
                
            }

            string position1, position2;

            position1 = position.Substring(0, 1);
            position2 = position.Substring(1);
            posy2 = Convert.ToInt32(position1) * 2;
            posx2 = Convert.ToInt32(position2) * 2;

            
        }

        public void MovePiece(int posy, int posx, int posy2, int posx2)
        {

            if (GameDisplay.displayboard[posy2, posx2] == "帅")
                Gameover = 2;

            if (GameDisplay.displayboard[posy2, posx2] == "将")
                Gameover = 1;

            GameDisplay.displayboard[posy2, posx2] = GameDisplay.displayboard[posy, posx];
            GameBoard.board[posy2 / 2, posx2 / 2] = GameBoard.board[posy / 2, posx / 2];
            GameBoard.board[posy / 2, posx / 2] = null;
            //The following sentence is to recover the displayboard
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

            GameDisplay.DrawingBoard();

        }

        public void InValidMove()//Judge whether the destination's coordinate is the same as the starting point's coordinate and let player to select piece again once this condition happen 
        {
            while (posx == posx2 && posy == posy2)
            {
                turn--;
                ErrorNumber = 3;
                GameDisplay.ErrorMessage();
                SelectPiece();
                JudgeSide();
                SelectPosition();
            }
        }
        public void JudgeMoveRules()//Judge whether the move is valid or not, if the move is invalid, ask the player to select again
        {

            while (MovesJudge() == false)
            {
                ErrorNumber = 4;
                GameDisplay.ErrorMessage();
                SelectPosition();

            }
        }


        public bool MovesJudge()//While JudgeMoveRule is pass,which means this move is valid,then determine whether this move satisfy the selected piece's corresponding moving method or not
        {
            if (board[posy / 2, posx / 2].Move(posx, posy, posx2,posy2,board) == false) { return false; }
            else return true;

        }


    }

}
