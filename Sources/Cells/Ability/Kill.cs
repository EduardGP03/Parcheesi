public class Kill : Ability
{
    public Cell[] Cells { get; set; }
    public Kill(Cell[] cells) : base("Kiil", 4)
    {
        Cells = cells;
    }

    public override void Activate(Player Player, Token token)
    {
        for (int i = 1; i <= 3; i++)
        {
            int temp = token.Position + i;
            int position = temp < 40 ? temp : temp - 40;
            Cell cell = Cells[position];
            var tokens = cell.Tokens;

            if (tokens.Count != 0 && tokens[0].TokenFaction != token.TokenFaction)
            {
                Killer(tokens);
                break;
            }
        }
    }

    private void Killer(List<Token> tokens)
    {
        if (tokens[0].ProtectedEffect == false)
        {
            tokens[0].Position = -1;
            tokens.Remove(tokens[0]);
        }

        else
            tokens[0].ProtectedEffect = false;
    }
}