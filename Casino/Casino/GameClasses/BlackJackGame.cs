using PlayerClass;

namespace Casino
{
    public class BlackJack
    {
        public int i;
        private Random rnd = new Random();
        public List<string> cards1 = new List<string>() { "6♠", "6♥", "6♦", "6♣", "7♠", "7♥", "7♦", "7♣", "8♠", "8♥", "8♦", "8♣", "9♠", "9♥", "9♦", "9♣", "10♠", "10♥", "10♦", "10♣", "J♠", "J♥", "J♦", "J♣", "Q♠", "Q♥", "Q♦", "Q♣", "K♠", "K♥", "K♦", "K♣" , "A♠", "A♥", "A♦", "A♣" };
        public List<string> cards2 = new List<string>();
        public List<string> playercards = new List<string>();
        public List<string> botcards = new List<string>();
        public List<int> numbers = new List<int>() {6, 7, 8, 9, 10};
        public bool botpass, playerpass = false;
        public BlackJack()
        {

        }

        public void CardMixer()
        {
            while (cards1.Count > 0)
            {
                if (cards1.Count != 1)
                {
                    i = rnd.Next(0, cards1.Count - 1);
                }

                else
                {
                    i = 0;
                }

                cards2.Add(cards1[i]);
                cards1.RemoveAt(i);
            }

            while (cards2.Count > 0)
            {
                if (cards2.Count != 1)
                {
                    i = rnd.Next(0, cards2.Count - 1);
                }

                else
                {
                    i = 0;
                }

                cards1.Add(cards2[i]);
                cards2.RemoveAt(i);
            }
        }

        public int TotalPoints(List<string> list)
        {
            int total_points = 0;

            foreach (string s in list)
            {
                foreach (int s2 in numbers)
                {
                    if (s.Contains(s2.ToString()))
                    {
                        total_points += s2;
                        break;
                    }
                }
                if(s.Contains("K") || s.Contains("Q") || s.Contains("J"))
                {
                    total_points += 10;
                }

                if (s.Contains("A"))
                {
                    total_points += 11;
                }
            }

            return total_points;
        }

        public void Play(Player player)
        {

            BetCreator bc = new BetCreator();
            bc.BetCreate(player);

            CardMixer();
            
            int h = 0;
            playercards.Add(cards1[h]);
            playercards.Add(cards1[h + 1]);
            botcards.Add(cards1[h + 2]);
            botcards.Add(cards1[h + 3]);
            h += 4;

            Console.Write("Вот ваши карты: ");
            foreach (string i in playercards)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine("");
            Console.WriteLine($"Общий счёт {TotalPoints(playercards)}");


            while (h <= 35 & (!playerpass || !botpass))
            {
                if (!playerpass)
                {
                    Console.WriteLine("Если хотите взять карту то введите 1, если нет введите 2");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            playercards.Add(cards1[h]);
                            h++;
                            Console.Write("Вот ваши карты: ");
                            foreach (string i in playercards)
                            {
                                Console.Write($"{i} ");
                            }
                            Console.WriteLine("");
                            Console.WriteLine($"Общий счёт {TotalPoints(playercards)}");
                            break;
                        case "2":
                            playerpass = true;
                            break;
                    }
                }

                if (!botpass)
                {
                    if (TotalPoints(botcards) < 15)
                    {
                        botcards.Add(cards1[h]);
                        h++;
                    }
                    else
                    {
                        botpass = true;
                    }
                }
            }

            Console.WriteLine("Карты противника");
            foreach (string i in botcards)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine("");
            Console.WriteLine($"Общий счёт противника {TotalPoints(botcards)}");

            if (TotalPoints(botcards) > 21 && TotalPoints(playercards) > 21)
            {
                if (TotalPoints(botcards) == TotalPoints(playercards))
                {
                    Console.WriteLine("Ничья!");
                    return;
                }
                if (TotalPoints(botcards) > TotalPoints(playercards))
                {
                    Console.WriteLine($"Вы выйграли {bc.bet}$");
                    player.Money += bc.bet;
                    return;
                }
                else 
                {
                    Console.WriteLine($"Вы проиграли {bc.bet}$");
                    player.Money -= bc.bet;
                    return;
                }
            }

            if (TotalPoints(playercards) > 21)
            {
                Console.WriteLine($"Вы проиграли {bc.bet}$");
                player.Money -= bc.bet;
                return;
            }
            if (TotalPoints(botcards) > 21)
            {
                Console.WriteLine($"Вы выйграли {bc.bet}$");
                player.Money += bc.bet;
                return;
            }

            if (TotalPoints(playercards) > TotalPoints(botcards))
            {
                Console.WriteLine($"Вы выйграли {bc.bet}$");
                player.Money += bc.bet;
                return;
            }
            if (TotalPoints(playercards) == TotalPoints(botcards))
            {
                Console.WriteLine("Ничья!");
                return;
            }

            else
            {
                Console.WriteLine($"Вы проиграли {bc.bet}$");
                player.Money -= bc.bet;
                return;
            }
        }
    }
}
