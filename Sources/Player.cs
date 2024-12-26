class Player
{
    public int PlayerStart;
    public List<Token> Tokens;
    public Faction PlayerFaction;

    public Player(int playerStart, List<Token> tokens, Faction playerFaction )
    {
        PlayerStart = playerStart;
        Tokens = tokens;
        PlayerFaction = playerFaction;
    }
}