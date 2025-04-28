using System;

public class Manager
{
    private Board board;
    private bool winner;
    private short playercolour=1;
    private short enemycolour=-1;
    private short lastcolour=0;

    public Manager()
    {
        this.board=new Board();
    }

    /*
     * Allows the player to make a move in the specified column. 
     * returns a bool representing the validity fo the move.
     */
    public bool PlayerMove(int col)
    {
        Result r;
        r=this.board.MakeMove((short)col,this.playercolour);
        lastcolour=this.playercolour;
        if(r.legal)
        {
            if(this.board.Winner(r.col,r.row))
            {
                winner=true;
            }
            return true;
        }
        return false;
    }

    /*
     * same logic as playermove, but with randomly selected columns
     * runs until a legal move is made
     */
    public int EnemyMove()
    {
        System.Random rand=new System.Random();
        //make 42 random moves to guarantee a full game 
        Result r;
        do
        {
            short col=(short)rand.Next(0,7);
            r=this.board.MakeMove(col,this.enemycolour);
            lastcolour=this.enemycolour;
        }
        while(!r.legal);
        //we have a successful move
        if(this.board.Winner(r.col,r.row))
        {
            //end the game
            winner=true;
        }
        return (int)r.col;
    }

    public bool PlayerTurn()
    {
        return lastcolour!=playercolour;
    }

    public bool Winner()
    {
        return this.winner;
    }

    // just prints stuff. a macro to allow me to easily modify how everything prints.
    public static void PrintStuff(string s){Runner.PrintStuff(s);}
}
