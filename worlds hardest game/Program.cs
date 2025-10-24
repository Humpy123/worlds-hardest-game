using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

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

            int timeElapsed = 0;
            int level = 5;
            int deathCount = 0;
            bool gameRunning = true;

            Scores.InitList();
            TextHelper.PrintLargeTextCentered(TextHelper.IntroLogo, ConsoleColor.DarkCyan, 10);
            Console.SetCursorPosition(Console.WindowWidth / 2, 18);

            TextHelper.PrintStaggeredText(TextHelper.nameQuery, TextHelper.FindCenterX(TextHelper.nameQuery), 17, ConsoleColor.DarkCyan);

            string playerName = Console.ReadLine();

            while (gameRunning)
            {
                bool completed = false;
                switch (level)
                {
                    case 1:
                        board = new Board(60, 30, new SideToSideFactory());
                        game = new Game(board, level);
                        var gameResult = game.Run(level, deathCount);
                        completed = gameResult.completed;
                        timeElapsed += gameResult.timeSpent;
                        break;
                    case 2:
                        board = new Board(60, 30, new UpAndDownFactory());
                        game = new Game(board, level);
                        gameResult = game.Run(level, deathCount);
                        completed = gameResult.completed;
                        timeElapsed += gameResult.timeSpent;
                        break;
                    case 3:
                        board = new Board(60, 30, new UpAndDownFactory());
                        game = new Game(board, level);
                        gameResult = game.Run(level, deathCount);
                        completed = gameResult.completed;
                        timeElapsed += gameResult.timeSpent;
                        break;
                    case 4:
                        board = new Board(60, 30, new UpAndDownFactory());
                        game = new Game(board, level);
                        gameResult = game.Run(level, deathCount);
                        completed = gameResult.completed;
                        timeElapsed += gameResult.timeSpent;
                        break;
                    case 5:
                        BoardFetcher boardFetcher = new BoardFetcher();
                        board = boardFetcher.ReadImage(@"C:\Users\olive\source\repos\worlds hardest game\worlds hardest game\assets\boards\test.png");
                        game = new Game(board, level);
                        gameResult = game.Run(level, deathCount);
                        completed = gameResult.completed;
                        timeElapsed += gameResult.timeSpent;
                        break;
                    case 7:
                        boardFetcher = new BoardFetcher();
                        board = boardFetcher.ReadImage(@"C:\Users\olive\source\repos\worlds hardest game\worlds hardest game\assets\boards\level1.png");
                        game = new Game(board, level);
                        gameResult = game.Run(level, deathCount);
                        completed = gameResult.completed;
                        timeElapsed += gameResult.timeSpent;
                        break;
                    default:
                        gameRunning = false;
                        break;
                }

                if (completed)
                    level++;
                else
                    deathCount++;
            }
            Scores.Add(new PlayerFile(playerName), timeElapsed);
            foreach(var score in Scores.GetHighScores())
            {
                int scoreInDeciSecs = Convert.ToInt32(score.GameScore);
                Console.Write(score.Name + ":      " + scoreInDeciSecs/10 + "." + scoreInDeciSecs%10 + " Seconds");
                Console.WriteLine();
            }
        }
    }
}
