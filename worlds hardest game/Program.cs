namespace worlds_hardest_game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EndZone test = new EndZone();
            Board b = new Board(60, 30);
            b.AddCell(test, 5, 8);
            b.PrintFullboard();

            Game game = new Game(b);
            game.Run();
        }
    }
}
