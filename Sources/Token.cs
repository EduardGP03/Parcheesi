public class Token
{
    public Faction Type_faction;
    public Speed Speed { get; set; }
    private bool IsCooldownActive { get; set; }
    private int CooldownTime { get; set; }
    public Ability Ability { get; set; }
    public int Position;
    public int BasePosition; //ver si es esta o player quien la debe conocer
    public bool ProtectedToken;

    //public int CooldownTime { get; set; }
    //public string Name { get; set; }
    //public int PositionX { get; set; }
    //public int PositionY { get; set; }
    public Token(Faction faction, Ability ability, int BasePosition)
    {
        Type_faction = faction;
        Speed = new();
        Ability = ability;
        ProtectedToken = false;
        this.BasePosition=BasePosition;
    }

    // Mueve la ficha en el tablero
    public int GetTotalMove(int diceRoll)
    {
        int result = Speed.baseValue + diceRoll;

        foreach (var mod in Speed.ModifierswithDuration.Keys)
            result *= mod;

        return result;
    }
    public void Move(Cell[] cells, int Move)
    {
        int ActualPosition = Position;
        for (int i = 0; i < Math.Abs(Move); i++)
        {
            if(ActualPosition == -1) ActualPosition= cells.Length-1;
            if(ActualPosition == cells.Length) ActualPosition= 0;
            ActualPosition = (int.IsPositive(Move)) ? ActualPosition + 1 : ActualPosition - 1;
            if (cells[ActualPosition] is Wall)
            {
                cells[ActualPosition].ActivateEffect(this);
                break;
            }
        }
        Position= ActualPosition;
        cells[ActualPosition].ActivateEffect(this);

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


