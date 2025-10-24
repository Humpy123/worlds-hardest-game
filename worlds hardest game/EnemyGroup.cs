using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace worlds_hardest_game
{
    public class EnemyGroup : IEnumerable<CharacterBase>
    {
        private List<CharacterBase> enemyList;

        public EnemyGroup(List<CharacterBase> list)
        {
            enemyList = list;
        }

        public IEnumerator<CharacterBase> GetEnumerator() => new EnemyEnum(enemyList);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerable<CharacterBase> NearbyEnemies(Player player, int radius)
        {
            return enemyList.Where(e => Distance(e, player) <= radius);
        }

        private int Distance(CharacterBase a, CharacterBase b) => Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);


    }

    public class EnemyEnum : IEnumerator<CharacterBase>
    {
        public List<CharacterBase> enemyList;
        private int index = -1;
        public EnemyEnum(List<CharacterBase> enemyList)
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

        public CharacterBase Current => enemyList[index];  
        object IEnumerator.Current => Current;
        public void Dispose() { }
    }
}
