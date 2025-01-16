public class TryAgain : Ability
{
    public TryAgain() : base ("TryAgain", 4)
    {

    }

    public override void Activate(Player Player, Token token)
    {
        token.TryAgain = true;
        // ver si tengo que tirar el dado como es
    }
}