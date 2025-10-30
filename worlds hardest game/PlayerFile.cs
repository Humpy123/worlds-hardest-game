using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace worlds_hardest_game
{
    public class PlayerFile
    {
        public string Name { get; set; }
        public int GameScore { get; set; }
        public PlayerFile() { }
        public PlayerFile(string Name, int GameScore)
        {
            this.Name = Name;
            this.GameScore = GameScore;
        }
    }

}
