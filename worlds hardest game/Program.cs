namespace worlds_hardest_game
{
    internal class Program
    {

        static void Main(string[] args)
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.CursorVisible = false;

            var printer = new TextHelper();
            printer.PrintLargeTextCentered(printer.IntroLogo, ConsoleColor.DarkCyan, 10);
            printer.PrintStaggeredText(printer.enterText, printer.CenterTextX(printer.enterText), 17, ConsoleColor.DarkCyan);
            Console.ReadLine();
            Board b = new Board(60, 30, new BasicEnemyFactory());
            Game game = new Game(b);
            game.Run();
        }
    }
}
