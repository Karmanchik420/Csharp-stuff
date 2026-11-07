namespace Delivery
{
    internal class Truck : Transport
    {
        private int _cost = 200;
        private int _costPerKm = 15;
        private double _costPerKg = 0.5;
        const int _maxWeight = 1000;
        public Truck() : base(_maxWeight) { }
        public override double CalculateCost(Order order)
        {
            return _cost + (_costPerKm * order.Distance) + (_costPerKg * order.Weight);
        }
    }
}
