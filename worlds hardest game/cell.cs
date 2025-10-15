using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace worlds_hardest_game
{
    public interface ICell
    {
        void OnEnter(Board board);
        char Symbol { get; }
        ConsoleColor Color { get; set; }
    }
    public class Empty : ICell
    {
        public void OnEnter(Board board) { }
        public char Symbol => '█';
        public ConsoleColor Color { get; set; } = ConsoleColor.White;
    }
    public class Obstacle : ICell
    {
        public void OnEnter(Board board) { }

        public char Symbol => 'O';
        public ConsoleColor Color { get; set; }
    }

    public class Coin : ICell
    {
        public void OnEnter(Board board) { }

        public char Symbol => 'C';
        public ConsoleColor Color { get; set; }
    }
    public class Wall : ICell
    {
        public void OnEnter(Board board) { }
        public char Symbol => '█';
        public ConsoleColor Color { get; set; } = ConsoleColor.Cyan;

    }

    public class EndZone : ICell
    {
        public void OnEnter(Board board) => Console.WriteLine("You won!");
        public char Symbol => '█';
        public ConsoleColor Color { get; set; } = ConsoleColor.Green;
    }
}
