using PlayerClass;
using System.Numerics;
using System;
using System.Dynamic;
using CasinoCore;
using Avalonia;

namespace Casino
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartWarning st = new StartWarning();
            st.OnStartGameWarning();
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

                Console.Write("1. ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Kости");
                Console.ResetColor();
                Console.WriteLine();

                Console.Write("2. ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Kамень");
                Console.Write(" ножницы");
                Console.Write(" бумага");
                Console.ResetColor();
                Console.WriteLine();
                
                Console.Write("3. ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Слоты");
                Console.WriteLine();
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("4. Блэк");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Джек");
                Console.ResetColor();
                Console.WriteLine();

                Console.Write("5. ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("С");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("3");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("K");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("P");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("3");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("T");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("H");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("0");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("3 ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Ч");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("N");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("С");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("Л");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("O");
                Console.WriteLine();
                Console.ResetColor();

                Console.Write("6. ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("П");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("о");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Л");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("е ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Ч");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("у");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Д");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("е");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("C");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine();
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("7. Бинго");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("8. Ввести промо-код");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("9. Настройки");
                Console.ResetColor();

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
                        BlackJackGame blackJackGame = new BlackJackGame(); 
                        blackJackGame.Play(player);
                        break;
                    case "5":
                        GuessTheNumberGame theNumberGame = new GuessTheNumberGame();
                        theNumberGame.Play(player);
                        break;
                    case "6":
                        GuessTheWordGame theWordGame = new GuessTheWordGame();
                        theWordGame.Play(player);
                        break;
                    case "7":
                        BingoGame bingo = new BingoGame();
                        bingo.Play(player);
                        break;
                    case "8":
                        Promocodes promocodes = new Promocodes();
                        promocodes.UsePromo(player);
                        break;
                    case "9":
                        SettingsMenu(player);
                        break;
                    case "0":
                        Console.WriteLine("До свиданья!");
                        player.Save();
                        break;
                    default:
                        Console.WriteLine("Неверный выбор.");
                        break;
                        
                }
            }
        }
        static void SettingsMenu(Player player)
        {
            string input;
            do
            {
                Console.WriteLine("\nМеню настроек:");
                Console.WriteLine("1. Удалить профиль и начать новый");
                Console.WriteLine("0. Вернуться в главное меню");
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        if (File.Exists("playerData.json"))
                        {
                            File.Delete("playerData.json");
                        }
                        player.IsAccountDeleted = true; 
                        Console.WriteLine("Профиль удален.  Начните новую игру.");
                        break;

                    case "0":
                        Console.WriteLine("Возвращение в главное меню...");
                        break;

                    default:
                        Console.WriteLine("Неверный выбор.");
                        break;
                }
            } while (input != "0");
        }
    }
}