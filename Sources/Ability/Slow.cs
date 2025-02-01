using System.Collections.Generic;

public class Slow : Ability
{
    public Cell[] Cells { get; set; }
    public Slow(Cell[] cells) : base("Slow", 3)
    {
        Cells = cells;
    }

    public override void Activate(Player Player, Token token)
    {
        List<Token> value = DistanceOfAbility(Cells, token);

        if (value != null)
            SlowToken(DistanceOfAbility(Cells, token));
    }

    private void SlowToken(List<Token> tokens)
    {
        if (!Chield(tokens))
            tokens[0].Speed.AddModifier(1 / 2, 2);

        else
            tokens[0].ProtectedEffect = false;
    }
}