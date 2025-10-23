using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace worlds_hardest_game
{
    public class EnemyGroup : IEnumerable<ICharacter>
    {
        private List<ICharacter> enemyList;

        public EnemyGroup(List<ICharacter> list)
        {
            enemyList = list;
        }

        public IEnumerator<ICharacter> GetEnumerator() => new EnemyEnum(enemyList);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerable<ICharacter> NearbyEnemies(Player player, int radius)
        {
            return enemyList.Where(e => Distance(e, player) <= radius);
        }

        private int Distance(ICharacter a, ICharacter b) => Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);


    }

    public class EnemyEnum : IEnumerator<ICharacter>
    {
        public List<ICharacter> enemyList;
        private int index = -1;
        public EnemyEnum(List<ICharacter> enemyList)
        {
            this.enemyList = enemyList;
        }

        public bool MoveNext()
        {
            if (++index < enemyList.Count())
                return true;
            else return false;
        }

        public void Reset() => index = -1;

        public ICharacter Current => enemyList[index];  
        object IEnumerator.Current => Current;
        public void Dispose() { }
    }
}
