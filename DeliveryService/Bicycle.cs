namespace Delivery
{
    internal class Bicycle : Transport
    {
        const int _cost = 20;
        const int _costPerKm = 5;
        const int _maxDistance = 10;
        const int _maxWeight = 10;
        public Bicycle() : base(_maxWeight) { }
        public override double CalculateCost(Order order)
        {
            return _cost + (_costPerKm * order.Distance);
        }
        public override bool CanTake(Order order)
        {
            if (order.Distance <= _maxDistance && order.Weight <= MaxWeight)
                return true;
            return false;
        }
    }
}
