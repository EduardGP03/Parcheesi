public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Bienvenido al juego de Parchís!");
        Console.Write("Ingrese el número de jugadores (2-4): ");
        int numberOfPlayers = int.Parse(Console.ReadLine());

        Game game = new Game(new Board());

        game.StartGame(numberOfPlayers);
        foreach(var element in game.Maze.Cells)
           {
                if (game.Maze.Cell)
           }
           
            // Console.WriteLine(element);
        while (true)
        {
            game.UpdateBoard();
        }
    }
}
