namespace Delivery
{
    internal class Order
    {
        private int _id;
        private string _description;
        private double _weight;
        private int _distance;
        private Transport _deliveryTransport;

        public int Id => _id;
        public string Description => _description;
        public double Weight => _weight;
        public int Distance => _distance;
        public Transport DeliveryTransport => _deliveryTransport;

        public Order(int id, string desc, double weight, int dist)
        {
            _id = id;
            _description = desc;
            _weight = weight;
            _distance = dist;
        }
        public void AssignTransport(Transport transport)
        {
            _deliveryTransport = transport;
        }
        public override string ToString()
        {
            if (_deliveryTransport == null)
                return $"#{Id} \"{Description}\" ({Weight} kg, {Distance} km)";
            return $"#{Id} \"{Description}\" ({Weight} kg, {Distance} km)\nDelivery transport: {DeliveryTransport}";
        }
    }
}
