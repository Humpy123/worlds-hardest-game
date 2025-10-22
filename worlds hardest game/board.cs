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
        public int CoinCount { get; set; }
        private int width;
        private int height;
        private ICell[,] cells;
        private List<ICharacter> enemies = new List<ICharacter>();
        private Player player;
        public Player Player => player;
        private IEnemyFactory factory;
        public bool LevelCompleted = false;

        public Board(int width, int height, IEnemyFactory factory)
        {
            this.width = width;
            this.height = height;

            this.factory = factory;
            cells = new ICell[width, height];
            player = new Player('■', new PlayerMovement());

            

            

            // Initialize all cells as WALL
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    cells[x, y] = new Wall();
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


        public void IterateThroughEnemies()
        {
            foreach (var enemy in enemies)
                if (enemy.X == player.X && enemy.Y == player.Y)
                {
                    if (player.Immunity <= 0)
                        this.EndGame();
                }                   

        }

        public void CheckPlayerCell()
        {
            var cell = cells[player.X, player.Y];

            if(cell is ICollectible)
                cells[player.X, player.Y] = new Empty();
            cell.OnEnter(this);
        }

        public void DebugCellType(int x, int y)
        {
            Console.WriteLine(player.Immunity);
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
                            emptyCell.Color = ColorHelper.GetCheckerColor(x, y);
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

        public void FixCell()
        {
            SetCell(
                new Empty { Color = ColorHelper.GetCheckerColor(Player.X, Player.Y) },
                Player.X,
                Player.Y
            );

            PrintCell(Player.X, Player.Y);
        }
        private void FixCell(ICharacter character) => PrintCell(character.OldX, character.OldY);
        public void PrintCell(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            var cell = cells[x, y];
            PrintCell(cell.Symbol.ToString(), cell.Color);
        }

        public ConsoleColor GetCellColor(int x, int y) => cells[x, y].Color;
        public void SetCell<T>(int x, int y) where T : ICell, new() => cells[x, y] = new T();
        public void SetCell(ICell cell, int x, int y) => cells[x, y] = cell;

        public void SetPlayerPos(int x, int y)
        {
            player.X = x;
            player.Y = y;
        }

    }
}
