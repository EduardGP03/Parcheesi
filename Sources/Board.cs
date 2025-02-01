public class Board
{
    public Player[] Players;
    public Cell[] Cells;
    public Dice DiceRoll;
    public int currentPlayerIndex;

    public Board()
    {
        Cells = new Cell[40];
    }

}


