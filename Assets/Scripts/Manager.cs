using System;

public class GameManager
{
    private Board board;

    public GameManager()
    {
        this.board = new Board();
    }

    /*
     * start the game of connect 4. currently unfinished
     */
    public void play()
    {
        //following code is from Litman, modified to fit my existing project
        Random rand=new Random();
        //make 10 random moves for testing
        for(int i=0;i<10;i++)
        {
            this.board.display();
            Result r;
            do
            {
                r=this.board.MakeMove((short)rand.Next(0,7),(short)Math.Pow(-1,(i%2)));
            }
            while(!r.legal);
            //we have a successful move
            //check to see if that move won the game
            if(this.board.Winner(r.col,r.row))
            {
                //someone won
            }
        }
        Console.WriteLine("finished test");
    }
}
