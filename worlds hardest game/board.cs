using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace worlds_hardest_game
{
    public class Board
    {
        private int width;
        private int height;
        private ICell[,] cells;
        private Player player;

        public Board(int width, int height)
        {
            this.width = width;
            this.height = height;
            cells = new ICell[width, height];
            player = new Player(width / 2, height / 2, '■');

            // Initialize all cells as empty
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    cells[x, y] = new Empty();

            // Add walls around the perimeter
            for (int x = 0; x < width; x++)
            {
                cells[x, 0] = new Wall();         // Top wall
                cells[x, height - 1] = new Wall(); // Bottom wall
            }
            for (int y = 0; y < height; y++)
            {
                cells[0, y] = new Wall();         // Left wall
                cells[width - 1, y] = new Wall();  // Right wall
            }
        }

        public void AddCell(ICell cell, int x, int y)
        {
            cells[x, y] = cell;
        }

        public void Print()
        {
            Console.Clear();
            Console.WriteLine("World's Hardest game! Level: 5");
            Console.WriteLine();

            void Print(string text, ConsoleColor color)
            {
                Console.ForegroundColor = color;
                Console.Write(text);
                Console.ResetColor();
            }

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                        var cell = cells[x, y];
                        Print(cell.Symbol.ToString(), cell.Color);

                }
                Console.WriteLine();
            }
        }

        public void MovePlayer(int dx, int dy)
        {
            player.Move(dx, dy);
        }

        public void PrintPlayer() => player.Print();
    }
}
