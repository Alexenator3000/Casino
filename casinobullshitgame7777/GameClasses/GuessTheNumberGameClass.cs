using PlayerClass;
using static System.Formats.Asn1.AsnWriter;

namespace Casino
{
    public class GuessTheNumberGame
    {
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
            Console.WriteLine("Введите минимальное число:");
            int min = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите максимальное число:");
            int max = int.Parse(Console.ReadLine());
            int attempts = 5;

            Random random = new Random();
            int secretNumber = random.Next(min, max + 1);

            Console.WriteLine($"Вы загадал число от {min} до {max}. У вас есть {attempts} попыток.");

            for (int i = 0; i < attempts; i++)
            {
                Console.WriteLine($"\nПопытка {i + 1}/{attempts}:");
                Console.Write("Введите ваше число: ");

                if (int.TryParse(Console.ReadLine(), out int guess))
                {
                    if (guess == secretNumber)
                    {
                        Console.WriteLine($"Поздравляю! Вы угадали секретное число {secretNumber} за {i + 1} попыток!");
                        player.Money += bet;
                        Console.WriteLine($"Ваш баланс: {player.Money}");
                        
                        return;
                    }
                    else if (guess < secretNumber)
                    {
                        Console.WriteLine("Секретное число больше.");
                    }
                    else
                    {
                        Console.WriteLine("Секретное число меньше.");
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Попробуйте ещё раз.");
                    i--;
                }
            }

            Console.WriteLine($"\nВы исчерпали все попытки. Загаданное число было {secretNumber}.");
            player.Money -= bet;
            Console.WriteLine($"Ваш баланс: {player.Money}");
        }
    }
}