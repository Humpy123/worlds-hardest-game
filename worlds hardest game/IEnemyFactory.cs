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

    public class SideToSideFactory : IEnemyFactory
    {   
        
        public ICharacter CreateEnemy(int x, int y, char symbol, Board board) 
        {
            return new BasicEnemy(x, y, symbol, new SideToSideMovement(board));
        }
    }

    public class UpAndDOwnFactory : IEnemyFactory
    {
        public ICharacter CreateEnemy(int x, int y, char symbol, Board board)
        {
            return new BasicEnemy(x, y, symbol, new UpAndDownMovement(board));
        }
    }


}

