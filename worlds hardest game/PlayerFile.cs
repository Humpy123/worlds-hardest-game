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
        public string GameScore { get; set; }
        public PlayerFile(string Name)
        {
            this.Name = Name;
            this.GameScore = "0.0";
        }
    }

}
