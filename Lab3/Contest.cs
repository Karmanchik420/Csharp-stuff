using System.Numerics;

namespace HunterGame
{
    internal class Contest
    {
        private List<Hunter> _hunters;
        public Contest()
        {
            _hunters = new List<Hunter>();
        }
        public void AddHunter(Hunter hunter)
        {
            _hunters.Add(hunter);
        }
        public void RemoveHunter(Hunter hunter)
        {
            _hunters.Remove(hunter);
        }
        public void HuntersBattle(int rounds)
        {
            if (rounds <= 0)
            {
                Console.WriteLine("There must be at least 1 round.");
                return;
            }
            if (_hunters.Count < 2)
            {
                Console.WriteLine("There must be at least 2 hunters.");
                return;
            }

            foreach (Hunter h in _hunters)
                h.ShowInfo();

            for (int i = 0; i < rounds; ++i)
            {
                foreach (Hunter h in _hunters)
                {
                    if ((h.Arrows == 0 && h.Gold == 0 && h.Loot == 0) || h.Health <= 0)
                        continue;
                    if (h.Loot > 0)
                        h.SellLoot(h.Loot);
                    if (h.Arrows == 0 && h.Gold > 0)
                        h.BuyArrows(h.Gold);
                    h.Hunt(1);
                }
            }

            foreach (Hunter h in _hunters)
                h.ShowInfo();

            ShowWinner();
        }
        private void ShowWinner()
        {
            int maxHunted = 0;
            int winners = 0;
            Hunter winner = _hunters[0];
            foreach (Hunter h in _hunters)
            {
                if (h.TotalHunted > maxHunted)
                    maxHunted = h.TotalHunted;

            }
            if (maxHunted == 0)
            {
                Console.WriteLine("Nobody managed to successfully hunt.");
                return;
            }
            foreach (Hunter h in _hunters)
            {
                if (h.TotalHunted == maxHunted)
                {
                    winner = h;
                    winners++;
                }
                if (winners > 1)
                {
                    Console.WriteLine("Draw!");
                    return;
                }
            }
            Console.WriteLine($"The winner is {winner.Name} with total hunted {winner.TotalHunted} hares!");
        }
    }
}
