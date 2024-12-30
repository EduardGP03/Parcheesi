class Entry : Cell
{
    Faction Color;
    Cell[] FinalRoad;
    Cell FactionBox;

    public Entry(Faction color, Cell[] finalRoad)
    {
        Color = color;
        FinalRoad = finalRoad;
    }

    public override void ActivateEffect(Token token)
    {
        if (token.TokenFaction == Color) token.Position = 0;
    }
}