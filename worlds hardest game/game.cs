using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace worlds_hardest_game
{
    internal class Game
    {
        private Board board;

        public Game(Board board) =>
            this.board = board;



        public void Run()
        {
            var level = new LevelCreator(board);

            level.MakeRectangle<Empty>(4, 10, 15, 20);
            level.MakeRectangle<EndZone>(45, 10, 56, 20);
            level.MakeRectangle<Empty>(18, 11, 42, 19);
            level.MakeRectangle<Empty>(14, 20, 20, 20);
            level.MakeRectangle<Empty>(40, 10, 44, 10);

            board.PrintFullboard();

            var lastUpdate = DateTime.Now;
            var updateInterval = TimeSpan.FromMilliseconds(100);

            while (!board.GameOver)
            {
                // Handle input as fast as possible
                board.MovePlayer();
                board.PrintPlayer();

                // Only update enemies and redraw every 100ms
                if (DateTime.Now - lastUpdate >= updateInterval)
                {
                    board.MoveEnemies();
                    board.PrintEnemies();
                    board.IterateThroughCells();
                    board.IterateThroughEnemies();

                    lastUpdate = DateTime.Now;
                }
            }
        }

    }
}
