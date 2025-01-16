using System.Runtime.InteropServices;

public class Board
{
    public Player[] Players;
    public Cell[] Cells;
    private Dice DiceRoll;
    private int currentPlayerIndex;

    public Board()
    {

    }

    public void StartGame(int cantPlayers)
    {
        Players = new Player[cantPlayers];
        Cells = new Cell[40];
        DiceRoll = new Dice();
        Initial[] ini = Ini();

        for (int i = 0; i < cantPlayers; i++)
        {
            Faction faction = (Faction)(i % 4); // Asignar una facción cíclicamente
            Players[i] = new Player(ini[i], new List<Token>());

            for (int j = 0; j < 4; j++)
            {
                Players[i].Tokens.Add(new Token(faction, null, -1)); // Ajusta Ability según sea necesario
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
            { new CellToken0((1, 2)), cantPlayers * 2 }, // Dos celdas de token por jugador
            { new Normal(), availablePositions.Count - (6 + cantPlayers * 2)}
        };

        // Llama al método para colocar las celdas
        PlaceCells(cellTypes, ref availablePositions);

        Cells[1] = new Exit();
        Cells[11] = new Exit();
        Cells[21] = new Exit();
        Cells[31] = new Exit();
        Cells[8] = new Entry(Faction.red, new Normal[3]);
        Cells[18] = new Entry(Faction.yellow, new Normal[3]);
        Cells[28] = new Entry(Faction.blue, new Normal[3]);
        Cells[38] = new Entry(Faction.green, new Normal[3]);
    }

    public Initial[] Ini()
    {
        Initial[] ini =
        {
            new Initial(1, 38, Faction.red),
            new Initial(11, 8, Faction.yellow),
            new Initial(21, 18, Faction.blue),
            new Initial(31, 28, Faction.green)
        };

        return ini;
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

        // Mostrar las fichas del jugador y sus habilidades
        Console.WriteLine($"Turno del jugador {currentPlayer.Start.Color}:");
        for (int i = 0; i < currentPlayer.Tokens.Count; i++)
        {
            Token token = currentPlayer.Tokens[i];
            Console.WriteLine($"{i + 1}. Ficha {i + 1} (Posición: {token.Position}) - Habilidad: {token.Ability?.Name ?? "Ninguna"}");
        }

        // Opción para usar habilidades
        while (true)
        {
            Console.WriteLine("¿Deseas usar alguna habilidad? (s/n)");
            string useAbilityInput = Console.ReadLine().ToLower();

            if (useAbilityInput == "s")
            {
                Console.WriteLine("Selecciona las habilidades que deseas activar (separadas por comas):");
                Console.WriteLine("Ejemplo: 1,2 para activar la habilidad de la ficha 1 y 2.");
                string abilitySelection = Console.ReadLine();
                string[] selectedIndices = abilitySelection.Split(',');

                foreach (string index in selectedIndices)
                {
                    if (int.TryParse(index.Trim(), out int selectedIndex) &&
                        selectedIndex > 0 && selectedIndex <= currentPlayer.Tokens.Count)
                    {
                        Token token = currentPlayer.Tokens[selectedIndex - 1];
                        token.Ability?.Activate(token); // Activa la habilidad si existe
                    }
                    else
                    {
                        Console.WriteLine($"Índice no válido: {index}");
                    }
                }
            }
            else if (useAbilityInput == "n")
            {
                break; // Salir del bucle si no se desean usar habilidades
            }
            else
            {
                Console.WriteLine("Opción no válida. Por favor, ingresa 's' o 'n'.");
            }
        }

        // Lanzar el dado
        int diceRoll = DiceRoll.Roll();
        bool[] validTokens = ValidToken(currentPlayer.Tokens, diceRoll);
        Console.WriteLine($"El jugador {currentPlayer.Start.Color} ha lanzado el dado y obtuvo: {diceRoll}");

        // Mover una ficha como antes
        Console.WriteLine($"Jugador {currentPlayer.Start.Color}, elige una ficha para mover:");

        for (int i = 0; i < currentPlayer.Tokens.Count; i++)
        {
            string valid = validTokens[i] ? "valid" : "invalid";
            Console.WriteLine($"{i + 1}. Ficha {i + 1}: Posición actual {currentPlayer.Tokens[i].Position} : {valid}");
        }

        int selectedTokenIndex;

        while (true)
        {
            Console.Write("Selecciona el número de la ficha que deseas mover: ");
            if (int.TryParse(Console.ReadLine(), out selectedTokenIndex) &&
                selectedTokenIndex > 0 && selectedTokenIndex <= currentPlayer.Tokens.Count && validTokens[selectedTokenIndex - 1])
            {
                break; // Salir del bucle si se selecciona un índice válido
            }
            Console.WriteLine("Selección no válida. Intenta de nuevo.");
        }

        Token tokenToMove = currentPlayer.Tokens[selectedTokenIndex - 1]; // Seleccionar la ficha elegida
        int totalMove = tokenToMove.GetTotalMove(diceRoll);
        Console.WriteLine(totalMove);

        if(tokenToMove.Position == -1)
        {
            tokenToMove.Position = currentPlayer.Start.Exit;
        }

        tokenToMove.Move(Cells, totalMove); // Mover la ficha seleccionada

        // Actualizar el estado del juego
        foreach (var token in currentPlayer.Tokens)
        {
            token.UpdateTurn(); // Actualiza cooldowns y estado del token
            int position = token.Position;
            Cell currentCell = Cells[position];

            Console.WriteLine(currentCell);

        }

        // Cambiar al siguiente jugador
        currentPlayerIndex = (currentPlayerIndex + 1) % Players.Length;
    }

    public void DisplayBoard()
    {
        Console.Clear(); // Limpiar la consola para redibujar el tablero

        Console.WriteLine("Tablero:");
        for (int i = 0; i < Cells.Length; i++)
        {
            if (Cells[i] != null)
            {
                Console.Write($"[{Cells[i].GetType().Name.Substring(0, 3)}] "); // Muestra el tipo de celda en forma abreviada.
            }
            else
            {
                Console.Write("[   ] "); // Espacio vacío en el tablero.
            }
        }
        Console.WriteLine(); // Nueva línea después del tablero.
    }

    public bool[] ValidToken(List<Token> tokens, int roll)
    {
        bool[] validToken = new bool[tokens.Count];

        for (int i = 0; i < tokens.Count; i++)
        {
            if (tokens[i].Position == -1 && roll != 5)
                validToken[i] = false;


            else
                validToken[i] = true;
        }

        return validToken;
    }
}


