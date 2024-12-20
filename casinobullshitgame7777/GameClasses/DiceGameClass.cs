﻿using PlayerClass;
using System;

namespace Casino
{
    public class DiceGame
    {
        private Random random = new Random();

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

            int dice1 = random.Next(1, 7);
            int dice2 = random.Next(1, 7);
            int sum = dice1 + dice2;

            Console.WriteLine($"Выпало: {dice1} и {dice2} (сумма: {sum})");

            if (sum == 7)
            {
                player.Money += bet;
                Console.WriteLine($"Вы выиграли! Ваш баланс: {player.Money}$");
            }
            else
            {
                player.Money -= bet;
                Console.WriteLine($"Вы проиграли! Ваш баланс: {player.Money}$");
            }
            
            if (player.IsAccountDeleted)
            {
                return;
            }
        }
    }
}