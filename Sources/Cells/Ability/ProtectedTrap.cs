public class ProtectedTrap : Ability
{
    public ProtectedTrap() : base("ProtectedTrap", 3)
    {

    }

    public override void Activate(Player Player, Token token)
    {
        token.ProtectedTrap = true;
    }
}