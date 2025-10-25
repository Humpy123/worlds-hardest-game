using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace worlds_hardest_game
{
    internal class Program
    {
        static string PlayIntro()
        {
            TextHelper.PrintLargeText
                (TextHelper.IntroLogo, ConsoleColor.DarkCyan,
                 TextHelper.FindCenterX(TextHelper.IntroLogo[0]), 15, 30);

            Console.SetCursorPosition((Console.WindowWidth / 2), 23);

            TextHelper.PrintStaggeredText
            (TextHelper.nameQuery,
            TextHelper.FindCenterX(TextHelper.nameQuery),
            23, ConsoleColor.DarkCyan, 10);

            var cts = new CancellationTokenSource();
            var cubeAnimation = TextHelper.RunCubeAnimation
                (cts.Token, //token                           
                (Console.WindowWidth / 2)-16, //starting x of animation
                0, //starting y of animation
                (Console.WindowWidth / 2 + TextHelper.nameQuery.Length/2), //x to reset cursor to
                23);                                                     //y to reset cursor to

            var input = Console.ReadLine();
            cts.Cancel();
            return input;
        }

         static void Main(string[] args)
         {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.CursorVisible = false;
            Board board;
            Game game;

            int timeElapsed = 0;
            int level = 1;
            int deathCount = 0;
            bool gameRunning = true;


            // Fetch player name, limit to 30 characters
            string nameInput = PlayIntro();
            string playerName = nameInput.Length > 30 ? nameInput.Substring(0, 30) : nameInput;

            while (gameRunning)
            {
                bool completed = false;
                switch (level)
                {
                    case 1:
                        board = new Board(60, 30, new LargeEnemyFactory(new DVDMovement()));
                        game = new Game(board, level);
                        var gameResult = game.Run(level, deathCount);
                        completed = gameResult.completed;
                        timeElapsed += gameResult.timeSpent;
                        break;
                    case 2:
                        board = new Board(60, 30, new BasicEnemyFactory(new UpAndDownMovement()));
                        game = new Game(board, level);
                        gameResult = game.Run(level, deathCount);
                        completed = gameResult.completed;
                        timeElapsed += gameResult.timeSpent;
                        break;
                    case 3:
                        board = new Board(60, 30, new BasicEnemyFactory(new UpAndDownMovement()));
                        game = new Game(board, level);
                        gameResult = game.Run(level, deathCount);
                        completed = gameResult.completed;
                        timeElapsed += gameResult.timeSpent;
                        break;
                    case 4:
                        board = new Board(60, 30, new BasicEnemyFactory(new UpAndDownMovement()));
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
            // Add player to scores file
            Scores.Add(new PlayerFile(playerName), timeElapsed);





            // Print high scores
            Console.Clear();
            string hs = "High Scores";
            TextHelper.PrintStaggeredText(hs, TextHelper.FindCenterX(hs), 5, ConsoleColor.DarkCyan, 10);
            TextHelper.PrintHighScores();


            File.WriteAllLines(@"..\..\..\assets\asciiart\InGameLogo2.txt", TextHelper.InGameLogo2);
            File.WriteAllLines(@"..\..\..\assets\asciiart\IntroLogo.txt", TextHelper.IntroLogo);


            // Run cube animation again
            var cts = new CancellationTokenSource();
            var cubeAnimation = TextHelper.RunCubeAnimation
               (cts.Token, (Console.WindowWidth / 2 - 60), 8, 0, 0);

            Console.ReadLine();
        }
    }
}
