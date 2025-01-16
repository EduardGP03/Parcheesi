public class Token
{
    public Faction TokenFaction { get; set; }
    public Speed Speed { get; set; }
    public bool IsCooldownActive { get; set; }
    private int CooldownTime { get; set; }
    public Ability Ability { get; set; }
    public int Position { get; set; }
    public int BasePosition { get; set; }
    public bool ProtectedToken { get; set; }

    // Constructor
    public Token(Faction faction, Ability ability, int basePosition)
    {
        TokenFaction = faction;
        Speed = new Speed(1); // Inicializa Speed con un valor base
        Ability = ability;
        ProtectedToken = false;
        BasePosition = basePosition;
        Position = basePosition; // Inicializa la posición en el base position
        IsCooldownActive = false;
        CooldownTime = 0;
    }

    // Mueve la ficha en el tablero
    public int GetTotalMove(int diceRoll)
    {
        int result = Speed.BaseValue + diceRoll;

        // Aplica los modificadores
        foreach (var mod in Speed.ModifierswithDuration.Keys)
        {
            result += mod; // Cambiar a suma si quieres que los modificadores aumenten el movimiento
        }

        return result;
    }

    public void Move(Cell[] cells, int move)
    {
        
        int actualPosition = Position;
        cells[actualPosition].Tokens.Remove(this);

        for (int i = 0; i < Math.Abs(move); i++)
        {
            // Ajusta la posición
            actualPosition += (move > 0) ? 1 : -1;

            // Manejo de límites del tablero
            if (actualPosition < 0) actualPosition = cells.Length - 1;
            if (actualPosition >= cells.Length) actualPosition = 0;

            // Activar efecto si es una pared
            if (cells[actualPosition] is Wall)
            {
                cells[actualPosition].ActivateEffect(this);
                break;
            }
        }

        Position = actualPosition;
        cells[actualPosition].Tokens.Add(this);
        cells[actualPosition].ActivateEffect(this);

        Eat(cells[actualPosition], this);
    }

    // Usar la habilidad de la ficha
    public void UseAbility()
    {
        if (!IsCooldownActive && Ability != null)
        {
            IsCooldownActive = true;
            CooldownTime = Ability.CooldownTime;
            Console.WriteLine("Ability used");
            // Implementar lógica específica de la habilidad aquí
        }
    }

    // Actualizar el estado de la ficha en cada turno
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
        Speed.UpdateModifers();
    }

    public static void Eat(Cell cell, Token token)
    {
        foreach (var element in cell.Tokens)
        {
            if (element.TokenFaction != token.TokenFaction)
            {
                element.Position = -1;
                cell.Tokens.Remove(element);
            }
        }

        
    }
}
