using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace worlds_hardest_game
{
    public interface IEnemyFactory
    {
        ICharacter CreateEnemy(int x, int y, char symbol, Board board);
    }

    public class BasicEnemyFactory : IEnemyFactory
    {
        public ICharacter CreateEnemy(int x, int y, char symbol, Board board) 
        {
            return new BasicEnemy(x, y, symbol, new LeftToRightMovement(board));
        }
    }

}

