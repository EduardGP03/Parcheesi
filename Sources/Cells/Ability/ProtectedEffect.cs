public class ProtectedEffect : Ability
{
    public ProtectedEffect() : base("PorotectedEffect", 3)
    {

    }

    public override void Activate(Player Player, Token token)
    {
        token.ProtectedEffect = true;
    }
}