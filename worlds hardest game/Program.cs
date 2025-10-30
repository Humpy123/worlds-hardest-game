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
            Game game;

            int timeElapsed = 0;
            int level = 1;
            int deathCount = 0;
            bool gameRunning = true;


            //Fetch player name, limit to 20 characters
            string nameInput = PlayIntro();
            string playerName = nameInput.Length > 20 ? nameInput.Substring(0, 30) : nameInput;

            while (gameRunning)
            {
                bool completed = false;
                switch (level)
                {
                    case 1:
                        game = new Game(level);
                        var gameResult = game.Run(level, deathCount);
                        completed = gameResult.completed;
                        timeElapsed += gameResult.timeSpent;
                        break;
                    case 2:
                        game = new Game(level);
                        gameResult = game.Run(level, deathCount);
                        completed = gameResult.completed;
                        timeElapsed += gameResult.timeSpent;
                        break;
                    case 3:
                        game = new Game(level);
                        gameResult = game.Run(level, deathCount);
                        completed = gameResult.completed;
                        timeElapsed += gameResult.timeSpent;
                        break;
                    case 4: 
                        game = new Game(level);
                        gameResult = game.Run(level, deathCount);
                        completed = gameResult.completed;
                        timeElapsed += gameResult.timeSpent;
                        break;
                    case 5:
                        game = new Game(level);
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

            // Print game logo
            TextHelper.PrintLargeText
                (TextHelper.InGameLogo2,
                 ConsoleColor.DarkCyan,
                 Console.WindowWidth/2-42,
                 TextHelper.FindCenterY(TextHelper.InGameLogo2));

            // Run cube animation again
            var cts = new CancellationTokenSource();
            var cubeAnimation = TextHelper.RunCubeAnimation
               (cts.Token, (Console.WindowWidth/2+20), 8, 0, 0);

            Console.ReadKey();
        }
    }
}
