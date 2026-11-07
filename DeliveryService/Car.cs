namespace Delivery
{
    internal class Car : Transport
    {
        private int _cost = 50;
        private int _costPerKm = 8;
        private int _costPerKg = 1;
        const int _maxWeight = 300;
        public Car() : base(_maxWeight) { }
        public override double CalculateCost(Order order)
        {
            return _cost + (_costPerKm * order.Distance) + (_costPerKg * order.Weight);
        }
    }
}
