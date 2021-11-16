using System;


namespace GRAND_FATHER
{
    //public enum 


    public enum Side
    {
        red,
        black,

    }


    public enum PieceTypes
    {
        General,
        Advisor,
        Elephant,
        Horse,
        Chariot,
        Cannon,
        Soldier,
        Default,
    }


    public class ChessPiece
    {


        public Side Side { get; set; }
        public PieceTypes Type { get; set; }

        public override string ToString()
        {
            return "";
        }

        public virtual bool Move()
        {
            return false;
        }

        public ChessPiece(Side side)
        {

            this.Side = side;
        }
    }





    // public class blank : ChessPiece
    // {
    //     public blank(Side side) : base(side)
    //     {
    //         this.Type = PieceTypes.blank;
    //     }

    //     public override string ToString()
    //     {
    //         return "";

    //     }
    // }



    public class General : ChessPiece
    {
        public General(Side side) : base(side)
        {
            this.Type = PieceTypes.General;
        }

        public override string ToString()
        {
            if (Side == Side.red) { return "帅"; }
            else { return "将"; }

        }

        public override bool Move()
        {
            if (System.Math.Abs(GameBoard.posx - GameBoard.posx2) == 2 && (GameBoard.posy - GameBoard.posy2) == 0 || (GameBoard.posx - GameBoard.posx2) == 0 && System.Math.Abs(GameBoard.posy - GameBoard.posy2) == 2)//General can only move one step at a time
            {
                if (GameBoard.board[GameBoard.posy2 / 2, GameBoard.posx2 / 2] == null || GameBoard.board[GameBoard.posy2 / 2, GameBoard.posx2 / 2].Side != GameBoard.board[GameBoard.posy / 2, GameBoard.posx / 2].Side)//Chesspiece can move when its destination don't have pieces or the destination piece's side is not as same as itself
                {
                    if (GameBoard.posy2 > 4 && GameBoard.posy2 < 14 || GameBoard.posx2 < 6 || GameBoard.posx2 > 10) //General can only move in the General square
                        return false;
                    else return true;
                }
                else return false;
            }
            else
                return false;
        }


    }


    public class Advisor : ChessPiece
    {
        public Advisor(Side side) : base(side)
        {
            this.Type = PieceTypes.Advisor;
        }

        public override string ToString()
        {
            if (Side == Side.red) { return "仕"; }
            else { return "士"; }
        }
        public override bool Move()
        {
            if (System.Math.Abs(GameBoard.posx - GameBoard.posx2) == 2 && System.Math.Abs(GameBoard.posy - GameBoard.posy2) == 2)//Advisor can only move along the diagonal
            {
                if (GameBoard.board[GameBoard.posy2 / 2, GameBoard.posx2 / 2] == null || GameBoard.board[GameBoard.posy2 / 2, GameBoard.posx2 / 2].Side != GameBoard.board[GameBoard.posy / 2, GameBoard.posx / 2].Side)//Chesspiece can move when its destination don't have pieces or the destination piece's side is not as same as itself
                {
                    if (GameBoard.posy2 > 4 && GameBoard.posy2 < 14 || GameBoard.posx2 < 6 || GameBoard.posx2 > 10)//Advisor can only move in the General square
                        return false;
                    else return true;
                }
                else return false;
            }
            else
                return false;

        }
    }



    public class Elephant : ChessPiece
    {
        public Elephant(Side side) : base(side)
        {
            this.Type = PieceTypes.Elephant;
        }

        public override string ToString()
        {
            if (Side == Side.red) { return "相"; }
            else { return "象"; }
        }
        public override bool Move()
        {
            if (System.Math.Abs(GameBoard.posx - GameBoard.posx2) == 4 && System.Math.Abs(GameBoard.posy - GameBoard.posy2) == 4)//Elephant 's moving method , once it move, its x-coordinate and y-coordinate must each change 2 step.
            {
                if (GameBoard.board[GameBoard.posy2 / 2, GameBoard.posx2 / 2] == null || GameBoard.board[GameBoard.posy2 / 2, GameBoard.posx2 / 2].Side != GameBoard.board[GameBoard.posy / 2, GameBoard.posx / 2].Side)//Chesspiece can move when its destination don't have pieces or the destination piece's side is not as same as itself
                {
                    if (GameBoard.board[(GameBoard.posy / 2 + GameBoard.posy2 / 2) / 2, (GameBoard.posx / 2 + GameBoard.posx2 / 2) / 2] == null)//Elephant can move only when there is no chesspiece in the diagonal line in its moving path
                    {    //Determine if there are chess pieces
                        if (GameBoard.board[GameBoard.posy / 2, GameBoard.posx / 2].Side == Side.black)  //Cause Elephant cannot cross the river,so we have two different situation
                        {
                            if (GameBoard.posy2 > 8)
                                return false;
                            else
                                return true;
                        }
                        else 
                        {
                            if (GameBoard.posy2 < 10)
                                return false;
                            else
                                return true;
                        }
                    }
                    return false;
                }
                else return false;

            }
            else return false;
        }

    }

    public class Horse : ChessPiece
    {
        public Horse(Side side) : base(side)
        {
            this.Type = PieceTypes.Horse;
        }

        public override string ToString()
        {
            return "马";
        }

        public override bool Move()
        {
            if (GameBoard.board[GameBoard.posy2 / 2, GameBoard.posx2 / 2] == null || GameBoard.board[GameBoard.posy2 / 2, GameBoard.posx2 / 2].Side != GameBoard.board[GameBoard.posy / 2, GameBoard.posx / 2].Side)//Chesspiece can move when its destination don't have pieces or the destination piece's side is not as same as itself
            {    
                if (System.Math.Abs(GameBoard.posx - GameBoard.posx2) == 2 && System.Math.Abs(GameBoard.posy - GameBoard.posy2) == 4)//Horse 's moving method , its coordinates' changes must satisfy this condition
                {
                    if (GameBoard.board[(GameBoard.posy / 2 + GameBoard.posy2 / 2) / 2, GameBoard.posx / 2] != null)//Horse's moving rule, horse will stuck once there is a chesspiece in a particular place 
                    {
                        return false;
                    }
                    return true;
                }
                else if (System.Math.Abs(GameBoard.posx - GameBoard.posx2) == 4 && System.Math.Abs(GameBoard.posy - GameBoard.posy2) == 2)
                {
                    if (GameBoard.board[GameBoard.posy / 2, (GameBoard.posx / 2 + GameBoard.posx2 / 2) / 2] != null)
                    {
                        return false;
                    }
                    return true;
                }
            }
            return false;

        }
    }



    public class Chariot : ChessPiece
    {
        public Chariot(Side side) : base(side)
        {
            this.Type = PieceTypes.Chariot;
        }

        public override string ToString()
        {
            return "车";
        }
        public override bool Move()
        {
            if (GameBoard.posx == GameBoard.posx2 && GameBoard.posy != GameBoard.posy2)//Chariot move in vertical way
            {
                if (GameBoard.board[GameBoard.posy2 / 2, GameBoard.posx2 / 2] == null || GameBoard.board[GameBoard.posy2 / 2, GameBoard.posx2 / 2].Side != GameBoard.board[GameBoard.posy / 2, GameBoard.posx / 2].Side)
                {
                    for (int i = (GameBoard.posy / 2) + 1; i <= (GameBoard.posy2 / 2) - 1; i++)//Set a for loop to test whether there are pieces in its moving path
                    {
                        if (GameBoard.board[i, GameBoard.posx / 2] != null)//Chariot can move when there are no pieces in its moving pat
                            return false;
                    }
                    return true;
                }
                else if (GameBoard.board[GameBoard.posy2 / 2, GameBoard.posx2 / 2].Side == GameBoard.board[GameBoard.posy / 2, GameBoard.posx / 2].Side) return false;
            }

            if (GameBoard.posy == GameBoard.posy2 && GameBoard.posx != GameBoard.posx2)//Chariot move in horizontal way
            {
                if (GameBoard.board[GameBoard.posy2 / 2, GameBoard.posx2 / 2] == null || GameBoard.board[GameBoard.posy2 / 2, GameBoard.posx2 / 2].Side != GameBoard.board[GameBoard.posy / 2, GameBoard.posx / 2].Side)
                {

                    for (int i = (GameBoard.posx / 2) + 1; i <= (GameBoard.posx2 / 2) - 1; i++)
                    {
                        if (GameBoard.board[GameBoard.posy / 2, i] != null)
                            return false;
                    }
                    return true;

                }
                else if (GameBoard.board[GameBoard.posy2 / 2, GameBoard.posx2 / 2].Side == GameBoard.board[GameBoard.posy / 2, GameBoard.posx / 2].Side) return false;

            }
            return false;
        }
    }

    public class Cannon : ChessPiece
    {
        public Cannon(Side side) : base(side)
        {
            this.Type = PieceTypes.Cannon;
        }

        public override string ToString()
        {
            return "炮";
        }

        public override bool Move()
        {
            int count = 0;//To count how many pieces are in its moving path
            int i, j, rangeCannon;
            if (GameBoard.board[GameBoard.posy2 / 2, GameBoard.posx2 / 2] == null ||GameBoard.board[GameBoard.posy2 / 2, GameBoard.posx2 / 2].Side != GameBoard.board[GameBoard.posy / 2, GameBoard.posx / 2].Side)//Chesspiece can move when its destination don't have pieces or the destination piece's side is not as same as itself
            {    
            if (GameBoard.posx2 == GameBoard.posx)//Canon move in vertical way
            {
                i = GameBoard.posy < GameBoard.posy2 ? GameBoard.posy : GameBoard.posy2;//The x-coordinate of the starting point
                j = GameBoard.posy > GameBoard.posy2 ? GameBoard.posy : GameBoard.posy2;//The y-coordinate of the starting point
                for (rangeCannon = i / 2 + 1; rangeCannon < j / 2; rangeCannon++)
                {
                    if (GameBoard.board[rangeCannon, GameBoard.posx2 / 2] != null)//Judge whether there are pieces between its starting point and destination
                    {
                        count++;
                    }
                }
                if (count > 1)
                {
                    return false;
                }
            }
            else if (GameBoard.posy2 == GameBoard.posy)//Canon move in horizontal way
            {
                i = GameBoard.posx < GameBoard.posx2 ? GameBoard.posx : GameBoard.posx2;
                j = GameBoard.posx > GameBoard.posx2 ? GameBoard.posx : GameBoard.posx2;
                for (rangeCannon = i / 2 + 1; rangeCannon < j / 2; rangeCannon++)
                {
                    if (GameBoard.board[GameBoard.posy2 / 2, rangeCannon] != null)//Judge whether there are pieces between its starting point and destination
                    {
                        count++;
                    }
                }
                if (count > 1)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            if (count == 0 && GameBoard.board[GameBoard.posy2 / 2, GameBoard.posx2 / 2] != null)//There are no pieces in its moving path and the destination has piece
            {
                return false;
            }
            if (count == 1 && GameBoard.board[GameBoard.posy2 / 2, GameBoard.posx2 / 2] == null)
            {
                return false;
            }
            return true;
          }return false;

        }


    }

    public class Soldier : ChessPiece
    {
        public Soldier(Side side) : base(side)
        {
            this.Type = PieceTypes.Soldier;
        }

        public override string ToString()
        {
            if (Side == Side.red) { return "兵"; }
            else { return "卒"; }
        }

        public override bool Move()
        {
            if (GameBoard.board[GameBoard.posy2 / 2, GameBoard.posx2 / 2] == null || GameBoard.board[GameBoard.posy2 / 2, GameBoard.posx2 / 2].Side != GameBoard.board[GameBoard.posy / 2, GameBoard.posx / 2].Side)
            {
                if (GameBoard.board[GameBoard.posy / 2, GameBoard.posx / 2].Side == Side.red)//Move rule for red Player's soldier
                {
                    if (GameBoard.posy2 >= 10)//Rules for Soldier once they haven't cross the river
                    {
                        if (GameBoard.posx != GameBoard.posx2 || GameBoard.posy - GameBoard.posy2 > 2 || GameBoard.posy - GameBoard.posy2 < 0)//1.soldier can't move in horizontal way 2.Soldier can only move 1 step at a time 3.Soldier can't move backward
                        {
                            return false;
                        }   return true;
                    }


                    if (GameBoard.posy2 < 10)//Rules for Soldier once they cross the river
                    {
                        if (GameBoard.posy == GameBoard.posy2 && System.Math.Abs(GameBoard.posx - GameBoard.posx2) > 2 || GameBoard.posx == GameBoard.posx2 && System.Math.Abs(GameBoard.posy - GameBoard.posy2) > 2 || GameBoard.posy - GameBoard.posy2 < 0)
                        {
                            return false;
                        }   return true;
                    }

                }
                else//Move rule for black Player's soldier
                {
                    if (GameBoard.posy2 <= 8)
                    {
                        if (GameBoard.posx != GameBoard.posx2 || GameBoard.posy2 - GameBoard.posy > 2 || GameBoard.posy2 - GameBoard.posy < 0)
                        {
                            return false;
                        }   return true;
                    }
                    if (GameBoard.posy2 > 8)
                    {
                        if (GameBoard.posy == GameBoard.posy2 && System.Math.Abs(GameBoard.posx - GameBoard.posx2) > 2 || GameBoard.posx == GameBoard.posx2 && System.Math.Abs(GameBoard.posy - GameBoard.posy2) > 2 || GameBoard.posy2 - GameBoard.posy < 0)
                        {
                            return false;
                        }   return true;
                    }
                }

            }return false;
            
        }

    }



}
















