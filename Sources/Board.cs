class Board
{
    public Player[] Players = new Player[40];
    public Cell[] Cells = new Cell[40];


    public Board()
    {
        StartGame(Players.Length);
    }
    static void StartGame(int cantPlayers)
    {
        Players = new Player[cantPlayers];
        Cells = new Cell[40];

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




