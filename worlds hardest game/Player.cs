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

        public int X => x;
        public int Y => y;
        public int OldX => oldX;
        public int OldY => oldY;


        //read-only
        public int X => x;
        public int Y => y;
        public int OldX => oldX;
        public int OldY => oldY;
        public char Symbol { get; set; }

        public Player(int x, int y,char symbol)
        {   
            this.x = x;
            this.y = y;
            this.Symbol = symbol;
        }

        public void Move(int dx, int dy)
        {
            oldX = x;
            oldY = y;
            this.x += dx;
            this.y += dy;
        }

        public void Print()
        {
            Console.SetCursorPosition(this.x, this.y);
            Console.Write(this.Symbol.ToString());
        }

        public bool IsAt(int x, int y) => (this.x == x && this.y == y) ? true : false;
    }
}
