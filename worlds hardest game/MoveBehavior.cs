using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace worlds_hardest_game
{
    public interface IMoveBehavior
    {
        void Move(ICharacter character, Board board);
    }


    public class PlayerMovement : IMoveBehavior
    {
        public void Move(ICharacter character, Board board)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                int dx = 0, dy = 0;

                if (key == ConsoleKey.UpArrow || key == ConsoleKey.W) dy = -1;
                else if (key == ConsoleKey.DownArrow || key == ConsoleKey.S) dy = 1;
                else if (key == ConsoleKey.LeftArrow || key == ConsoleKey.A) dx = -1;
                else if (key == ConsoleKey.RightArrow || key == ConsoleKey.D) dx = 1;
                else if (key == ConsoleKey.Escape) Environment.Exit(0);

                if (!board.IsWallAt(character.X + dx, character.Y + dy))
                {
                    character.MoveByDelta(dx, dy);
                }
            }
        }
    }


    public class UpAndDownMovement : IMoveBehavior
    {
        private Board board;
        int count = 0;
        private int direction = -1;

        public UpAndDownMovement(Board board)
        {
            this.board = board;
        }

        public void Move(ICharacter character, Board board)
        {
            if (board.IsWallAtOffset(character, 0, direction))
            {
                direction *= -1;
            }
            
            // Limits up and down movement because pixels are taller than they are wide
            if(++count % 2 == 0)
                character.MoveByDelta(0, direction);
        }

    }

    public class SideToSideMovement : IMoveBehavior
    {
        private Board board;
        private int direction = -1;

        public SideToSideMovement(Board board)
        {
            this.board = board;
        }

        public void Move(ICharacter character, Board board)
        {
            if (board.IsWallAtOffset(character, direction, 0))
            {
                direction *= -1;
            }

            character.MoveByDelta(direction, 0);
        }

    }
}
