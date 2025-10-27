using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace worlds_hardest_game
{
    static class TextHelper
    {


        public static async Task RunCubeAnimation(CancellationToken token, int x, int y, int returnX, int returnY)
        {
            int index = 0;
            while (!token.IsCancellationRequested)
            {
                string[] cube = File.ReadAllLines(
                    @"..\..\..\assets\asciiart\kub" + ((index++ % 6) + 1) + ".txt");

                TextHelper.PrintLargeText(cube, ConsoleColor.DarkCyan, x, y);

                Console.SetCursorPosition(returnX, returnY);

                await Task.Delay(120, token);
            }
        }

        static public string[] InGameLogo2 =
            File.ReadAllLines(@"..\..\..\assets\asciiart\InGameLogo2.txt");
        static public string[] IntroLogo =
            File.ReadAllLines(@"..\..\..\assets\asciiart\IntroLogo.txt");

        static public string nameQuery = "Enter your name:  ";

        static public void PrintCoinCount(int coinCount)
        {
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(21, 3);
            Console.WriteLine("Coins Remaining: " + coinCount);
            Console.ResetColor();
        }

        static public void PrintLargeTextCentered(string[] artLines, ConsoleColor color, int y)
        {
            int startPoint = (Console.WindowWidth / 2) - (artLines[0].Length / 2);
            PrintLargeText(artLines, color, startPoint, y);
        }
        static public Func<string, int> FindCenterX = s => (Console.WindowWidth / 2) - (s.Length / 2);
        static public Func<string[], int> FindCenterY = arr => (Console.WindowHeight / 2) - (arr.Length / 2);
        static public void PrintStaggeredText(string s, int x, int y, ConsoleColor color, int delayMs)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            for(int i = 0; i < s.Length; i++)
            {
                Console.Write(s[i]);
                Thread.Sleep(delayMs);
            }
        }

        static public void PrintLargeText(string[] artLines, ConsoleColor color, int x, int y, int lineDelayMs = 0)
        {
            Console.ForegroundColor = color;
            for (int i = 0; i < artLines.Length; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.WriteLine(artLines[i]);
                Thread.Sleep(lineDelayMs);
            }
        }
        static public void PrintSideText(int level, int deaths)
        {
            PrintLargeText(InGameLogo2, ConsoleColor.DarkCyan, 62, 3);
            Console.SetCursorPosition(63, 13);
            Console.WriteLine("Level: " + level);
            Console.SetCursorPosition(63, 14);
            Console.WriteLine("Deaths: " + deaths);
        }

        static public void PrintHighScores()
        {
            int scoreYCoord = 10;
            foreach (var playerScore in Scores.GetHighScores())
            {
                int scoreInDeciSecs = Convert.ToInt32(playerScore.GameScore);
                string totalScore = (scoreInDeciSecs / 10 + "." + scoreInDeciSecs % 10);

                TextHelper.PrintStaggeredText
                    (playerScore.Name, Console.WindowWidth / 2 - 10, ++scoreYCoord, ConsoleColor.DarkCyan, 10);
                TextHelper.PrintStaggeredText
                    (totalScore, Console.WindowWidth / 2 + 10, scoreYCoord, ConsoleColor.DarkCyan, 10);
                Console.WriteLine();
            }
        }
    }
}
