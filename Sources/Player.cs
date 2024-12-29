public class Player
{
    public int PlayerStart {get; set;}
    public List<Token> Tokens {get; set;}
    public Faction PlayerFaction {get; set;}

    public Player(int playerStart, List<Token> tokens, Faction playerFaction )
    {
        PlayerStart = playerStart;
        Tokens = tokens;
        PlayerFaction = playerFaction;
    }
}