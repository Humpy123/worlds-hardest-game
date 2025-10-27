using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace worlds_hardest_game
{
    public interface IMoveBehavior
    {
        void Move(CharacterBase character, Board board);
        void MoveGroup(CharacterBase[] enemyGroup, Board board);
    }

    public class FrozenMovement : IMoveBehavior
    {
        public void Move(CharacterBase character, Board board) { }
        public void MoveGroup(CharacterBase[] enemyGroup, Board board) { }
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
        public void MoveGroup(CharacterBase[] enemyGroup, Board board) { }
    }

        public class UpAndDownMovement : IMoveBehavior
        {
            private int directionY = -1;
            public void Move(CharacterBase character, Board board)
            {
                if (board.IsWallAtOffset(character, 0, directionY))
                    directionY *= -1;
                character.MoveByDelta(0, directionY);
            }

            public void MoveGroup(CharacterBase[] enemyGroup, Board board)
            {
                foreach (var part in enemyGroup)
                {
                    bool shouldFlip = enemyGroup.Any(part => board.IsWallAtOffset(part, 0, directionY));
                    if (shouldFlip)
                        directionY *= -1;
                }
                foreach (var part in enemyGroup)
                    part.MoveByDelta(0, directionY);
            }

        }

        public class SideToSideMovement : IMoveBehavior
        {
            private int directionX = -1;
            public void Move(CharacterBase character, Board board)
            {
                if (board.IsWallAtOffset(character, directionX, 0))
                    directionX *= -1;
                character.MoveByDelta(directionX, 0);
            }

            public void MoveGroup(CharacterBase[] enemyGroup, Board board)
            {
                foreach (var part in enemyGroup)
                {
                    bool shouldFlip = enemyGroup.Any(part => board.IsWallAtOffset(part, directionX, 0));
                    if (shouldFlip)
                        directionX *= -1;
                }
                foreach (var part in enemyGroup)
                    part.MoveByDelta(directionX, 0);
            }
        }

        public class DVDMovement : IMoveBehavior
        {
            private int directionX = -1;
            private int directionY = -1;
            public void Move(CharacterBase character, Board board)
            {
                if (board.IsWallAtOffset(character, directionX, 0))
                    directionX *= -1;
                if (board.IsWallAtOffset(character, 0, directionY))
                    directionY *= -1;

                character.MoveByDelta(directionX, directionY);
            }

        public void MoveGroup(CharacterBase[] enemyGroup, Board board)
        {
            bool flipX = enemyGroup.Any(part => board.IsWallAtOffset(part, directionX, 0));
            bool flipY = enemyGroup.Any(part => board.IsWallAtOffset(part, 0, directionY));

            if (flipX) directionX *= -1;
            if (flipY) directionY *= -1;

            foreach (var part in enemyGroup)
                part.MoveByDelta(directionX, directionY);
        }

    }

    public class TimeBasedEnemyFactory : IEnemyFactory
    {
        private Func<int> getGameTime;

        public TimeBasedEnemyFactory(Func<int> timeProvider)
        {
            getGameTime = timeProvider;
        }

        public CharacterBase CreateEnemy(int x, int y, char symbol, Board board)
        {
            int time = getGameTime();
            IMoveBehavior behavior = time switch
            {
                < 100 => new FrozenMovement(),
                < 200 => new SideToSideMovement(),
                < 300 => new UpAndDownMovement(),
                _ => new DVDMovement()
            };

            return new BasicEnemy(x, y, symbol, behavior);
        }
    }



    /*
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
            public void MoveGroup(CharacterBase[] enemyGroup, Board board) { }
        }*/

}
