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

        public void ChangeColor(ConsoleColor color) => this.Color = color;
    }
    public class Obstacle : ICell
    {
        public void OnEnter(Board board) { }

        public char Symbol => 'O';
        public ConsoleColor Color { get; set; }
    }
    public class Wall : ICell
    {
        public void OnEnter(Board board) { }
        public char Symbol => '█';
        public ConsoleColor Color { get; set; } = ConsoleColor.Cyan;

    }

    public class StartZone : ICell
    {
        public void OnEnter(Board board) { }
        public char Symbol => '█';
        public ConsoleColor Color { get; set; } = ConsoleColor.Green;
    }

    public class EndZone : ICell
    {
        public void OnEnter(Board board)
        {
            if(board.CoinCount <= 0)
                board.WonGame();
        }
        public char Symbol => '█';
        public ConsoleColor Color { get; set; } = ConsoleColor.Green;
    }

    public interface ICollectible
    {
        void ApplyEffect(Board board);
    }

    public class Coin : ICell, ICollectible
    {
        public void ApplyEffect(Board board)
        {
            board.CoinCount--;
            board.FixCell();
            board.PrintCell(board.Player.X, board.Player.Y);
        }
        public char Symbol => '●';
        public ConsoleColor Color { get; set; } = ConsoleColor.DarkYellow;
        public void OnEnter(Board board)
        {
            ApplyEffect(board);
            
        } 
    }
    public class Shield : ICell, ICollectible
    {
        public void ApplyEffect(Board board)
        {   
            board.Player.Immunity = 30;
            board.FixCell();
            board.PrintCell(board.Player.X, board.Player.Y);
        }
        public char Symbol => '●';
        public ConsoleColor Color { get; set; } = ConsoleColor.Blue;
        public void OnEnter(Board board)
        {
            ApplyEffect(board);

        }
    }


    public class GenericPickup<T> : ICell where T : ICollectible, ICell, new()
    {
        public T Item { get; set; } = new T();
        public char Symbol => Item.Symbol;

        public ConsoleColor Color
        {
            get => Item.Color;
            set => Item.Color = value;
        }

        public void OnEnter(Board board)
        {
            Item.ApplyEffect(board);
        }
    }

}
