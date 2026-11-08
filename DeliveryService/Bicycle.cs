namespace Delivery
{
    internal class Bicycle : Transport
    {
        const int Cost = 20;
        const int CostPerKm = 5;
        const int MaxDistance = 10;
        const int WeightLimit = 10;
        public Bicycle() : base(WeightLimit) { }
        public override double CalculateCost(Order order)
        {
            return Cost + (CostPerKm * order.Distance);
        }
        public override bool CanTake(Order order)
        {
            if (order.Distance <= MaxDistance && order.Weight <= MaxWeight)
                return true;
            return false;
        }
    }
}
