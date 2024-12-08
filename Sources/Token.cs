public class Token
{
    public Faction Type_faction;
    public int Speed { get; set; }
    public bool IsCooldownActive { get; set; }
    public Ability Ability { get; set; }

    public Cell Position;

    //public int CooldownTime { get; set; }
    //public string Name { get; set; }
    //public int PositionX { get; set; }
    //public int PositionY { get; set; }
    public Token(Faction faction, int speed, Ability ability)
    {
        Type_faction = faction;
        Speed = speed;
        Ability = ability;
    }

    // Mueve la ficha en el tablero
    public Cell? Move(Cell cell, int move)
    {
        if (move == 0)
        {
            if (cell.type_cell == Type.wall) return cell;
            
            else return null;
        }

        return Move(cell.GetNext(), move - 1);
    }

    // Usa la habilidad de la ficha
    public void UseAbility()
    {
        if (!IsCooldownActive)
        {
            IsCooldownActive = true;
            CooldownTime = Ability.CooldownTime;
            // Implementar lógica de la habilidad
            Console.WriteLine("Ability used");
        }
    }

    // Actualiza el estado de la ficha en cada turno
    public void UpdateTurn()
    {
        if (IsCooldownActive)
        {
            CooldownTime--;
            if (CooldownTime <= 0)
            {
                IsCooldownActive = false;
                CooldownTime = 0;
            }
        }
    }

}
public enum Faction { red, yellow, blue, green }



// public Token(string name, int speed, int cooldownTime, Ability ability)
// {
//     Name = name;
//     Speed = speed;
//     CooldownTime = cooldownTime;
//     Ability = ability;
//     IsCooldownActive = false;
// }


