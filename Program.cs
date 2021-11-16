using System;

namespace GRAND_FATHER
{
    class Program
    {
        static void Main(string[] args)
        {
         
            GameDisplay gamedisplay = new GameDisplay(); //Initialize the GameDisplay object
            GameBoard gameboard = new GameBoard();//Initialize the Gameboard object
         
            gamedisplay.Gamestart();//Print the welcome word 
            gamedisplay.Storingboard(); //create the displayboard
            gameboard.InitializeBoard();//create the actual board and put chesspieces on the actual board

            while(true){//Once 2 general is alive, the game will continue
           
            gameboard.SelectPiece();//Ask player to select chesspiece
            gameboard.JudgeSide();//Judge whether the player have select his or her opponet's chesspiece or select an empty place
            gameboard.SelectPosition();//Ask player to select destination
            gameboard.InValidMove();//Judge whether the player's selected piece's coordinate is as the same as the destination's coordinate
            gameboard.JudgeMoveRules();//Judge whether this move can satisfy the corresponding chesspiece's moving method
            gameboard.MovePiece(GameBoard.posy,GameBoard.posx,GameBoard.posy2,GameBoard.posx2);//Move the chesspiece
            if(gameboard.Gameover == 1){//Red player wins! Print the following message to celebrate!!
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("*************************");
            Console.WriteLine("*        Red Win        *");
            Console.WriteLine("*       Game Over.      *");
            Console.WriteLine("*************************");
            break;
            }
            if(gameboard.Gameover == 2){//Black player wins! Print the following message to celebrate!!
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("*************************");
            Console.WriteLine("*       Black Win        *");
            Console.WriteLine("*       Game Over.      *");
            Console.WriteLine("*************************");
            break;
            }
            }
        }
    }
}
