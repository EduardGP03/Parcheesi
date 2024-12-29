public abstract class Cell
{
    private List<Token> Tokens;
    public abstract void ActivateEffect(Token token);

    public Cell()
    {
        Tokens = new List<Token>();
    }

}

