using System.Collections.Generic;

public abstract class Ability
{
    public string Name { get; set; }
    public int CooldownTime { get; set; }

    protected Ability(string name, int cooldownTime)
    {
        Name = name;
        CooldownTime = cooldownTime;
    }

    public abstract void Activate(Player Player, Token token); // Método que debe ser implementado por las habilidades concretas.

    public static List<Token> DistanceOfAbility(Cell[] cells, Token token)
    {
        for (int i = 1; i <= 3; i++)
        {
            int temp = token.Position + i;
            int position = temp < 40 ? temp : temp - 40;
            Cell cell = cells[position];
            var tokens = cell.Tokens;

            if (tokens.Count != 0 && tokens[0].TokenFaction != token.TokenFaction)
            {
                return tokens;
            }
        }

        return null;
    }

    public static bool Chield(List<Token> tokens)
    {
        return tokens[0].ProtectedEffect;
    }
}




