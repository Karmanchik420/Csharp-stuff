namespace Delivery
{
    internal class Truck : Transport
    {
        const int Cost = 200;
        const int CostPerKm = 15;
        const double CostPerKg = 0.5;
        const int WeightLimit = 1000;
        public Truck() : base(WeightLimit) { }
        public override double CalculateCost(Order order)
        {
            return Cost + (CostPerKm * order.Distance) + (CostPerKg * order.Weight);
        }
    }
}
