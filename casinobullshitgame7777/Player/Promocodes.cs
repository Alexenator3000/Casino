using PlayerClass;

namespace Casino
{
    public class Promocodes
    {
        public Dictionary<string, bool> promocodes = new Dictionary<string, bool>() { { "Goyda", false }, { "Penisex", false }, { "Negripidori", false }, { "ZOV", false }, { "Oxlobistin crush", false } };

        public void UsePromo(Player player)
        {
            Console.WriteLine("Введите промокод");
            string input = Console.ReadLine();
            switch (input)
            {
                case "Goyda":
                    if (promocodes[input] == false)
                    {
                        Console.WriteLine($"Вы ввели промо-код {input}. +500");
                        promocodes[input] = true;
                        player.Money += 500;
                        Console.WriteLine($"Баланс: {player.Money}");
                    }
                    break;
                case "Penisex":
                    if (promocodes[input] == false)
                    {
                        Console.WriteLine($"Вы ввели промо-код {input}. +500");
                        promocodes[input] = true;
                        player.Money += 500;
                        Console.WriteLine($"Баланс: {player.Money}");
                    }
                    break;
                case "Negripidori":
                    if (promocodes[input] == false)
                    {
                        Console.WriteLine($"Вы ввели промо-код {input}. +500");
                        promocodes[input] = true;
                        player.Money += 500;
                        Console.WriteLine($"Баланс: {player.Money}");
                    }
                    break;
                case "ZOV":
                    if (promocodes[input] == false)
                    {
                        Console.WriteLine($"Вы ввели промо-код {input}. +500");
                        promocodes[input] = true;
                        player.Money += 500;
                        Console.WriteLine($"Баланс: {player.Money}");
                    }
                    break;
                case "Oxlobistin crush":
                    if (promocodes[input] == false)
                    {
                        Console.WriteLine($"Вы ввели промо-код {input}. +500");
                        promocodes[input] = true;
                        player.Money += 500;
                        Console.WriteLine($"Баланс: {player.Money}");
                    }
                    break;
                default:
                    Console.WriteLine("Неверный код!");
                    break;
            }
        }
    }
}
