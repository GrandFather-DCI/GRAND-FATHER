using System;


namespace Xiangqi01
{


    public enum Side
    {
        red,
        black,
        blank,

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
        blank,
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


        public virtual string SelcetChess()
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


    public class blank : ChessPiece
    {
        public blank(Side side) : base(side)
        {
            this.Type = PieceTypes.blank;
        }
        public override String ToString()
        {
            return "..\\..\\..\\Resource\\blank.png";
        }

        public override string SelcetChess()
        {
            return "..\\..\\..\\Resource\\select.png";
        }

        public override bool Move(int posx, int posy, int posx2, int posy2, ChessPiece[,] board)
        {
            return true;
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
            if (Side == Side.black) { return "..\\..\\..\\Resource\\BlackGeneral.png"; }
            else { return "..\\..\\..\\Resource\\RedGeneral.png"; }
        }

        public override string SelcetChess()
        {
            if (Side == Side.black) { return "..\\..\\..\\Resource\\BlackGeneralSelect.png"; }
            else { return "..\\..\\..\\Resource\\RedGeneralSelect.png"; }
        }



        public override bool Move(int posx, int posy, int posx2, int posy2, ChessPiece[,] board)
        {
            if (System.Math.Abs(posx - posx2) == 1 && (posy - posy2) == 0 || (posx - posx2) == 0 && System.Math.Abs(posy - posy2) == 1)
            {
                if (board[posy2, posx2].Side == board[posy, posx].Side)
                    return false;
                 
                if (posy2 > 2 && posy2 < 7 || posx2 < 3 || posx2 > 5)
                    return false;
                    
                
                else return true;
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
            if (Side == Side.black) { return "..\\..\\..\\Resource\\BlackAdviser.png"; }
            else { return "..\\..\\..\\Resource\\RedAdviser.png"; }
        }

        public override string SelcetChess()
        {
            if (Side == Side.black) { return "..\\..\\..\\Resource\\BlackAdviserSelect.png"; }
            else {return "..\\..\\..\\Resource\\RedAdviserSelect.png";}
        }




        public override bool Move(int posx, int posy, int posx2, int posy2, ChessPiece[,] board)
        {
            if (System.Math.Abs(posx - posx2) == 1 && System.Math.Abs(posy - posy2) == 1)
            {
                if (board[posy2, posx2].Side != board[posy, posx].Side)
                {
                    if (posy2 > 2 && posy2 < 7 || posx2 < 3 || posx2 > 5)
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
            if (Side == Side.black) { return "..\\..\\..\\Resource\\BlackElephant.png"; }
            else { return "..\\..\\..\\Resource\\RedElephant.png"; }
        }

        public override string SelcetChess()
        {
            if (Side == Side.black) { return "..\\..\\..\\Resource\\BlackElephantSelect.png"; }
            else { return "..\\..\\..\\Resource\\RedElephantSelect.png"; }
        }


        public override bool Move(int posx, int posy, int posx2, int posy2, ChessPiece[,] board)
        {
            if (System.Math.Abs(posx - posx2) == 2 && System.Math.Abs(posy - posy2) == 2)
            {
                if (board[posy2, posx2].Side != board[posy, posx].Side)
                {
                    if (board[(posy + posy2) / 2, (posx + posx2) / 2].Side == Side.blank)
                    {    //Determine if there are chess pieces
                        if (board[posy, posx].Side == Side.black)
                        {
                            if (posy2 > 4)
                                return false;
                            else
                                return true;
                        }
                        else
                        {
                            if (posy2 < 5)
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
            if (Side == Side.black) { return "..\\..\\..\\Resource\\BlackHorse.png"; }
            else { return "..\\..\\..\\Resource\\RedHorse.png"; }
        }

        public override string SelcetChess()
        {
            if (Side == Side.black) { return "..\\..\\..\\Resource\\BlackHorseSelect.png"; }
            else { return "..\\..\\..\\Resource\\RedHorseSelect.png"; }
        }

        public override bool Move(int posx, int posy, int posx2, int posy2, ChessPiece[,] board)
        {
                if (board[posy2, posx2].Side == board[posy, posx].Side)
                return false;
                if (System.Math.Abs(posx - posx2) == 1 && System.Math.Abs(posy - posy2) == 2)
                {
                    if (board[(posy + posy2) / 2, posx].Side != Side.blank)
                    {
                        return false;
                    }
                    return true;
                }
                else if (System.Math.Abs(posx - posx2) == 2 && System.Math.Abs(posy - posy2) == 1)
                {
                    if (board[posy, (posx + posx2) / 2].Side != Side.blank)
                    {
                        return false;
                    }
                    return true;
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
            if (Side == Side.black) { return "..\\..\\..\\Resource\\BlackCar.png"; }
            else { return "..\\..\\..\\Resource\\RedCar.png"; }
        }

        public override string SelcetChess()
        {
            if (Side == Side.black) { return "..\\..\\..\\Resource\\BlackCarSelect.png"; }
            else { return "..\\..\\..\\Resource\\RedCarSelect.png"; }
        }

        public override bool Move(int posx, int posy, int posx2, int posy2, ChessPiece[,] board)
        {
            int i, j, rangeChariot;
            if (posx == posx2 && posy != posy2)//Chariot move in vertical way
            {
                i = posy < posy2 ? posy : posy2;//The x-coordinate of the starting point
                j = posy > posy2 ? posy : posy2;
                if (board[posy2, posx2].Side != board[posy, posx].Side)
                {
                    for (rangeChariot = (i ) + 1; rangeChariot <= (j ) - 1; rangeChariot++)//Set a for loop to test whether there are pieces in its moving path
                    {
                        if (board[rangeChariot, posx].Side != Side.blank)//Chariot can move when there are no pieces in its moving pat
                            return false;
                    }
                    return true;
                }
                //else if (board[posy2 / 2, posx2 / 2].Side == board[posy / 2, posx / 2].Side) 
                return false;
            }

            if (posx != posx2 && posy == posy2)//Chariot move in horizontal way
            {
                i = posx < posx2 ? posx : posx2;
                j = posx > posx2 ? posx : posx2;
                if (board[posy2, posx2].Side != board[posy, posx].Side)
                {

                    for (rangeChariot = (i) + 1; rangeChariot <= (j) - 1; rangeChariot++)
                    {
                        if (board[posy, rangeChariot].Side != Side.blank)
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
            if (Side == Side.black) { return "..\\..\\..\\Resource\\BlackCannon.png"; }
            else{ return "..\\..\\..\\Resource\\RedCannon.png"; }

        }

        public override string SelcetChess()
        {
            if (Side == Side.black) { return "..\\..\\..\\Resource\\BlackCannonSelect.png"; }
            else { return "..\\..\\..\\Resource\\RedCannonSelect.png"; }

        }

        public override bool Move(int posx, int posy, int posx2, int posy2, ChessPiece[,] board)
        {
            int count = 0;
            int i, j, rangeCannon;
            
                if (posx2 == posx)
                {
                    i = posy < posy2 ? posy : posy2;
                    j = posy > posy2 ? posy : posy2;
                    for (rangeCannon = i + 1; rangeCannon <= j -1; rangeCannon++)
                    {
                        if (board[rangeCannon, posx2].Side != Side.blank)
                        {
                            count++;
                        }
                    }
                    if (count > 1)
                    {
                        return false;
                    }
                    
                }
                else if (posy2 == posy)
                {
                    i = posx < posx2 ? posx : posx2;
                    j = posx > posx2 ? posx : posx2;
                    for (rangeCannon = i + 1; rangeCannon <= j - 1; rangeCannon++)
                    {
                        if (board[posy2, rangeCannon].Side != Side.blank)
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
                if (count == 0 && board[posy2, posx2].Side != Side.blank)
                    return false;
                
                if (count == 1 && board[posy2, posx2].Side == Side.blank)
                    return false;
                if (board[posy2, posx2].Side == board[posy, posx].Side)  //目的点是同一方的棋子
                    return false;

                return true;
            
            

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
            if (Side == Side.black) { return "..\\..\\..\\Resource\\BlackSoldier.png"; }
            else { return "..\\..\\..\\Resource\\RedSoldier.png"; }
        }

        public override string SelcetChess()
        {
            if (Side == Side.black) { return "..\\..\\..\\Resource\\BlackSoldierSelect.png"; }
            else { return "..\\..\\..\\Resource\\RedSoldierSelect.png"; }
        }

        public override bool Move(int posx, int posy, int posx2, int posy2, ChessPiece[,] board)
        {
                if (board[posy2, posx2].Side == board[posy, posx].Side)  //目的点是同一方的棋子
                        return false;
                if (board[posy, posx].Side == Side.red)
                {
                    if (System.Math.Abs(posx - posx2) > 0 && System.Math.Abs(posy - posy2) > 0)  
                        return false;
                    if (posy2 >= 5)
                    {
                        if (posx != posx2 || posy - posy2 > 1 || posy - posy2 < 0)
                        {
                            return false;
                        }
                        return true;
                    }


                    if (posy2 < 5)
                    {
                        if (posy == posy2 && System.Math.Abs(posx - posx2) > 1 || posx == posx2 && System.Math.Abs(posy - posy2) > 1 || posy - posy2 < 0)
                        {
                            return false;
                        }
                        return true;
                    }
                    

                }
                else
                {
                    if (System.Math.Abs(posx - posx2) > 0 && System.Math.Abs(posy - posy2) > 0)  
                        return false;
                    if (posy2 <= 4)
                    {
                        if (posx != posx2 || posy2 - posy > 1 || posy2 - posy < 0)
                        {
                            return false;
                        }
                        return true;
                    }
                    if (posy2 > 4)
                    {
                        if (posy == posy2 && System.Math.Abs(posx - posx2) > 1 || posx == posx2 && System.Math.Abs(posy - posy2) > 1 || posy2 - posy < 0)
                        {
                            return false;
                        }
                        return true;
                    }
                }
            return false;

        }

    }



}


