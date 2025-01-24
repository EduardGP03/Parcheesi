class Entry : Cell
{
    Faction Color;

    public Entry(Faction color)
    {
        Color = color;
    }

    public override void ActivateEffect(Token token)
    {
        if (token.TokenFaction == Color)
        {
            token.Road = true;
            token.Position = 0;
        }
    }
}