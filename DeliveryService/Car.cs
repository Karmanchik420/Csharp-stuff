namespace Delivery
{
    internal class Car : Transport
    {
        const int Cost = 50;
        const int CostPerKm = 8;
        const int CostPerKg = 1;
        const int WeightLimit = 300;
        public Car() : base(WeightLimit) { }
        public override double CalculateCost(Order order)
        {
            return Cost + (CostPerKm * order.Distance) + (CostPerKg * order.Weight);
        }
    }
}
