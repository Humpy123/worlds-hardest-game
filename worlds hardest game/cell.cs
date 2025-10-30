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
    
    public class Wall : ICell
    {
        public void OnEnter(Board board) { }
        public char Symbol => '█';
        public ConsoleColor Color { get; set; } = ConsoleColor.Cyan;

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
        }
        public char Symbol => '●';
        public ConsoleColor Color { get; set; } = ConsoleColor.Blue;
        public void OnEnter(Board board)
        {
            ApplyEffect(board);
        }
    }

    public class Freeze : ICell, ICollectible
    {
        private int duration { get; set; }
        public Freeze() => this.duration = 15;
        public Freeze(int duration) => this.duration = duration;
        public void ApplyEffect(Board board)
        {
            board.FreezeNearbyEnemies();
            board.FixCell();
        }
        public char Symbol => '‡';
        public ConsoleColor Color { get; set; } = ConsoleColor.DarkCyan;
        public void OnEnter(Board board) => ApplyEffect(board);
    }



    // 1: Generics
    // 2: En generisk klass som wrappar celler som agerar som powerups.
    // 3: Logiken för powerupens effekt sitter i själva pickupen, och inte i cellen.
    // 3: Tillåter oss att hantera alla pickups med samma logik, tar bort conditionals.
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
