public class Board
{
    // checker short representation 0 is unfilled. -1 for black. 1 for red
    // 0 is bottom of board, 6 is top
    // 0 is right, 7 is left
    private Result [,] board;
    private short rows=6;
    private short cols=7;

    public Board()
    {
        this.board=new short[cols,rows];
    }

    /*
     * attempts to place a piece in a column. 
     * takes in the column and colour of the piece.
     * returns a Result with info about the move
     */
    public Result MakeMove(short col, short colour)
    {
        Result r=new Result();
        // if the column is a legal value and at least one space on the board is open
        if ((col>=0&&col<cols)&&(board[(int)col,6]==0))
        {
            //make the move
            for (int i=0; i<cols; i++)
            {
                if (board[(int)col,i]!=0)
                {
                    //fill out Result
                    r.legal=true;
                    r.row=i;
                    r.col=col;
                    r.colour=colour;  

                    //fill in place on board
                    board[(int)col,i]=r;
                }
            }
        } 
        else
        {
            //illegal move
            r.legal=false;
        }
        return r;
    }

    /*
     * check if there is a sequence of 4 moves including the piece at the passed row and column 
     * returns a bool indicating whether there is a winner
     */
    public bool Winner(short row, short col)
    {
        short c=0;
        short lc=0;

        //TODO: ensure loop stays within array bounds
        //check horizontally
        for (int i=col-4; i<col+4; i++) 
        {
            lc=board[i,(int)row].Result.colour;
            short nc=board[i+1,(int)row].Result.colour;
            if((lc==nc)&&(nc!=0))
            {
                c++;
            }
            if(c>=4)
            {
                //we have a winner
                return true;
            }
        }
        c=0;
        lc=0;

        //check vertically
        for (int i=row-4; i<row+4; i++) 
        {
            lc=board[(int)col,i].Result.colour;
            short nc=board[(int)col,i+1].Result.colour;
            if((lc==nc)&&(nc!=0))
            {
                c++;
            }
            if(c>=4)
            {
                //we have a winner
                return true;
            }
        }

        //check horizontally (top left to bottom right)

        //check horizontally (top right to bottom left)
    }
}
