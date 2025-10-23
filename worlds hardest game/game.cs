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

        public (bool completed, int timeSpent) Run(int level, int deaths)
        {
            int timer = 0;

            board.PrintFullboard();
            TextHelper.PrintSideText(level, deaths);

            var lastUpdate = DateTime.Now;
            var updateInterval = TimeSpan.FromMilliseconds(100);

            while (!board.GameOver)
            {
                Console.SetCursorPosition(1, 1);
                board.Debug();

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
