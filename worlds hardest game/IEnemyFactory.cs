using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace worlds_hardest_game
{
    public interface IEnemyFactory
    {
        CharacterBase CreateEnemy(int x, int y, char symbol, Board board);
    }

    public class BasicEnemyFactory : IEnemyFactory
    {
        private Type moveBehaviorType;

        public BasicEnemyFactory(IMoveBehavior moveBehavior)
        {
            moveBehaviorType = moveBehavior.GetType();
        }

        public CharacterBase CreateEnemy(int x, int y, char symbol, Board board)
        {
            IMoveBehavior newBehavior = (IMoveBehavior)Activator.CreateInstance(moveBehaviorType);
            return new BasicEnemy(x, y, symbol, newBehavior);
        }
    }

    public class RandomFactory : IEnemyFactory
    {
        Random rand = new Random();
        public CharacterBase CreateEnemy(int x, int y, char symbol, Board board)
        {
            switch (rand.Next(1, 4))
            {
                case 1:
                    return new BasicEnemy(x, y, symbol, new SideToSideMovement());
                case 2:
                    return new BasicEnemy(x, y, symbol, new UpAndDownMovement());
                case 3:
                    return new BasicEnemy(x, y, symbol, new DVDMovement());
                case 4:
                    return new BasicEnemy(x, y, symbol, new DVDMovement());
                default:
                    return new BasicEnemy(x, y, symbol, new DVDMovement());

            }            
        }
    }

    public class LargeEnemyFactory : IEnemyFactory
    {
        private Type moveBehaviorType;
        public LargeEnemyFactory(IMoveBehavior moveBehavior)
        {
            moveBehaviorType = moveBehavior.GetType();
        }

        public CharacterBase CreateEnemy(int x, int y, char symbol, Board board)
        {
            IMoveBehavior newBehavior = (IMoveBehavior)Activator.CreateInstance(moveBehaviorType);
            return new LargeEnemy(x, y, symbol, newBehavior, ConsoleColor.DarkMagenta);
        }
    }
}

