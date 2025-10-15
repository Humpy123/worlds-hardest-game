using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace worlds_hardest_game
{
    public class Player
    {
        private int x, y;

        public char Symbol { get; set; }

        public Player(int x, int y,char symbol)
        {
            this.x = x;
            this.y = y;
            this.Symbol = symbol;
        }

        public void Move(int dx, int dy)
        {
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
