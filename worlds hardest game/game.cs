using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace worlds_hardest_game
{
    internal class Game
    {
        private Board board;

        public Game(Board board, int level)
        {
            this.board = board;
            LevelManager.SetupLevel(this.board, level);
        }




        public bool Run(int level, int deaths)
        {
            var printer = new TextHelper();

            board.PrintFullboard();
            printer.PrintLargeText(printer.InGameLogo2, ConsoleColor.DarkCyan, 62, 3);
            Console.SetCursorPosition(63, 13);
            Console.WriteLine("Level: " + level);
            Console.SetCursorPosition(63, 14);
            Console.WriteLine("Deaths: " + deaths);

            var lastUpdate = DateTime.Now;
            var updateInterval = TimeSpan.FromMilliseconds(80);

            while (!board.GameOver)
            {
                Console.SetCursorPosition(1, 1);
                board.DebugCellType(30, 15);

                // Handle input as fast as possible
                board.MovePlayer();
                board.PrintPlayer();
                board.IterateThroughEnemies();

                // Only update enemies and redraw every 100ms
                if (DateTime.Now - lastUpdate >= updateInterval)
                {
                    board.MoveAndPrintEnemies();
                    board.CheckPlayerCell();

                    board.Player.Immunity--;
                    lastUpdate = DateTime.Now;
                }
            }

            return board.LevelCompleted;
        }

    }
}
