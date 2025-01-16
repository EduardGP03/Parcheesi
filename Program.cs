public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Bienvenido al juego de Parchís!");
        Console.Write("Ingrese el número de jugadores (2-4): ");
        int numberOfPlayers = int.Parse(Console.ReadLine());

        Board gameBoard = new Board();

        gameBoard.StartGame(numberOfPlayers);
        foreach(var element in gameBoard.Cells)
            Console.WriteLine(element);
        while (true)
        {
            gameBoard.NextTurn();
        }
    }
}
