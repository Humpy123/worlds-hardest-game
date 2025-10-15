using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace worlds_hardest_game
{
    public class Player
    {
        private int X, Y;

        public int oldX,oldY;

        public char Symbol { get; set; }

        public Player(int x, int y,char symbol)
        {   
            this.X = x;
            this.Y = y;
            this.Symbol = symbol;
        }

        public void Move(int dx, int dy)
        {
            oldX = X;
            oldY = Y;
            this.X += dx;
            this.Y += dy;
        }
        public (int x, int y) GetOldCoords() // tuple return type
        {
            return (oldX, oldY); // tuple literal
        }
        public void Print()
        {
            Console.SetCursorPosition(this.X, this.Y);
            Console.Write(this.Symbol.ToString());
        }

        public bool IsAt(int x, int y) => (this.X == x && this.Y == y) ? true : false;
    }
}
