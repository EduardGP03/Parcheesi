class Player
{
    public Cell PlayerStart;
    public List<Token> Tokens;
    public Faction PlayerFaction;

    public Player(Cell playerStart, List<Token> tokens, Faction playerFaction )
    {
        PlayerStart = playerStart;
        Tokens = tokens;
        PlayerFaction = playerFaction;
    }
}