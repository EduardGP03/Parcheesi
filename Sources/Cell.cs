using System.Collections.Generic;

public abstract class Cell
{
    public List<Token> Tokens;
    public abstract void ActivateEffect(Token token);

    public Cell()
    {
        Tokens = new List<Token>();
    }

}

