using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace worlds_hardest_game
{
    static class Scores
    {
        static public void InitList()
            => SerializeList(new List<PlayerFile>(), @"..\..\..\assets\highscores\highscores.json");
        static private void SerializeList(List<PlayerFile> list, string filePath)
        {
            string json = JsonSerializer.Serialize(list);
            File.WriteAllText(filePath, json);
        }
        static public void Add(PlayerFile player, int timeElapsed)
        {
            string filePath = @"..\..\..\assets\highscores\highscores.json";
            List<PlayerFile> playerList = new List<PlayerFile>();

            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                playerList = JsonSerializer.Deserialize<List<PlayerFile>>(json) ?? new List<PlayerFile>();
            }


            player.GameScore = timeElapsed.ToString();
            playerList.Add(player);
            string newJson = JsonSerializer.Serialize(playerList);
            File.WriteAllText(filePath, newJson);
        }

        static public List<PlayerFile> GetHighScores()
        {
            string filePath = @"..\..\..\assets\highscores\highscores.json";
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                var scores = JsonSerializer.Deserialize<List<PlayerFile>>(json) ?? new List<PlayerFile>();

                var topPlayers = scores
                    .OrderBy(p => int.Parse(p.GameScore))
                    .Take(10)
                    .ToList();

                return topPlayers;
            }
            return new List<PlayerFile>();
        }
    }
}
