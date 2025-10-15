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

            bool game = true;
            board.Print();
            while (game)
            {
                if (Console.KeyAvailable)
                {
                    
                    var key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.UpArrow) board.MovePlayer(0, -1);
                    else if (key == ConsoleKey.DownArrow) board.MovePlayer(0, 1);
                    else if (key == ConsoleKey.LeftArrow) board.MovePlayer(-1, 0);
                    else if (key == ConsoleKey.RightArrow) board.MovePlayer(1, 0);
                    else if(key == ConsoleKey.Escape) {game = false;};
                }


                //Console.Clear();
                board.PrintPlayer();
               // board.Print();

                Thread.Sleep(100);
               
            }

        }
    }
}
