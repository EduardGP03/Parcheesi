public class Boost : Ability
{
    public Boost() : base("Speed Boost", 3)
    {

    }

    public override void Activate(Player player, Token token)
    {
        token.Speed.AddModifier(2, 1); // Aumenta la velocidad por un turno.
    }
}