namespace worlds_hardest_game
{
    internal class Program
    {

        static void Main(string[] args)
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.CursorVisible = false;
            /*
            var printer = new TextHelper();
            printer.PrintLargeTextCentered(printer.IntroLogo, ConsoleColor.DarkCyan, 10);
            printer.PrintStaggeredText(printer.enterText, printer.FindCenterX(printer.enterText), 17, ConsoleColor.DarkCyan);
            Console.ReadKey();
            */

            Board b;
            Game game;
            int level = 1;
            int deathCount = 0;

            while (true)
            {
                bool completed = false;
                switch (level)
                {
                    case 1:
                        b = new Board(60, 30, new SideToSideFactory());
                        game = new Game(b, level);
                        completed = game.Run(level, deathCount);
                        break;
                    case 2:
                        b = new Board(60, 30, new UpAndDownFactory());
                        game = new Game(b, level);
                        completed = game.Run(level, deathCount);
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
