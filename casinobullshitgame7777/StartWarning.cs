namespace CasinoCore
{
    public class StartWarning
    {
        public void OnStartGameWarning()
        {
            Console.WriteLine("Перед тем как начать игру, рекомендуется открыть игру на весь " +
                "экран с помощью F11 и приблизить сам текст с помощью " +
                "колесика мыши и ctrl");
            Console.WriteLine("Убедитесь что вы все сделали и выведите 1 в консоль:");
            string userInput = Console.ReadLine();
            if (userInput == "1")
            {
                Console.WriteLine("Удачной игры!");
                Console.Clear();
            }
        }
        
    }
}
