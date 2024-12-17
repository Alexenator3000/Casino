using PlayerClass;

namespace Casino
{
    public class DiceGame
    {
        private Random random = new Random();

        public void Play(Player player)
        {
            BetCreator bc = new BetCreator();
            bc.BetCreate(player);

            int dice1 = random.Next(1, 7);
            int dice2 = random.Next(1, 7);
            int sum = dice1 + dice2;

            Console.WriteLine($"Выпало: {dice1} и {dice2} (сумма: {sum})");

            if (sum == 7)
            {
                player.Money += bc.bet;
                Console.WriteLine($"Вы выиграли {bc.bet}$! Ваш баланс: {player.Money}$");
            }
            else
            {
                player.Money -= bc.bet;
                Console.WriteLine($"Вы проиграли8 {bc.bet}$! Ваш баланс: {player.Money}$");
            }
            
        }
    }
}