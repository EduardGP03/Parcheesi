class Board
{
    public Player[] Players;
    public Cell[] Cells;
    private Dice DiceRoll;

    public Board()
    {
        StartGame(Players.Length);
    }

    static void StartGame(int cantPlayers)
    {
        Players = new Player[cantPlayers];
        Cells = new Cell[40];
        DiceRoll = new Dice();

        for (int i = 0; i < cantPlayers; i++)
        {
            Faction faction = (Faction)(i % 4); // Asignar una facción cíclicamente

            Players[i] = new Player(i, new List<Token>(), (Faction)i);

            // Inicializa tokens para cada jugador
            for (int j = 0; j < 4; j++)
            {
                Players[i].Tokens.Add(new Token(faction, null, 0)); // Ajusta Ability ver q habilidad poner
            }
        }

        HashSet<int> forbiddenPositions = new HashSet<int> { 1, 11, 21, 31, 8, 18, 28, 38 };
        List<int> availablePositions = new List<int>();

        for (int i = 0; i < Cells.Length; i++)
        {
            if (!forbiddenPositions.Contains(i))
                availablePositions.Add(i);
        }

        PlaceRandomCell(ref availablePositions, new Trap(), 3);
        PlaceRandomCell(ref availablePositions, new Wall(), 3);
        PlaceRandomCell(ref availablePositions, new CellToken(), 2);
    }

    public void NextTurn()
    {
        Player currentPlayer = Players[currentPlayerIndex];

        // Activar habilidades de los tokens
        foreach (var token in currentPlayer.Tokens)
        {
            if (!token.IsCooldownActive) // Verifica si la habilidad está disponible
            {
                // permitir al jugador elegir usar una habilidad
                //Console.WriteLine($"¿Deseas usar la habilidad del token {token.Type_faction}? (s/n)");
                string input = Console.ReadLine();
                if (input.ToLower() == "s")
                {
                    token.UseAbility(); // Usa la habilidad
                }
            }
        }

        // Lanzar el dado
        int diceRoll = Dice.Roll();
        //Console.WriteLine($"El jugador {currentPlayer.PlayerFaction} ha lanzado el dado y obtuvo: {diceRoll}");

        // permitir elegir qué token mover
        Token tokenToMove = currentPlayer.Tokens[0]; // Ejemplo: mover el primer token
        int totalMove = tokenToMove.GetTotalMove(diceRoll);
        tokenToMove.Move(Cells, totalMove);

        // Actualizar el estado del juego, como cooldowns de habilidades
        foreach (var token in currentPlayer.Tokens)
        {
            token.UpdateTurn(); // Actualiza cooldowns y estado del token
        }

        // Cambiar al siguiente jugador
        currentPlayerIndex = (currentPlayerIndex + 1) % Players.Length;
    }

    private static void PlaceRandomCell(ref List<int> availablePositions, Cell cellType, int count)
    {
        Random random = new Random();

        for (int i = 0; i < count; i++)
        {
            int randomIndex = random.Next(availablePositions.Count);
            int positionToPlace = availablePositions[randomIndex];

            // Almacena la instancia de la celda en la posición correspondiente
            Cells[positionToPlace] = cellType;

            availablePositions.RemoveAt(randomIndex);
        }
    }

    static void UpdateGame()
    {

    }
}




