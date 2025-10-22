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

            board.PrintFullboard();
            TextHelper.PrintSideText(level, deaths);

            var lastUpdate = DateTime.Now;
            var updateInterval = TimeSpan.FromMilliseconds(80);

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
                    
                    board.MoveAndPrintEnemies();

                    board.Player.Immunity--;
                    board.Frozen--;
                    lastUpdate = DateTime.Now;
                }
            }

            return board.IsLevelCompleted;
        }

    }
}
