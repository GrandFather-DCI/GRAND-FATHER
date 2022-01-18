using System;


namespace GRAND_FATHER
{


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

        public bool OneStep()
        {
            if (System.Math.Abs(GameBoard.posx - GameBoard.posx2) == 2 && (GameBoard.posy - GameBoard.posy2) == 0 || (GameBoard.posx - GameBoard.posx2) == 0 && System.Math.Abs(GameBoard.posy - GameBoard.posy2) == 2)
            {
                return true;
            }
            return false;
        }

        public bool Logic()
        {
            if (GameBoard.board[GameBoard.posy2 / 2, GameBoard.posx2 / 2] == null || GameBoard.board[GameBoard.posy2 / 2, GameBoard.posx2 / 2].Side != GameBoard.board[GameBoard.posy / 2, GameBoard.posx / 2].Side)
            {
                return true;
            }
            return false;
        }

        public bool MoveInSquar()
        {
            if (GameBoard.posy2 > 4 && GameBoard.posy2 < 14 || GameBoard.posx2 < 6 || GameBoard.posx2 > 10)
            {
                return true;
            }
            return false;
        }
        public int XGap()
        {
            if (System.Math.Abs(GameBoard.posx - GameBoard.posx2) == 2)
            {
                return 2;
            }
            if (System.Math.Abs(GameBoard.posx - GameBoard.posx2) == 4)
            {
                return 4;
            }
            return 0;
        }

        public int YGap()
        {
            if (System.Math.Abs(GameBoard.posy - GameBoard.posy2) == 2)
            {
                return 2;
            }
            if (System.Math.Abs(GameBoard.posy - GameBoard.posy2) == 4)
            {
                return 4;
            }
            return 0;
        }

        public bool Vertical()
        {
            if (GameBoard.posx == GameBoard.posx2 && GameBoard.posy != GameBoard.posy2)
            {
                return true;
            }
            return false;
        }

        public bool Horizontal()
        {
            if (GameBoard.posy == GameBoard.posy2 && GameBoard.posx != GameBoard.posx2)
            {
                return true;
            }
            return false;
        }
        public Side Side { get; set; }
        public PieceTypes Type { get; set; }

        public override string ToString()
        {
            return "";
        }

        public virtual bool Move(int posx, int posy, int posx2, int posy2, ChessPiece[,] board)
        {
            return false;
        }

        public ChessPiece(Side side)
        {

            this.Side = side;
        }
    }



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

        public override bool Move(int posx, int posy, int posx2, int posy2, ChessPiece[,] board)
        {
            if (OneStep() == true)
            {
                if (Logic() == true)
                {
                    if (MoveInSquar() == true)
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
        public override bool Move(int posx, int posy, int posx2, int posy2, ChessPiece[,] board)
        {
            if (XGap() == 2 && YGap() == 2)
            {
                if (Logic() == true)
                {
                    if (MoveInSquar() == true)
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
        public override bool Move(int posx, int posy, int posx2, int posy2, ChessPiece[,] board)
        {
            if (XGap() == 4 && YGap() == 4)
            {
                if (Logic() == true)
                {
                    if (board[(posy / 2 + posy2 / 2) / 2, (posx / 2 + posx2 / 2) / 2] == null)
                    {    //Determine if there are chess pieces
                        if (board[posy / 2, posx / 2].Side == Side.black)
                        {
                            if (posy2 > 8)
                                return false;
                            else
                                return true;
                        }
                        else
                        {
                            if (posy2 < 10)
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

        public override bool Move(int posx, int posy, int posx2, int posy2, ChessPiece[,] board)
        {
            if (Logic() == true)
            {
                if (XGap() == 2 && YGap() == 4)
                {
                    if (board[(posy / 2 + posy2 / 2) / 2, posx / 2] != null)
                    {
                        return false;
                    }
                    return true;
                }
                else if (XGap() == 4 && YGap() == 2)
                {
                    if (board[posy / 2, (posx / 2 + posx2 / 2) / 2] != null)
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
        public override bool Move(int posx, int posy, int posx2, int posy2, ChessPiece[,] board)
        {
            int i,j,rangeChariot;
            if (Vertical() == true)//Chariot move in vertical way
            {
                i = posy < posy2 ? posy : posy2;//The x-coordinate of the starting point
                j = posy > posy2 ? posy : posy2;
                if (Logic() == true)
                {
                    for (rangeChariot= (i / 2) + 1; rangeChariot <= (j / 2) - 1; rangeChariot++)//Set a for loop to test whether there are pieces in its moving path
                    {
                        if (board[rangeChariot, posx / 2] != null)//Chariot can move when there are no pieces in its moving pat
                            return false;
                    }
                    return true;
                }
                //else if (board[posy2 / 2, posx2 / 2].Side == board[posy / 2, posx / 2].Side) 
                return false;
            }

            if (Horizontal() == true)//Chariot move in horizontal way
            {
                i = posx < posx2 ? posx : posx2;
                j = posx > posx2 ? posx : posx2;
                if (Logic() == true)
                {

                    for (rangeChariot = (i / 2) + 1; rangeChariot <= (j / 2) - 1;rangeChariot++)
                    {
                        if (board[posy / 2,rangeChariot] != null)
                            return false;
                    }
                    return true;

                }
                //else if (board[posy2 / 2, posx2 / 2].Side == board[posy / 2, posx / 2].Side) 
                return false;

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

        public override bool Move(int posx, int posy, int posx2, int posy2, ChessPiece[,] board)
        {
            int count = 0;
            int i, j, rangeCannon;
            if (Logic() == true)
            {
                if (Vertical() == true)
                {
                    i = posy < posy2 ? posy : posy2;
                    j = posy > posy2 ? posy : posy2;
                    for (rangeCannon = i / 2 + 1; rangeCannon < j / 2; rangeCannon++)
                    {
                        if (board[rangeCannon, posx2 / 2] != null)
                        {
                            count++;
                        }
                    }
                    if (count > 1)
                    {
                        return false;
                    }
                }
                else if (Horizontal() == true)
                {
                    i = posx < posx2 ? posx : posx2;
                    j = posx > posx2 ? posx : posx2;
                    for (rangeCannon = i / 2 + 1; rangeCannon < j / 2; rangeCannon++)
                    {
                        if (board[posy2 / 2, rangeCannon] != null)
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
                if (count == 0 && board[posy2 / 2, posx2 / 2] != null)
                {
                    return false;
                }
                if (count == 1 && board[posy2 / 2, posx2 / 2] == null)
                {
                    return false;
                }
                return true;
            }
            return false;

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

        public override bool Move(int posx, int posy, int posx2, int posy2, ChessPiece[,] board)
        {
            if (Logic() == true)
            {
                if (board[posy / 2, posx / 2].Side == Side.red)
                {
                    if (posy2 >= 10)
                    {
                        if (posx != posx2 || posy - posy2 > 2 || posy - posy2 < 0)
                        {
                            return false;
                        }
                        return true;
                    }


                    if (posy2 < 10)
                    {
                        if (posy == posy2 && System.Math.Abs(posx - posx2) > 2 || posx == posx2 && System.Math.Abs(posy - posy2) > 2 || posy - posy2 < 0)
                        {
                            return false;
                        }
                        return true;
                    }

                }
                else
                {
                    if (posy2 <= 8)
                    {
                        if (posx != posx2 || posy2 - posy > 2 || posy2 - posy < 0)
                        {
                            return false;
                        }
                        return true;
                    }
                    if (posy2 > 8)
                    {
                        if (posy == posy2 && System.Math.Abs(posx - posx2) > 2 || posx == posx2 && System.Math.Abs(posy - posy2) > 2 || posy2 - posy < 0)
                        {
                            return false;
                        }
                        return true;
                    }
                }

            }
            return false;

        }

    }



}
















