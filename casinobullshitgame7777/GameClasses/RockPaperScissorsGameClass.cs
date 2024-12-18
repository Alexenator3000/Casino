using PlayerClass;

namespace Casino
{
    public class RockPaperScissorsGame
    {
        private Random random = new Random();
        private string[] choices = { "камень", "ножницы", "бумага" };

        public void Play(Player player)
        {
            Console.WriteLine($"\nВаш баланс: {player.Money}$");
            Console.WriteLine("Сколько вы хотите поставить?");

            if (!int.TryParse(Console.ReadLine(), out int bet))
            {
                Console.WriteLine("Некорректная сумма ставки.");
                return;
            }

            if (bet <= 0 || bet > player.Money)
            {
                Console.WriteLine("Некорректная ставка. Сумма должна быть больше нуля и не превышать ваш баланс.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Выберите: камень, ножницы или бумага:");
            Console.WriteLine("(что бы выбрать, напишите 'камень/ножницы/бумага'");

            string playerChoice = Console.ReadLine().ToLower();

            if (!IsValidChoice(playerChoice))
            {
                Console.WriteLine("Неверный выбор.");
                return;
            }

            string computerChoice = choices[random.Next(choices.Length)];
            Console.WriteLine($"Компьютер выбрал: {computerChoice}");

            string result = DetermineWinner(playerChoice, computerChoice);
            Console.WriteLine(result);

            if (result == "Вы выиграли!")
            {
                player.Money += bet;
            }
            else if (result == "Вы проиграли!")
            {
                player.Money -= bet;
            }
            else
            {
                Console.WriteLine("Ничья!");
            }

            Console.WriteLine($"Ваш баланс на данный момент: {player.Money}$");
           
        }

        private bool IsValidChoice(string choice)
        {
            return choices.Contains(choice);
        }

        private string DetermineWinner(string playerChoice, string computerChoice)
        {
            if (playerChoice == computerChoice)
            {
                return "Ничья!";
            }
            else if (
                (playerChoice == "камень" && computerChoice == "ножницы") ||
                (playerChoice == "ножницы" && computerChoice == "бумага") ||
                (playerChoice == "бумага" && computerChoice == "камень")
            )
            {
                return "Вы выиграли!";
            }
            else
            {
                return "Вы проиграли!";
            }
        }
    }
}
