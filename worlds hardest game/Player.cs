using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace worlds_hardest_game
{
    public interface ICharacter
    {
        int X { get; set; }
        int Y { get; set; }
        int OldX { get; }
        int OldY { get; }
        char Symbol { get; set; }

        IMoveBehavior moveBehavior { get; set; }

        void Move(Board board);

        void MoveByDelta(int dx, int dy);
        void Print();
        void Print(Board board);
        bool IsAt(int x, int y);
    }

    public class Player : ICharacter
    {
        private int x, y;
        private int oldX, oldY;
        private int deathCount { get; set; }
        private bool hasShield { get; set; }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int OldX => oldX;
        public int OldY => oldY;
        public char Symbol { get; set; }
        public IMoveBehavior moveBehavior { get; set; }
        public bool HasShield { get => hasShield; set => hasShield = value; }



        public Player(char symbol, IMoveBehavior moveBehavior)
        {   
            this.Symbol = symbol;
            this.moveBehavior = moveBehavior;
            this.deathCount = 0;
        }

        public void Move(Board board) => moveBehavior.Move(this, board);


        public void MoveByDelta(int dx, int dy)
        {
            oldX = x;
            oldY = y;
            x += dx;
            y += dy;
        }

        public void Print(Board board)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = board.GetCellColor(x, y);
            Print();
        }
        public void Print()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(this.Symbol.ToString());
        }

        public bool IsAt(int x, int y) => (this.x == x && this.y == y) ? true : false;
    }

    class BasicEnemy : ICharacter
    {
        private int x, y;
        private int oldX, oldY;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int OldX => oldX;
        public int OldY => oldY;

        public char Symbol { get; set; }

        public IMoveBehavior moveBehavior { get; set; }


        public BasicEnemy(int x, int y, char symbol, IMoveBehavior moveBehavior)
        {
            this.x = x;
            this.y = y;
            this.X = this.x;
            this.Y = this.y;
            this.Symbol = symbol;
            this.moveBehavior = moveBehavior;
            
        }

        public void Move(Board board) => moveBehavior.Move(this, board);


        public void MoveByDelta(int dx, int dy)
        {
            oldX = x;
            oldY = y;
            x += dx;
            y += dy;
        }


        public void Print(Board board)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = board.GetCellColor(x, y);
            Print();
        }
        public void Print()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(this.Symbol.ToString());
        }

        public bool IsAt(int x, int y) { return false; }
    }
}
