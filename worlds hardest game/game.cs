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
            board.PrintFullboard();
            while (!board.GameOver)
            {
                board.MoveEnemies();
                board.MovePlayer();
                board.PrintPlayer();
                board.PrintEnemies();

                board.IterateThroughCells();
                board.IterateThroughEnemies();

                Thread.Sleep(100);               
            }
        }
    }
}
