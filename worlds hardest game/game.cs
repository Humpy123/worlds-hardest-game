using System;
using System.Collections.Generic;
using System.Linq;
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
            while ()
            {
                board.Print();
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.UpArrow) board.MovePlayer(0, -1);
                else if (key == ConsoleKey.DownArrow) board.MovePlayer(0, 1);
                else if (key == ConsoleKey.LeftArrow) board.MovePlayer(-1, 0);
                else if (key == ConsoleKey.RightArrow) board.MovePlayer(1, 0);
            }
            board.Print();

            Console.WriteLine();
            Console.WriteLine("GAME OVER!");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
