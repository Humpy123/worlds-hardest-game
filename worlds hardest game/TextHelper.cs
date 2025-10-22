using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace worlds_hardest_game
{
    static class TextHelper
    {
        static public string enterText = "Press enter to start!";
        static public string[] InGameLogo2 = new string[]
        {
            "  __   _       _  __  ___",
            " (_ ` / ) / / /_) )_) )_  ",
            ".__) (_X (_/ / / / \\ (__  ",
            "                          ",
            " __       __      ___ __  ",
            " )_) / / (_ ` )_) )_  )_) ",
            "/   (_/ .__) ( ( (__ / \\  ",
            "                          "
        };

        static public void PrintCoinCount(int coinCount)
        {
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(21, 8);
            Console.WriteLine("Coins Remaining: " + coinCount);
            Console.ResetColor();
        }


        static public void ShieldActivated()
        {
            Console.SetCursorPosition(30, 5);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("SHIELD ACTIVATED!");
        }

        static public string[] IntroLogo = new string[]
        {
            " _____  _____ _   _  ___  ______ ___________ _   _ _____ _   _  ___________ ",
            "/  ___||  _  | | | |/ _ \\ | ___ \\  ___| ___ \\ | | /  ___| | | ||  ___| ___ \\",
            "\\ `--. | | | | | | / /_\\ \\| |_/ / |__ | |_/ / | | \\ `--.| |_| || |__ | |_/ /",
            " `--. \\| | | | | | |  _  ||    /|  __||  __/| | | |`--. \\  _  ||  __||    / ",
            "/\\__/ /\\ \\'/ / |_| | | | || |\\ \\| |___| |   | |_| /\\__/ / | | || |___| |\\ \\ ",
            "\\____/  \\_/\\_\\\\___/\\_| |_/\\_| \\_\\____/\\_|    \\___/\\____/\\_| |_/\\____/\\_| \\_|"
        };

        static public void PrintLargeTextCentered(string[] artLines, ConsoleColor color, int y)
        {
            int startPoint = (Console.WindowWidth / 2) - (artLines[0].Length / 2);
            PrintLargeText(artLines, color, startPoint, y);
        }
        static public Func<string, int> FindCenterX = s => (Console.WindowWidth / 2) - (s.Length / 2);
        static public void PrintStaggeredText(string s, int x, int y, ConsoleColor color)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            for(int i = 0; i < s.Length; i++)
            {
                Console.Write(s[i]);
                Thread.Sleep(50);
            }
        }

        static public void PrintLargeText(string[] artLines, ConsoleColor color, int x, int y)
        {
            Console.ForegroundColor = color;
            for (int i = 0; i < artLines.Length; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.WriteLine(artLines[i]);
                Thread.Sleep(50);
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
    }
}
