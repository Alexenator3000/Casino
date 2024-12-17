using PlayerClass;
using System.Numerics;
using System;
using RandomGameNameGeneratorClass;
using System.Dynamic;

namespace Casino
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RandomGameNameGenerator rndName = new RandomGameNameGenerator();
            rndName.RandomNameGenerator();
            Console.WriteLine("");
            string input = "";
            Player player = new Player();

            player.PlayerNameInsert();
            Console.WriteLine();
            player.PlayerMoneyInsert();

            while (input != "0" && !player.IsAccountDeleted)
            {
                Console.WriteLine("\nВыберите игру:");

                Console.Write("1. Игра в ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("кости");
                Console.ResetColor();
                Console.WriteLine();

                Console.Write("2. Игра в ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("камень");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(" ножницы");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(" бумага");
                Console.ResetColor();
                Console.WriteLine();

                Console.WriteLine("3. Слоты");
                Console.WriteLine("4. Блэк Джек");
                Console.WriteLine("5. Угадай слово");
                Console.WriteLine("6. Бинго");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("0. Выход");
                Console.ResetColor();
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        DiceGame diceGame = new DiceGame();
                        diceGame.Play(player);
                        break;
                    case "2":
                        RockPaperScissorsGame rpsGame = new RockPaperScissorsGame();
                        rpsGame.Play(player);
                        break;
                    case "3":
                        SlotsGame slotsGame = new SlotsGame();
                        slotsGame.Play(player);
                        break;
                    case "4":
                        BlackJack bj = new BlackJack();
                        bj.Play(player);
                        break;
                    case "5":
                        GuessTheWord guessTheWord = new GuessTheWord();
                        guessTheWord.Play(player);
                        break;
                    case "6":
                        Bingo bingo = new Bingo();
                        bingo.Play(player);
                        break;
                    case "0":
                        Console.WriteLine("До свиданья!");
                        break;
                    default:
                        Console.WriteLine("Неверный выбор.");
                        break;
                }
                player.BalanceChecker();
                if (player.IsAccountDeleted)
                {
                    return;
                }
            }
        }
    }
}