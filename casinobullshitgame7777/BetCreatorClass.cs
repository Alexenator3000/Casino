using PlayerClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public class BetCreator
    {
        public int bet;
        public BetCreator()
        {

        }

        public void BetCreate(Player player)
        {
            Console.WriteLine($"\nВаш баланс: {player.Money}$");
            Console.WriteLine("Сколько вы хотите поставить?");

            if (!int.TryParse(Console.ReadLine(), out bet))
            {
                Console.WriteLine("Некорректная сумма ставки.");
                return;
            }

            if (bet <= 0 || bet > player.Money)
            {
                Console.WriteLine("Некорректная ставка. Сумма должна быть больше нуля и не превышать ваш баланс.");
                return;
            }
        }
    }
}
