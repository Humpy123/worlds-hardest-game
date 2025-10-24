using System;

namespace worlds_hardest_game
{
    public interface IEnemy
    {
        bool CheckCollision(int x, int y);
    }
    public abstract class CharacterBase
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int OldX { get; private set; }
        public int OldY { get; private set; }
        public char Symbol { get; set; }
        public IMoveBehavior moveBehavior { get; set; }
        public ConsoleColor Color { get; set; }
        public virtual bool CheckCollision(int x, int y)
            => (x == this.X && y == this.Y);

        public void FixCell(Board board)
        {
            board.SetCell(
                new Empty { Color = ColorHelper.GetCheckerColor(X, Y) },
                X,
                Y
            );

            board.PrintCellAt(X, Y);
        }

        public virtual void Move(Board board) => moveBehavior.Move(this, board);
        public virtual void Print(Board board) { }
        public void MoveByDelta(int dx, int dy)
        {
            OldX = X;
            OldY = Y;
            X += dx;
            Y += dy;
        }
        public bool IsAt(int x, int y) => X == x && Y == y;
    }

    public class BasicEnemy : CharacterBase, IEnemy
    {
        public int FrozenTimer = 0;

        public BasicEnemy(int x, int y, char symbol, IMoveBehavior moveBehavior)
        {
            X = x;
            Y = y;
            Symbol = symbol;
            this.moveBehavior = moveBehavior;
        }

        public override void Move(Board board)
        {
            if (--FrozenTimer < 0)
                moveBehavior.Move(this, board);
        }
        public override void Print(Board board)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = board.GetCellColor(X, Y);
            Console.SetCursorPosition(X, Y);
            Console.Write(Symbol.ToString());

            //FixCell(board);
        }
    }

    public class Player : CharacterBase
    {
        public int Immunity { get; set; }

        public Player(char symbol, IMoveBehavior moveBehavior, ConsoleColor color)
        {
            Symbol = symbol;
            this.moveBehavior = moveBehavior;
            Immunity = 0;
            Color = color;
        }

        public void Move(Board board) => moveBehavior.Move(this, board);

        public override void Print(Board board)
        {
            Console.ForegroundColor = Immunity > 0 ? ConsoleColor.Blue : ConsoleColor.DarkRed;
            Console.BackgroundColor = board.GetCellColor(X, Y);
            Console.SetCursorPosition(X, Y);
            Console.Write(Symbol.ToString());

            //FixCell(board);
        }
    }

    public class LargeEnemy: CharacterBase, IEnemy
    {
        public BasicEnemy[] Body = new BasicEnemy[5];
        public LargeEnemy(int x, int y, char symbol, IMoveBehavior moveBehavior, ConsoleColor color)
        {
            Body[0] = new BasicEnemy(x, y, symbol, moveBehavior);
            Body[1] = new BasicEnemy(x+1, y+1, symbol, moveBehavior);
            Body[2] = new BasicEnemy(x+1, y-1, symbol, moveBehavior);
            Body[3] = new BasicEnemy(x-1, y+1, symbol, moveBehavior);
            Body[4] = new BasicEnemy(x-1, y-1, symbol, moveBehavior);

            Symbol = symbol;
            this.moveBehavior = moveBehavior;
            Color = color;
        }

        public override void Move(Board board)
        {
            moveBehavior.Move(this, board);
        }

        public override void Print(Board board)
        {
            foreach (var part in Body)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.BackgroundColor = board.GetCellColor(part.X, part.Y);
                Console.SetCursorPosition(part.X, part.Y);
                Console.Write(Symbol.ToString());

                board.PrintCellAt(part.OldX, part.OldY);
            }            
        }

        public override bool CheckCollision(int x, int y)
        {

            foreach (var part in Body)
                if (x == part.X && y == part.Y)
                    return true;
            return false;
        }
    }
}
