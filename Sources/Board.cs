public class Board
{
    public Player[] Players;
    public Cell[] Cells;
    private Dice DiceRoll;
    private int currentPlayerIndex;

    public Board(int numberOfPlayers)
    {
        StartGame(numberOfPlayers);
    }

    private void StartGame(int cantPlayers)
    {
        Players = new Player[cantPlayers];
        Cells = new Cell[40];
        DiceRoll = new Dice();

        for (int i = 0; i < cantPlayers; i++)
        {
            Faction faction = (Faction)(i % 4); // Asignar una facción cíclicamente
            Players[i] = new Player(i, new List<Token>(), faction);

            for (int j = 0; j < 4; j++)
            {
                Players[i].Tokens.Add(new Token(faction, null, 0)); // Ajusta Ability según sea necesario
            }
        }

        HashSet<int> forbiddenPositions = new HashSet<int> { 1, 11, 21, 31, 8, 18, 28, 38 };
        List<int> availablePositions = new List<int>();

        for (int i = 0; i < Cells.Length; i++)
        {
            if (!forbiddenPositions.Contains(i))
                availablePositions.Add(i);
        }

        // Definir los tipos de celdas y sus cantidades
        Dictionary<Cell, int> cellTypes = new Dictionary<Cell, int>
    {
        { new Trap0((1, 2)), 1 }, // Una instancia de Trap0
        { new Trap1(Cells), 1 }, // Una instancia de Trap1
        { new Trap2(), 1 },       // Una instancia de Trap2
        { new Wall(3, (1, 2)), 3 }, // Tres muros
        { new CellToken0((1, 2)), cantPlayers * 2 } // Dos celdas de token por jugador
    };

        // Llama al método para colocar las celdas
        PlaceCells(cellTypes, ref availablePositions);
    }

    private void PlaceCells(Dictionary<Cell, int> cellTypes, ref List<int> availablePositions)
    {
        foreach (var cellType in cellTypes)
        {
            PlaceRandomCell(ref availablePositions, cellType.Key, cellType.Value);
        }
    }

    private void PlaceRandomCell(ref List<int> availablePositions, Cell cellType, int count)
    {
        Random random = new Random();

        for (int i = 0; i < count; i++)
        {
            if (availablePositions.Count == 0) break; // Verifica si hay posiciones disponibles

            int randomIndex = random.Next(availablePositions.Count);
            int positionToPlace = availablePositions[randomIndex];

            Cells[positionToPlace] = cellType; // Almacena la instancia de la celda en la posición correspondiente
            availablePositions.RemoveAt(randomIndex);
        }
    }

    public void NextTurn()
    {
        Player currentPlayer = Players[currentPlayerIndex];

        // Activar habilidades de los tokens
        foreach (var token in currentPlayer.Tokens)
        {
            if (!token.IsCooldownActive) // Verifica si la habilidad está disponible
            {
                // Permitir al jugador elegir usar una habilidad
                Console.WriteLine($"¿Deseas usar la habilidad del token {token.TokenFaction}? (s/n)");
                string input = Console.ReadLine();
                if (input.ToLower() == "s")
                {
                    token.UseAbility(); // Usa la habilidad
                }
            }
        }

        // Lanzar el dado
        int diceRoll = DiceRoll.Roll();
        Console.WriteLine($"El jugador {currentPlayer.PlayerFaction} ha lanzado el dado y obtuvo: {diceRoll}");

        // Mostrar las fichas del jugador y permitir que elija una para mover
        Console.WriteLine($"Jugador {currentPlayer.PlayerFaction}, elige una ficha para mover:");

        for (int i = 0; i < currentPlayer.Tokens.Count; i++)
        {
            Console.WriteLine($"{i + 1}. Ficha {i + 1}: Posición actual {currentPlayer.Tokens[i].Position}");
        }

        int selectedTokenIndex;

        while (true)
        {
            Console.Write("Selecciona el número de la ficha que deseas mover: ");
            if (int.TryParse(Console.ReadLine(), out selectedTokenIndex) &&
                selectedTokenIndex > 0 && selectedTokenIndex <= currentPlayer.Tokens.Count)
            {
                break; // Salir del bucle si se selecciona un índice válido
            }
            Console.WriteLine("Selección no válida. Intenta de nuevo.");
        }

        Token tokenToMove = currentPlayer.Tokens[selectedTokenIndex - 1]; // Seleccionar la ficha elegida
        int totalMove = tokenToMove.GetTotalMove(diceRoll);

        tokenToMove.Move(Cells, totalMove); // Mover la ficha seleccionada

        // Actualizar el estado del juego
        foreach (var token in currentPlayer.Tokens)
        {
            token.UpdateTurn(); // Actualiza cooldowns y estado del token
        }

        // Cambiar al siguiente jugador
        currentPlayerIndex = (currentPlayerIndex + 1) % Players.Length;
    }
}
