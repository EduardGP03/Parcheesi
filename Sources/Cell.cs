public abstract class Cell
{

    private List<Token> tokens;
    public abstract void ActivateEffect(Token token);

    public Cell()
    {
        tokens = new();
    }

}

