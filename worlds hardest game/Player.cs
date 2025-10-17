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
        bool IsAt(int x, int y);
    }

    public class Player : ICharacter
    {
        private int x, y;
        private int oldX, oldY;

        public int X {get; set;}
        public int Y { get; set;}
        public int OldX => oldX;
        public int OldY => oldY;
        public char Symbol { get; set; }
        public IMoveBehavior moveBehavior { get; set; }


        public Player(int x, int y,char symbol, IMoveBehavior moveBehavior)
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


        public void Print()
        {
            Console.SetCursorPosition(this.x, this.y);
            Console.Write(this.Symbol.ToString());
        }

        public bool IsAt(int x, int y) => (this.x == x && this.y == y) ? true : false;
    }

    class BasicEnemy : ICharacter
    {
        private int x, y;
        private int oldX, oldY;

        public int X { get; set; }
        public int Y { get; set; }
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


        public void Print()
        {
            Console.SetCursorPosition(this.x, this.y);
            Console.Write(this.Symbol.ToString());
        }

        public bool IsAt(int x, int y) { return false; }
    }
}
