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

        static int CalculateScore(int timeInDeciSeconds, int deaths)
        {
            int denominator = 1 + timeInDeciSeconds/10 + (deaths * 30);
            return 50000 / denominator;
        }

         static void Main(string[] args)
         {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.CursorVisible = false;
            RoundSession round;

            int timeElapsed = 0;
            int level = 1;
            int deathCount = 0;
            bool gameRunning = true;


            //Fetch player name, limit to 20 characters
            string nameInput = PlayIntro();
            string playerName = nameInput.Length > 20 ? nameInput.Substring(0, 20) : nameInput;

            while (gameRunning)
            {
                bool completed = false;
                switch (level)
                {
                    case 1:
                        round = new RoundSession(level);
                        var gameResult = round.Run(level, deathCount);
                        completed = gameResult.completed;
                        timeElapsed += gameResult.timeSpent;
                        break;
                    case 2:
                        round = new RoundSession(level);
                        gameResult = round.Run(level, deathCount);
                        completed = gameResult.completed;
                        timeElapsed += gameResult.timeSpent;
                        break;
                    case 3:
                        round = new RoundSession(level);
                        gameResult = round.Run(level, deathCount);
                        completed = gameResult.completed;
                        timeElapsed += gameResult.timeSpent;
                        break;
                    case 4: 
                        round = new RoundSession(level);
                        gameResult = round.Run(level, deathCount);
                        completed = gameResult.completed;
                        timeElapsed += gameResult.timeSpent;
                        break;
                    case 5:
                        round = new RoundSession(level);
                        gameResult = round.Run(level, deathCount);
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
            int playerScore = CalculateScore(timeElapsed, deathCount);
            Scores.Add(new PlayerFile(playerName, playerScore));

            // Print Player score
            Console.Clear();
            string seehighscore = "Press ENTER to see high scores";
            string welldone =
                ("Well done, " + playerName + " You completed SQUAREPUSHER with a score of " + playerScore);
            TextHelper.PrintStaggeredText
                (welldone, TextHelper.FindCenterX(welldone), 10, ConsoleColor.DarkCyan, 10);

            TextHelper.PrintStaggeredText
                (seehighscore, TextHelper.FindCenterX(seehighscore), 14, ConsoleColor.DarkCyan, 10);
            Console.ReadKey();

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

            Console.ReadKey();
        }
    }
}
