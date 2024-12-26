class Goal : Cell
{
    Faction Color;
    int Counter = 0;
    int TotalTokens;
    bool GameWinner;
    public Goal(Faction color, int totalTokens, Cell previous, Cell next) : base(null, null)
    {
        Color = color;
        TotalTokens = totalTokens;
    }

    public override void ActivateEffect(Token token)
    {
        Counter++;
        if(Counter == TotalTokens) GameWinner = true;
    }
}