class Entry : Cell
{
    Faction Color;
    Cell FactionBox;

    public Entry(Faction color, Cell factionBox, Cell previous, Cell next) : base(previous, next)
    {
        Color = color;
        FactionBox = factionBox;
    }

    public override void ActivateEffect(Token token)
    {
        if (token.Type_faction == Color) token.Position = FactionBox;
    }
}