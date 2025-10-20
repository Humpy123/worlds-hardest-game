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
            printer.PrintStaggeredText(printer.enterText, printer.FindCenterX(printer.enterText), 17, ConsoleColor.DarkCyan);
            Console.ReadKey();

            Board b;
            Game game;
            int level = 1;

            while (true)
            {
                int deathCount = 0;
                bool completed = false;
                switch (level)
                {
                    case 1:
                        b = new Board(60, 30, new BasicEnemyFactory());
                        game = new Game(b, 1);
                        completed = game.Run();
                        break;
                    case 2:
                        b = new Board(60, 30, new BasicEnemyFactory());
                        game = new Game(b, 2);
                        completed = game.Run();
                        break;

                }

                if (completed)
                    level++;
                else
                    deathCount++;

            }
            



        }
    }
}
