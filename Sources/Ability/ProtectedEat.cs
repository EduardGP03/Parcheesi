public class ProtectedEat : Ability
{
    public ProtectedEat() : base("ProtectedEat", 3)
    {
         
    }

    public override void Activate(Player Player, Token token)
    {
        token.ProtectedEat = true;
    }
}