using PlayerClass;

namespace Casino;

public class GuessTheWordGame
{
    int i = 0;
    int s = 0;
    Random rnd = new Random();
    public string word;
    public List<string> openedletters = new List<string>();
    public List<string> wrongletters = new List<string>();
    new public Dictionary<string, string> words = new Dictionary<string, string>()
    {
        { "уравнение", "Неотъемлемая часть математики" },
        { "мышление", "Головные процессы" },
        { "творчество", "Из него состоит всё искусство" },
        { "открытие", "Учёные совершают это каждый день" },
        { "мероприятие", "Организованное событие" },
        { "профессионал", "Он знает свое дело" },
        { "доказательство", "Без него не примут никакое обвинение" },
        {"автомобиль","Средство передвижения"},
        {"парашют", "Без него лучше не прыгать"},
        {"компьютер", "Важнейшая вещь в жизни подростка"},
        {"ресторан", "Покультурнее столовой"},
        {"библиотека", "Тссс!"},
        {"воспитание", "О некоторых лучше не думать"},
        {"экономия", "Без неё не на что не накопишь"},
        {"мелодия", "Без неё не может быть не одной песни"},
        {"справедливость", "За неё сражается бэтмэн"} };
    public GuessTheWordGame()
    {

    }

    public string Text(string word)
    {
        string txt = "";
        foreach (char l in word)
        {
            txt += "╔═╗";
        }
        txt += "\n\r";
        foreach (char l in word)
        {
            if (openedletters.Contains(l.ToString()))
            {
                txt += $"║{l}║";
            }

            else
            {
                txt += "║ ║";
            }
        }
        txt += "\n\r";
        foreach (char l in word)
        {
            txt += "╚═╝";
        }
        return txt;
    }
    public void Play(Player player)
    {
        BetCreator bc = new BetCreator();
        bc.BetCreate(player);
        i = rnd.Next(words.Count());
        s = 0;
        foreach (var f in words)
        {
            if (s == i)
            {
                word = f.Key;
                break;
            }
            else
            {
                s++;
            }
        }
        i = 0;
        s = 0;
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine($"Подсказка: {words[word]}");
        Console.WriteLine(Text(word));
        Console.ResetColor();

        while (i <= 9 && s != word.Count())
        {
            Console.WriteLine($"У вас осталось {10 - i} попыток");
            Console.WriteLine("Введите букву");
            string input = Console.ReadLine();
            if (word.Contains(input))
            {
                if (!openedletters.Contains(input))
                {
                    openedletters.Add(input);
                }
            }
            else
            {
                if (!wrongletters.Contains(input))
                {
                    wrongletters.Add(input);
                    i++;
                }
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(Text(word));
            Console.ResetColor();
            Console.WriteLine("Неверные буквы: ");
            foreach (string l in wrongletters)
            {
                Console.Write(l + " ");
            }
            Console.WriteLine("");
            s = 0;
            foreach (char l in word)
            {
                if (openedletters.Contains(l.ToString()))
                {
                    s++;
                }
            }
        }

        if (s == word.Count())
        {
            Console.WriteLine($"Вы выйграли {bc.bet}$");
            player.Money += bc.bet;
        }
        else
        {
            Console.WriteLine($"Вы проиграли {bc.bet}$");
            player.Money -= bc.bet;
        }
    }
}