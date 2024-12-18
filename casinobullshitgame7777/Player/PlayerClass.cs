using Casino;
using System;

namespace PlayerClass
{
    public class Player
    {
        public string PlayerName { get; set; }
        public int Money { get; set; }
        public bool IsAccountDeleted { get; set; } = false;
        private PlayerData playerData;
        private string SaveFileName { get; } = "playerData.json";


        public Player()
        {
            playerData = PlayerData.Load();
            if (playerData != null)
            {
                PlayerName = playerData.PlayerName;
                Money = playerData.Money;
                Console.WriteLine($"Загружен профиль {PlayerName} с балансом {Money}$");
            }
        }

        public void PlayerNameInsert()
        {
            if (playerData == null)
            {
                Console.WriteLine();
                Console.WriteLine("Введите ник:");
                PlayerName = Console.ReadLine();
                Console.WriteLine($"Ваш ник: {PlayerName}");
            }
        }

        public void PlayerMoneyInsert()
        {
            if (playerData == null)
            {
                Console.WriteLine("Введите кол-во вашего баланса:");
                Console.WriteLine("(баланс не должен быть меньше или равном нулю)");
                string InputMoney = Console.ReadLine();
                Money = int.Parse(InputMoney);
                if (Money < 1)
                {
                    throw new Exception("БАЛАНС МЕНЬШЕ НУЛЯ, ИЛИ РАВЕН НУЛЮ");
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Ваш баланс: {Money}$");
                Console.ResetColor();
            }
        }

        public void UpdateBalance(int amount)
        {
            Money += amount;
            if (Money <= 0 && !IsAccountDeleted)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine();
                Console.WriteLine("Вы проиграли, т.к. ваш баланс равен нулю!" +
                    "\nВАША УЧЕТНАЯ ЗАПИСЬ УДАЛЕНА");
                IsAccountDeleted = true;   
                if (File.Exists(SaveFileName))
                {
                    File.Delete(SaveFileName);
                }
                CreateNewProfile();
            }
        }

        private void CreateNewProfile()
        {
            Console.WriteLine("\nСоздайте новый профиль:");
            PlayerNameInsert();
            PlayerMoneyInsert();
            Save();
        }


        public void Save()
        {
            if (playerData == null)
                playerData = new PlayerData(PlayerName, Money);
            else
            {
                playerData.PlayerName = PlayerName;
                playerData.Money = Money;
            }
            playerData.Save();
        }
    }
}