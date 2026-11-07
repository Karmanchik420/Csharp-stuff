namespace HunterGame
{
    internal class Menu
    {
        private Hunter _hunter;
        public Menu(Hunter hunter) 
        {
            _hunter = hunter;
        }
        public void Run()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("------\n1. Hunt\n2. Buy arrows\n3. Sell hares\n4. Info\n5. Contest mode\n6. Clear the console\n0. Exit\n------");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\nHow many times?");
                        if (int.TryParse(Console.ReadLine(), out int shots))
                        {
                            _hunter.Hunt(shots);
                        }
                        else
                        {
                            Console.WriteLine("Enter a number.");
                        }
                        break;

                    case "2":
                        Console.WriteLine("\nHow many arrows do you want to buy?");
                        if (int.TryParse(Console.ReadLine(), out int amount))
                        {
                            _hunter.BuyArrows(amount);
                        }
                        else
                        {
                            Console.WriteLine("Enter a number.");
                        }
                        break;
                    case "3":
                        Console.WriteLine("\nHow many hares do you want to sell?");
                        if (int.TryParse(Console.ReadLine(), out int hares))
                        {
                            _hunter.SellLoot(hares);
                        }
                        else
                        {
                            Console.WriteLine("Enter a number.");
                        }
                        break;
                    case "4":
                        _hunter.ShowInfo();
                        break;
                    case "5":
                        Contest contest = new Contest();
                        contest.AddHunter(new Hunter(_hunter.Name));
                        Console.WriteLine("\nHow many hunters are against you in the contest?");
                        if (int.TryParse(Console.ReadLine(), out int hunterCount))
                        {
                            for(int i = 0; i < hunterCount; ++i)
                            {
                                Console.WriteLine($"Name of a hunter {i+1}: ");
                                string name = Console.ReadLine();
                                while (string.IsNullOrWhiteSpace(name))
                                {
                                    Console.WriteLine("Please enter a name.");
                                    name = Console.ReadLine();
                                }
                                Hunter hunter = new Hunter(name);
                                contest.AddHunter(hunter);
                            }
                            Console.WriteLine("How many rounds?");
                            if (int.TryParse(Console.ReadLine(), out int rounds))
                                contest.HuntersBattle(rounds);
                            else
                                Console.WriteLine("Enter a number.");
                        }
                        else
                        {
                            Console.WriteLine("Enter a number.");
                        }
                        
                        break;
                    case "6":
                        Console.Clear();
                        break;
                    case "0":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Please choose a number from 0 to 6.");
                        break;
                }
            }
        }
        public Hunter HunterCreation()
        {
            Console.WriteLine("Enter hunter's name: ");
            string name = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Please enter a name..");

            }
            Hunter hunter = new Hunter(name);
            hunter.ShowInfo();
            return hunter;
        }
    }
}
