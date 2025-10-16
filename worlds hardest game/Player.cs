using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace worlds_hardest_game
{   
    interface Character
    {
        IMoveBehavior moveBehavior { get; set; }
    }
    public class Player
    {
        private int x, y;
        private int oldX, oldY;

        public int X {get; set;}
        public int Y { get; set;}
        public int OldX { get; set;}
        public int OldY { get; set;}

        public char Symbol { get; set; }

        public IMoveBehavior moveBehavior;

        public Player(int x, int y,char symbol, IMoveBehavior moveBehavior)
        {   
            this.x = x;
            this.y = y;
            this.X = this.x;
            this.Y = this.y;
            this.Symbol = symbol;
            this.moveBehavior = moveBehavior;
        }

        public void Move(int dx, int dy)
        {
            OldX = x;
            OldY = y;

            moveBehavior.Move(this, dx, dy);

            oldX = OldX;
            oldY = OldY;
        }

        public void Print()
        {
            Console.SetCursorPosition(this.x, this.y);
            Console.Write(this.Symbol.ToString());
        }

        public bool IsAt(int x, int y) => (this.x == x && this.y == y) ? true : false;
    }
}
