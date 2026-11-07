namespace Delivery
{
    internal class DeliveryService
    {
        private List<Transport> _transport = new List<Transport>();
        private List<Order> _activeOrders = new List<Order>();
        private List<Order> _history = new List<Order>();

        public void AddTransport(Transport transport)
        {
            _transport.Add(transport);
        }

        public void ShowCost(Order order)
        {
            Console.WriteLine($"\nCOST {order}");
            if (Validate(order))
            {
                Console.WriteLine($"===========\nCost of a delivery:");

                foreach (var transport in _transport)
                {
                    if (transport.CanTake(order))
                        Console.WriteLine($"------\nBy {transport}: {transport.CalculateCost(order)} hrn.");
                    else
                        Console.WriteLine($"------\n{transport} is not suitable for this order.");
                }
                Console.WriteLine("===========");
            }
        }
        public void AssignOrder(Order order, Transport transport)
        {
            Console.WriteLine($"\nASSIGN {order} -> {transport}");  
            
            if (!Validate(order))
            {
                return;
            } 
            if (!transport.CanTake(order))
            {
                Console.WriteLine($"{transport} is not suitable for this order.");
                return;
            }
            if (order.DeliveryTransport == transport)
            {
                Console.WriteLine($"{transport} is already assigned to this order.");
                return;
            }
            if (!transport.IsFree())
            {
                Console.WriteLine($"{transport} is not free right now.");
                return;
            }
            if (_activeOrders.Contains(order))
            {
                _activeOrders.Remove(order);
                order.DeliveryTransport.Release();
            }
            Console.WriteLine($"{order.Description} --> ready for delivery (by {transport}).");
            order.AssignTransport(transport);
            transport.Assign();
            _activeOrders.Add(order);
        }
        public void Deliver(Order order, IPayment payment)
        {
            Console.WriteLine($"\nDELIVER {order}");
            if (!_activeOrders.Contains(order))
            {
                Console.WriteLine("This order is not in the delivery list.");
                return;
            }
            Transport transport = order.DeliveryTransport;
            payment.Pay(transport.CalculateCost(order));
            transport.Release();
            Console.WriteLine($"--- {order.Description} were delivered. ---");
            _activeOrders.Remove(order);
            _history.Add(order);
        }
        public void ShowActive()
        {
            Console.WriteLine("\nACTIVE ORDERS: ");
            if (_activeOrders.Count == 0)
                Console.WriteLine(" . . . Nothing planned to be delivered.");
            foreach (var log in _activeOrders)
            {
                Console.WriteLine($"| Order #{log.Id}: {log.Description} |\nAbout to be delivered by {log.DeliveryTransport}, {log.DeliveryTransport.CalculateCost(log)} hrn.");
            }
        }
        public void ShowHistory()
        {
            Console.WriteLine("\nHISTORY: ");
            if (_history.Count == 0)
                Console.WriteLine(" . . . Nothing has been delivered yet.");
            foreach (var log in _history)
            {
                Console.WriteLine($"| Order #{log.Id}: {log.Description} |\nWere delivered by {log.DeliveryTransport}, {log.DeliveryTransport.CalculateCost(log)} hrn.");
            }
        }
        private bool Validate (Order order)
        {
            if (order.Weight <= 0)
            {
                Console.WriteLine($" ! Weight must be more than 0.");
                return false;
            }
            if (order.Distance <= 0)
            {
                Console.WriteLine($" ! Distance must be more than 0.");
                return false;
            }
            return true;
        }  
    }
}
