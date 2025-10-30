using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace worlds_hardest_game
{
    internal class RoundSession
    {
        private Board board;

        public RoundSession(int level)
        {
            this.board = LevelManager.SetupLevel(level);
        }

        public (bool completed, int timeSpent) Run(int level, int deaths)
        {
            int timer = 0;

            board.PrintFullboard();
            TextHelper.PrintSideText(level, deaths);

            var lastUpdate = DateTime.Now;
            var updateInterval = TimeSpan.FromMilliseconds(100);

            while (!board.IsGameOver)
            {
                Console.SetCursorPosition(1, 1);

                // Handle input as fast as possible
                board.MovePlayer();
                board.PrintPlayer();
                board.CheckEnemyCollision();
                board.CheckPlayerCell();

                TextHelper.PrintCoinCount(board.CoinCount);

                // Only update enemies and redraw every 100ms
                if (DateTime.Now - lastUpdate >= updateInterval)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.SetCursorPosition(63, 15);
                    Console.WriteLine("Seconds elapsed: " + ++timer/10 + "." + timer%10);

                    board.MoveAndPrintEnemies();
                    board.Player.Immunity--;
                    lastUpdate = DateTime.Now;
                }
            }

            return (board.IsLevelCompleted, timer);
        }

    }
}
