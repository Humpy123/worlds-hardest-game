using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace worlds_hardest_game
{
    //Krav #4:
    // 1: Factory Method Pattern
    // 2: Vi använder en fabrikshierarki där IEnemyFactory är supertypen och har tre konkretioner BasicEnemyFactory, RandomFactory och LargeEnemyFactory. 
    //  Varje factory skapar olika typer av produkter från supertypen CharacterBase med olika rörelsebeteenden.
    //  Fabrikerna injiceras sedan och används för att skapa fiender vilket gör att objekten inte lika gärna hade kunnat skapas utan fabriken.
    // 3: Vi använder Factory Method Pattern för att möjliggöra flexibelt och utbyggbart skapande av fiender med olika beteenden på olika nivåer i spelet.
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
        private IMoveBehavior getRandomMovebehavior()
        {
            Random rand = new Random();
            switch (rand.Next(1, 4))
            {
                case 1:
                    return new SideToSideMovement();
                case 2:
                    return new UpAndDownMovement();
                case 3:
                    return new DVDMovement();
                default:
                    throw new Exception("how");
            }
        }
        Random rand = new Random();
        public CharacterBase CreateEnemy(int x, int y, char symbol, Board board)
        {
            int num = rand.Next();

            if (num % 4 == 0)
                return new LargeEnemy(x, y, symbol, getRandomMovebehavior(), ConsoleColor.DarkMagenta);
            else
                return new BasicEnemy(x, y, symbol, getRandomMovebehavior());
       
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

