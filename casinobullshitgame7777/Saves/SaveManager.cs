using Newtonsoft.Json;
using System;
using System.IO;

namespace Casino
{
    public class PlayerData
    {
        public string PlayerName { get; set; }
        public int Money { get; set; }
        public string SaveFileName { get; private set; } = "playerData.json";

        public PlayerData() { } 

        public PlayerData(string playerName, int money)
        {
            PlayerName = playerName;
            Money = money;
        }

        public void Save()
        {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(SaveFileName, json);
        }

        public static PlayerData Load()
        {
            if (File.Exists("playerData.json"))
            {
                string json = File.ReadAllText("playerData.json");
                try
                {
                    return JsonConvert.DeserializeObject<PlayerData>(json);
                }
                catch (JsonReaderException ex)
                {
                    Console.WriteLine($"Error loading player data: {ex.Message}");
                    return null; 
                }
            }
            return null;
        }
    }
}