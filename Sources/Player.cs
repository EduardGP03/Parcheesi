public class Player
{
    public Initial Start {get; set;}
    public List<Token> Tokens {get; set;}

    public Player(Initial start, List<Token> tokens )
    {
        Start = start;
        Tokens = tokens;
    }
}