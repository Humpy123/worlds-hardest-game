using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace worlds_hardest_game
{
    internal class TextHelper
    {
        public string enterText = "Press enter to start!";
        public string[] InGameLogo2 = new string[]
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


        public string[] IntroLogo = new string[]
        {
            " _____  _____ _   _  ___  ______ ___________ _   _ _____ _   _  ___________ ",
            "/  ___||  _  | | | |/ _ \\ | ___ \\  ___| ___ \\ | | /  ___| | | ||  ___| ___ \\",
            "\\ `--. | | | | | | / /_\\ \\| |_/ / |__ | |_/ / | | \\ `--.| |_| || |__ | |_/ /",
            " `--. \\| | | | | | |  _  ||    /|  __||  __/| | | |`--. \\  _  ||  __||    / ",
            "/\\__/ /\\ \\'/ / |_| | | | || |\\ \\| |___| |   | |_| /\\__/ / | | || |___| |\\ \\ ",
            "\\____/  \\_/\\_\\\\___/\\_| |_/\\_| \\_\\____/\\_|    \\___/\\____/\\_| |_/\\____/\\_| \\_|"
        };

        public void PrintLargeTextCentered(string[] artLines, ConsoleColor color, int y)
        {
            int startPoint = (Console.WindowWidth / 2) - (artLines[0].Length / 2);
            PrintLargeText(artLines, color, startPoint, y);
        }
        public Func<string, int> CenterTextX = s => (Console.WindowWidth / 2) - (s.Length / 2);
        public void PrintStaggeredText(string s, int x, int y, ConsoleColor color)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            for(int i = 0; i < s.Length; i++)
            {
                Console.Write(s[i]);
                Thread.Sleep(50);
            }
        }

        public void PrintLargeText(string[] artLines, ConsoleColor color, int x, int y)
        {
            Console.ForegroundColor = color;
            for (int i = 0; i < artLines.Length; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.WriteLine(artLines[i]);
                Thread.Sleep(50);
            }
        }
    }
}
