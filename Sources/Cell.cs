public abstract class Cell
{
    public Cell Previous { get; private set; }
    public Cell Next { get; set; }
    private List<Token> tokens;
    public abstract void Efect(Token token);

    public Cell(Cell previous, Cell next)
    {
        Previous = previous;
        Next = next;
    }

}

