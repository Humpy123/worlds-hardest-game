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
        static private string filePath = @"..\..\..\assets\highscores\highscores.json";
        static private void SerializeList(List<PlayerFile> list)
        {
            string json = JsonSerializer.Serialize(list);
            File.WriteAllText(filePath, json);
        }
        static public void Add(PlayerFile player)
        {
            if (!File.Exists(filePath)) 
                SerializeList(new List<PlayerFile>());

            string json = File.ReadAllText(filePath);
            var playerList = JsonSerializer.Deserialize<List<PlayerFile>>(json) ?? new List<PlayerFile>();
            playerList.Add(player);

            SerializeList(playerList);
        }

        static public List<PlayerFile> GetHighScores()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                var scores = JsonSerializer.Deserialize<List<PlayerFile>>(json) ?? new List<PlayerFile>();

                var topPlayers = scores
                    .OrderByDescending(p => p.GameScore)
                    .Take(10)
                    .ToList();

                return topPlayers;
            }
            return new List<PlayerFile>();
        }
    }
}
