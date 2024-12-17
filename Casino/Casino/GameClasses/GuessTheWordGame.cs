using System.Security.Cryptography.X509Certificates;
using PlayerClass;

namespace Casino;

public class GuessTheWord
{
    int i = 0;
    int s = 0;
    Random rnd = new Random();
    public List<string> openedletters = new List<string>();
    public List<string> wrongletters = new List<string>();
    public List<string> words = new List<string>() { "уравнение", "мышление", "творчество", "открытие", "мероприятие", "профессионал", "доказательство", "автомобиль", "парашют", "компьютер", "ресторан", "библиотека", "воспитание", "экономия", "мелодия", "справедливость"};
    public GuessTheWord()
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
        string word = words[rnd.Next(0, words.Count() - 1)];
        int i = 0;
        int s = 0;
        Console.WriteLine(Text(word));

        while (i <= 10 && s != word.Count())
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
            Console.WriteLine(Text(word));
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