using PlayerClass;

namespace Casino
{
    public class SlotsGame
    {
        Random rnd = new Random();
        Player player = new Player();

        public string slot1;
        public string slot2;
        public string slot3;
        public int score = 0;

        public SlotsGame()
        {

        }

        public string Symbols(int num)
        {

            switch (num)
            {
                case 1:
                    return " .----------------. \r\n| .--------------. |\r\n| |     __       | |\r\n| |    /  |      | |\r\n| |    `| |      | |\r\n| |     | |      | |\r\n| |    _| |_     | |\r\n| |   |_____|    | |\r\n| |              | |\r\n| '--------------' |\r\n '----------------' ";
                case 2:
                    return " .----------------. \r\n| .--------------. |\r\n| |    _____     | |\r\n| |   / ___ `.   | |\r\n| |  |_/___) |   | |\r\n| |   .'____.'   | |\r\n| |  / /____     | |\r\n| |  |_______|   | |\r\n| |              | |\r\n| '--------------' |\r\n '----------------' ";
                case 3:
                    return " .----------------. \r\n| .--------------. |\r\n| |    ______    | |\r\n| |   / ____ `.  | |\r\n| |   `'  __) |  | |\r\n| |   _  |__ '.  | |\r\n| |  | \\____) |  | |\r\n| |   \\______.'  | |\r\n| |              | |\r\n| '--------------' |\r\n '----------------' ";
                case 4:
                    return " .----------------. \r\n| .--------------. |\r\n| |   _    _     | |\r\n| |  | |  | |    | |\r\n| |  | |__| |_   | |\r\n| |  |____   _|  | |\r\n| |      _| |_   | |\r\n| |     |_____|  | |\r\n| |              | |\r\n| '--------------' |\r\n '----------------'";
                case 5:
                    return " .----------------. \r\n| .--------------. |\r\n| |   _______    | |\r\n| |  |  _____|   | |\r\n| |  | |____     | |\r\n| |  '_.____''.  | |\r\n| |  | \\____) |  | |\r\n| |   \\______.'  | |\r\n| |              | |\r\n| '--------------' |\r\n '----------------' ";
            }
            return "";
        }
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

            player.Money -= bet;

            slot1 = Symbols(rnd.Next(1, 5));
            slot2 = Symbols(rnd.Next(1, 5));
            slot3 = Symbols(rnd.Next(1, 5));

            Console.WriteLine(slot1);
            Console.WriteLine(slot2);
            Console.WriteLine(slot3);


            if (slot1 == slot2)
            {
                score += 1;
            }

            if (slot1 == slot3)
            {
                score += 1;
            }

            if (slot2 == slot3)
            {
                score += 1;
            }

            player.Money += score * bet;
            Console.WriteLine($"Ваш баланс: {player.Money}");
            
        }
    }
}