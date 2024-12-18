using PlayerClass;

namespace Casino
{
    public class BingoGame
    {
        int total_score;
        public List<string> scores = new List<string>() { "+10", "+20", "+30", "+50", "-99", "-10", "-20", "-30", "-50" };
        public List<string> slots = new List<string>() { "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   " };
        Random rnd = new Random();
        public BingoGame()
        {

        }

        public void Play(Player player)
        {
            BetCreator bc = new BetCreator();
            bc.BetCreate(player);
            int i = 0;
            while (i != 3)
            {
                Console.WriteLine($" ╔═══╗╔═══╗╔═══╗\n\r ║{slots[0]}║║{slots[1]}║║{slots[2]}║\n\r ╚═══╝╚═══╝╚═══╝");
                Console.WriteLine($" ╔═══╗╔═══╗╔═══╗\n\r ║{slots[3]}║║{slots[4]}║║{slots[5]}║\n\r ╚═══╝╚═══╝╚═══╝");
                Console.WriteLine($" ╔═══╗╔═══╗╔═══╗\n\r ║{slots[6]}║║{slots[7]}║║{slots[8]}║\n\r ╚═══╝╚═══╝╚═══╝");
                Console.WriteLine("Какой слот вы хотите открыть?");
                switch (Console.ReadLine())
                {
                    case "1":
                        if (slots[0] == "   ")
                        {
                            slots[0] = scores[rnd.Next(0, scores.Count() - 1)];
                            scores.Remove(slots[0]);
                            break;
                        }
                        else
                        {
                            break;
                        }
                    case "2":
                        if (slots[1] == "   ")
                        {
                            slots[1] = scores[rnd.Next(0, scores.Count() - 1)];
                            scores.Remove(slots[1]);
                            break;
                        }
                        else
                        {
                            break;
                        }
                    case "3":
                        if (slots[2] == "   ")
                        {
                            slots[2] = scores[rnd.Next(0, scores.Count() - 1)];
                            scores.Remove(slots[2]);
                            break;
                        }
                        else
                        {
                            break;
                        }
                    case "4":
                        if (slots[3] == "   ")
                        {
                            slots[3] = scores[rnd.Next(0, scores.Count() - 1)];
                            scores.Remove(slots[3]);
                            break;
                        }
                        else
                        {
                            break;
                        }
                    case "5":
                        if (slots[4] == "   ")
                        {
                            slots[4] = scores[rnd.Next(0, scores.Count() - 1)];
                            scores.Remove(slots[4]);
                            break;
                        }
                        else
                        {
                            break;
                        }
                    case "6":
                        if (slots[5] == "   ")
                        {
                            slots[5] = scores[rnd.Next(0, scores.Count() - 1)];
                            scores.Remove(slots[5]);
                            break;
                        }
                        else
                        {
                            break;
                        }
                    case "7":
                        if (slots[6] == "   ")
                        {
                            slots[6] = scores[rnd.Next(0, scores.Count() - 1)];
                            scores.Remove(slots[6]);
                            break;
                        }
                        else
                        {
                            break;
                        }
                    case "8":
                        if (slots[7] == "   ")
                        {
                            slots[7] = scores[rnd.Next(0, scores.Count() - 1)];
                            scores.Remove(slots[7]);
                            break;
                        }
                        else
                        {
                            break;
                        }
                    case "9":
                        if (slots[8] == "   ")
                        {
                            slots[8] = scores[rnd.Next(0, scores.Count() - 1)];
                            scores.Remove(slots[8]);
                            break;
                        }
                        else
                        {
                            break;
                        }
                }

                i++;
            }
            Console.WriteLine($"╔═══╗╔═══╗╔═══╗\n\r║{slots[0]}║║{slots[1]}║║{slots[2]}║\n\r╚═══╝╚═══╝╚═══╝");
            Console.WriteLine($"╔═══╗╔═══╗╔═══╗\n\r║{slots[3]}║║{slots[4]}║║{slots[5]}║\n\r╚═══╝╚═══╝╚═══╝");
            Console.WriteLine($"╔═══╗╔═══╗╔═══╗\n\r║{slots[6]}║║{slots[7]}║║{slots[8]}║\n\r╚═══╝╚═══╝╚═══╝");

            foreach (string s in slots)
            {
                if (s == "   ")
                { }
                else
                {
                    if (s[0] == '+')
                    {
                        total_score += (s[1] - '0') * 10 + s[2] - '0';
                    }
                    else
                    {
                        total_score -= (s[1] - '0') * 10 + s[2] - '0';
                    }
                }
            }

            if (total_score > 0)
            {
                player.Money += bc.bet;
                Console.WriteLine($"Вы выйграли {bc.bet}$");
            }
            if (total_score < 0)
            {
                player.Money -= bc.bet;
                Console.WriteLine($"Вы проиграли {bc.bet}$");
            }
            if (total_score == 0)
            {
                Console.WriteLine("Вышли в ноль");
            }
        }
    }
}