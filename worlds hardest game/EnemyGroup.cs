using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace worlds_hardest_game
{
    // KRAV #5:
    // 1: Enumerable & Enumerator
    // 2: Vi implementerar en egen Enumerator (EnemyEnum) som används av vår EnemyGroup-klass för att iterera över fiender.
    //    Istället för att använda List<T>.GetEnumerator() har vi skapat en separat klass som hanterar iterationen manuellt.
    // 3: Detta ger oss möjlighet att utöka iterationen med egen logik, t.ex. filtrering av fiender
    //    Det gör vår typ mer flexibel än en vanlig lista..


    public class EnemyGroup : IEnumerable<CharacterBase>
    {
        private List<CharacterBase> enemyList;

        public EnemyGroup(List<CharacterBase> list)
        {
            enemyList = list;
        }


        public IEnumerator<CharacterBase> GetEnumerator() => new EnemyEnum(enemyList);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        // KRAV #6:
        // 1: LINQ metod-syntax
        // 2: Vår IEnumerable för fiender filtreras med en konstruerad conditional (Distance)
        //    Detta används i "freeze" effekten, som bara fryser fiender som är nära spelaren.
        // 3 LINQ används eftersom att det är det enklaste sättet att filtrera en lista med en conditional.
        public IEnumerable<CharacterBase> NearbyEnemies(Player player, int radius)
            => this.Where(e => Distance(e, player) <= radius);

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
