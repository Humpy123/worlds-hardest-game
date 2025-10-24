using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace worlds_hardest_game
{
    public interface IMoveBehavior
    {
        void Move(CharacterBase character, Board board);
    }

    public class FrozenMovement : IMoveBehavior
    {
        public void Move(CharacterBase character, Board board) { }
    }


    public class PlayerMovement : IMoveBehavior
    {
        public void Move(CharacterBase character, Board board)
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
        int count = 0;
        private int direction = -1;

        public void Move(CharacterBase character, Board board)
        {
            if (board.IsWallAtOffset(character, 0, direction))
            {
                direction *= -1;
            }
            

             character.MoveByDelta(0, direction);
        }

    }

    public class SideToSideMovement : IMoveBehavior
    {

        private int direction = -1;

        public void Move(CharacterBase character, Board board)
        {
            if (board.IsWallAtOffset(character, direction, 0))
            {
                direction *= -1;
            }

            character.MoveByDelta(direction, 0);
        }
    }

    public class DVDMovement : IMoveBehavior
    {
        private int directionX = -1;
        private int directionY = -1;
        public void Move(CharacterBase character, Board board)
        {
            if (board.IsWallAtOffset(character, directionX, 0))
            {
                directionX *= -1;
            }
            if (board.IsWallAtOffset(character, 0, directionY))
            {
                directionY *= -1;
            }

            character.MoveByDelta(directionX, directionY);
        }
    }

    public class LargeSideToSideMovement : IMoveBehavior
    {
        private int directionX = -1;
        private bool flipped = false;
        public void Move(CharacterBase character, Board board)
        {
            //if (character is not LargeEnemy)
               // throw new InvalidOperationException("LargeMovement can only be used with LargeEnemy.");

            LargeEnemy bigBoy = (LargeEnemy)character;
            foreach (var part in bigBoy.Body)
            {
                if (board.IsWallAtOffset(part, directionX, 0) && !flipped)
                {
                    directionX *= -1;
                    flipped = true;
                }                                 
            }
            flipped = false;

            foreach (var part in bigBoy.Body)
                part.MoveByDelta(directionX, 0);
        }
    }

}
