using System;

namespace worlds_hardest_game
{
    public interface IEnemy
    {

    }
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
        void Print(Board board);
        bool IsAt(int x, int y);
    }

    public class Player : ICharacter
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int OldX { get; private set; }
        public int OldY { get; private set; }
        public char Symbol { get; set; }
        public IMoveBehavior moveBehavior { get; set; }
        public int Immunity { get; set; }
        public ConsoleColor Color { get; set; }

        public Player(char symbol, IMoveBehavior moveBehavior, ConsoleColor color)
        {
            Symbol = symbol;
            this.moveBehavior = moveBehavior;
            Immunity = 0;
            Color = color;
        }

        public void Move(Board board) => moveBehavior.Move(this, board);

        public void MoveByDelta(int dx, int dy)
        {
            OldX = X;
            OldY = Y;
            X += dx;
            Y += dy;
        }

        public void Print(Board board)
        {
            Console.ForegroundColor = Immunity > 0 ? ConsoleColor.Blue : ConsoleColor.DarkRed;
            Console.BackgroundColor = board.GetCellColor(X, Y);
            Console.SetCursorPosition(X, Y);
            Console.Write(Symbol.ToString());
        }
        public bool IsAt(int x, int y) => X == x && Y == y;
    }

    public class BasicEnemy : ICharacter, IEnemy
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int OldX { get; private set; }
        public int OldY { get; private set; }
        public char Symbol { get; set; }
        public IMoveBehavior moveBehavior { get; set; }
        public int FrozenTimer = 0;

        public BasicEnemy(int x, int y, char symbol, IMoveBehavior moveBehavior)
        {
            X = x;
            Y = y;
            Symbol = symbol;
            this.moveBehavior = moveBehavior;
        }

        public void Move(Board board)
        {
            if(--FrozenTimer < 0)
                moveBehavior.Move(this, board);
        }

        public void MoveByDelta(int dx, int dy)
        {
            OldX = X;
            OldY = Y;
            X += dx;
            Y += dy;
        }

        public void Print(Board board)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = board.GetCellColor(X, Y);
            Console.SetCursorPosition(X, Y);
            Console.Write(Symbol.ToString());
        }
        public bool IsAt(int x, int y) => false;
    }
}
