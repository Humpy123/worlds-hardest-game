using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
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
        private IEnemyFactory factory;

        public int CoinCount { get; set; }
        public bool IsLevelCompleted { get; private set; }
        public bool GameOver { get; private set; } = false;
        public Player Player { get; private set; }
        public EnemyGroup enemyGroup { get; set; }


        public Board(int width, int height, IEnemyFactory factory)
        {
            this.width = width;
            this.height = height;
            this.factory = factory;
            cells = new ICell[width, height];
            Player = new Player('■', new PlayerMovement(), ConsoleColor.DarkRed);
            enemyGroup = new EnemyGroup(enemies);

            // Initialize all cells as wall objects
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    cells[x, y] = new Wall();
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
                    ColorHelper.FixColors(cell, x, y);
                    PrintCell(cell.Symbol.ToString(), cell.Color);

                }
                Console.WriteLine();
            }
        }
        public void EndGame() => GameOver = true;
        public void WonGame()
        {
            IsLevelCompleted = true;
            GameOver = true;
        }
        public void AddCell(ICell cell, int x, int y) => cells[x, y] = cell;
        public void PrintCell(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }

        public void MovePlayer() => Player.Move(this);
        public void PrintPlayer()
        {
            Player.Print(this);
            FixCell(Player);
        }

        // Check for player collision with cell
        public void CheckPlayerCell()
        {
            var cell = cells[Player.X, Player.Y];

            // Collectibles get replaced with an empty squares upon collection
            if (cell is ICollectible) 
                cells[Player.X, Player.Y] = new Empty();

            cell.OnEnter(this);
        }
        public void AddEnemy(int x, int y)
        {
            var enemy = factory.CreateEnemy(x, y, '●', this);
            enemies.Add(enemy);
            new EnemyGroup(enemies);
        }

        // Check for enemy collission
        public void CheckEnemyCollision()
        {
            var allOpps = enemyGroup.GetEnumerator();
            while (allOpps.MoveNext())
            {
                var enemy = allOpps.Current;

                if (enemy.X == Player.X && enemy.Y == Player.Y)
                {
                    if (Player.Immunity <= 0)
                        this.EndGame();
                }
            }      
        }

        public void FreezeNearbyEnemies()
        {
            foreach (var enemy in enemyGroup.NearbyEnemies(Player, 10))
                ((BasicEnemy)enemy).FrozenTimer = 15;
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

        //public void FreezeEnemies(int duration) => Frozen = duration;
        public void Debug() => Console.WriteLine();     
        public bool IsWallAt(int x, int y) => cells[x, y] is Wall;
        public bool IsWallAtOffset(ICharacter character, int dx, int dy) => IsWallAt(character.X + dx, character.Y + dy);


        public void FixCell()
        {
            SetCell(
                new Empty { Color = ColorHelper.GetCheckerColor(Player.X, Player.Y) },
                Player.X,
                Player.Y
            );

            PrintCellAt(Player.X, Player.Y);
        }
        private void FixCell(ICharacter character) => PrintCellAt(character.OldX, character.OldY);
        public void PrintCellAt (int x, int y)
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
            Player.X = x;
            Player.Y = y;
        }

    }
}
