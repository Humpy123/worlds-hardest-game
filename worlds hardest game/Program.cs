namespace worlds_hardest_game
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.CursorVisible = false;
            Board board;
            Game game;

            int level = 1;
            int deathCount = 0;

            while (true)
            {
                bool completed = false;
                switch (level)
                {
                    case 1:
                        board = new Board(60, 30, new SideToSideFactory());
                        game = new Game(board, level);
                        completed = game.Run(level, deathCount);
                        break;
                    case 2:
                        board = new Board(60, 30, new UpAndDownFactory());
                        game = new Game(board, level);
                        completed = game.Run(level, deathCount);
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
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
