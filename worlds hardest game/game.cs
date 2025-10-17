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


        string[] InGameLogo = new string[]
        {
            "                /    ",
            "| | _  __ |  _|    _ ",
            "|^|(_) |  | (_|   _> ",
            "                     ",
            "|_| _  __ _| _  _ _|_",
            "| |(_| | (_|(/__>  |_",
            " __                  ",
            "/__ _ __  _          ",
            "\\_|(_||||(/_         "
        };




        public void Run()
        {
            var printer = new TextHelper();
            var level = new LevelCreator(board);

            level.MakeRectangle<Empty>(4, 10, 15, 20); //Start Zone
            level.MakeRectangle<EndZone>(45, 10, 56, 20); //End Zone
            level.MakeRectangle<Empty>(18, 11, 42, 19); // Middle
            level.MakeRectangle<Empty>(14, 20, 20, 20); // Left corridor
            level.MakeRectangle<Empty>(40, 10, 44, 10); // Right corridor

            for(int i = 11; i <= 19; i++)
            {
                if(i%2==0)
                    board.AddEnemy(42, i);
                else
                    board.AddEnemy(18, i);
            }


            board.PrintFullboard();
            printer.PrintLargeText(printer.InGameLogo2, ConsoleColor.DarkCyan, 62, 3);
            Console.SetCursorPosition(63, 13);
            Console.WriteLine("Level: " + "1");

            var lastUpdate = DateTime.Now;
            var updateInterval = TimeSpan.FromMilliseconds(80);

            while (!board.GameOver)
            {
                // Handle input as fast as possible
                board.MovePlayer();
                board.PrintPlayer();
                board.IterateThroughEnemies();

                // Only update enemies and redraw every 100ms
                if (DateTime.Now - lastUpdate >= updateInterval)
                {
                    board.MoveAndPrintEnemies();
                    board.IterateThroughCells();


                    lastUpdate = DateTime.Now;
                }
            }
        }

    }
}
