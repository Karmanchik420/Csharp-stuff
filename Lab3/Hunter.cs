namespace HunterGame
{
    internal class Hunter
    {
        private string _name;
        private int _health = 100;
        private int _gold = 0;
        private int _arrows = 10;
        private int _loot = 0;
        private int _totalHunted = 0;
        const int ArrowPrice = 1;
        const int HarePrice = 3;
        private static readonly Random _rnd = new Random();
        public string Name
        {
            get { return _name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Enter valid name.");
                _name = value;
            }
        }
        public int Health => _health;
        public int Gold => _gold;
        public int Arrows => _arrows;
        public int Loot => _loot;
        public int TotalHunted => _totalHunted;

        public Hunter(string name)
        {
            Name = name;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"===========\nName: {_name}\nHealth: {_health}\nGold: {_gold}\nArrows: {_arrows}\nLoot: {_loot}\nTotal hunted: {_totalHunted}\n===========");
        }
        public void Hunt(int shots)
        {
            if (shots <= 0)
            {
                Console.WriteLine($"{_name} must hunt at least once.");
                return;
            }
            else if (_arrows <= 0)
            {
                Console.WriteLine($"{_name} has no arrows to hunt.");
                return;
            }
            else if (_health <= 0)
            {
                Console.WriteLine($"{_name}'s health is too low to hunt.");
                return;
            }
            int caught = 0;
            for (int i = 0; i < shots; i++)
            {
                if (_arrows <= 0)
                {
                    Console.WriteLine($"{_name} has no arrows left.");
                    break;
                }
                else if (_health <= 0)
                {
                    Console.WriteLine($"{_name} has no health left.");
                    break;
                }
                int roll = _rnd.Next(11);

                if (roll >= 5)
                {
                    ++_loot;
                    ++_totalHunted;
                    ++caught;
                    Console.WriteLine($"{_name}'s arrow hits a hare! (+1 hare)");
                }
                else
                {
                    int damage = _rnd.Next(16);
                    _health -= damage;
                    _health = Math.Max(0, _health);
                    Console.WriteLine($"{_name} missed and lost {damage} health.");
                }
                --_arrows;
            }
            Console.WriteLine($"{_name} caught {caught} hare(s).");
        }

        public void BuyArrows(int amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine($"{_name} must buy at least 1 arrow.");
                return;
            }
            else if (_gold < ArrowPrice * amount)
            {
                Console.WriteLine($"{_name} doesn't have enough gold.");
                return;
            }
            _arrows += amount;
            _gold -= ArrowPrice * amount;
            Console.WriteLine($"{_name} bought {amount} arrow(s) ({_gold} gold left).");
        }

        public void SellLoot(int hares)
        {
            if (hares <= 0)
            {
                Console.WriteLine($"{_name} must sell at least 1 hare.");
                return;
            }
            else if (_loot < hares)
            {
                Console.WriteLine($"{_name} doesn't have that many hares.");
                return;
            }
            _gold += hares * HarePrice;
            _loot -= hares;
            Console.WriteLine($"{_name} sold {hares} hare(s) for {hares * HarePrice} gold.");
        }
    }
}