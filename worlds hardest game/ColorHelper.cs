using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace worlds_hardest_game
{
    public static class ColorHelper
    {
        public static ConsoleColor GetCheckerColor(int x, int y)
        {
            return ((x + y % 2) % 2 == 0) ? ConsoleColor.White : ConsoleColor.Gray;
        }
    }
}

