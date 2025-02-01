using System.Collections.Generic;

public class Kill : Ability
{
    public Cell[] Cells { get; set; }
    public Kill(Cell[] cells) : base("Kiil", 4)
    {
        Cells = cells;
    }

    public override void Activate(Player Player, Token token)
    {
        List<Token> value = DistanceOfAbility(Cells, token);

        if (value != null)
            Killer(value);
    }

    private void Killer(List<Token> tokens)
    {
        if (!Chield(tokens))
        {
            tokens[0].Position = -1;
            tokens.Remove(tokens[0]);
        }

        else
            tokens[0].ProtectedEffect = false;
    }
}