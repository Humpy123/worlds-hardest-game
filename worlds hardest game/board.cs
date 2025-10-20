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
        private List<ICharacter> enemies = new List<ICharacter>();
        private Player player;
        private IEnemyFactory factory;
        public bool LevelCompleted = false;

        public Board(int width, int height, IEnemyFactory factory)
        {
            this.width = width;
            this.height = height;

            this.factory = factory;
            cells = new ICell[width, height];
            player = new Player(width / 2 - 20, height / 2, '■', new PlayerMovement());

            

            

            // Initialize all cells as WALL
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    cells[x, y] = new Wall();

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

        public void AddEnemy(int x, int y)
        {
            var enemy = factory.CreateEnemy(x, y, '●', this);
            enemies.Add(enemy);
        }

        public bool GameOver { get; private set; } = false;

        public void EndGame()
        {
            GameOver = true;
        }

        public void WonGame()
        {
            LevelCompleted = true;
            GameOver = true;
        }

        public void AddCell(ICell cell, int x, int y) => cells[x, y] = cell;


        public void PrintCell(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }

        public void IterateThroughCells()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    var cell = cells[x, y];
                    if (player.X == x && player.Y == y) cell.OnEnter(this); 

                }
            }
        }

        public void IterateThroughEnemies()
        {
            foreach (var enemy in enemies)
                if (enemy.X == player.X && enemy.Y == player.Y)
                    this.EndGame();
        }

        public void PrintFullboard()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                        var cell = cells[x, y];
                        if(cell is Empty emptyCell)
                        {
                            var color = ((x+y%2) % 2 == 0) ? ConsoleColor.White : ConsoleColor.Gray;
                            emptyCell.Color = color;
                        }
                            PrintCell(cell.Symbol.ToString(), cell.Color);

                }
                Console.WriteLine();
            }
        }

        public void MovePlayer() => player.Move(this);

        public void PrintPlayer()
        {
            player.Print(this);
            FixCell(player);
        }

        public void MoveAndPrintEnemies()
        {
            foreach (var enemy in enemies)
            {
                enemy.Move(this);
                enemy.Print(this);
                FixCell(enemy);
            }
        }

        public bool IsWallAt(int x, int y)
        {
            return cells[x, y] is Wall;
        }

        public bool IsWallAtOffset(ICharacter character, int dx, int dy)
        {
            int newX = character.X + dx;
            int newY = character.Y + dy;

            if (newX < 0 || newX >= width || newY < 0 || newY >= height)
                return true; // Treat out-of-bounds as wall

            return cells[newX, newY] is Wall;
        }

        private void FixCell(ICharacter character)
        {
            Console.SetCursorPosition(character.OldX, character.OldY);
            var cell = cells[character.OldX, character.OldY];
            PrintCell(cell.Symbol.ToString(), cell.Color);
        }
        public ConsoleColor GetCellColor(int x, int y) => cells[x, y].Color;
        public void ChangeCell<T>(int x, int y) where T : ICell, new() => cells[x, y] = new T();
    }
}
