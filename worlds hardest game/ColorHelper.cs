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

        private static void CheckerizeBackground(int x, int y)
        {
            Console.BackgroundColor = GetCheckerColor(x, y);
        }

        public static void FixColors(ICell cell, int x, int y)
        {
            if (cell is Empty)
                cell.Color = GetCheckerColor(x, y);


            if (cell.GetType().IsGenericType &&
            cell.GetType().GetGenericTypeDefinition() == typeof(GenericPickup<>))
                CheckerizeBackground(x, y);
        }

    }
}

