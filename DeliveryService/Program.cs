namespace Delivery
{
    internal class Program
    {
        static void Main()
        {
            DeliveryService service = new DeliveryService();

            Bicycle bike = new Bicycle();
            Car car = new Car();
            Truck truck1 = new Truck();
            Truck truck2 = new Truck();

            service.AddTransport(bike);
            service.AddTransport(car);
            service.AddTransport(truck1);
            service.AddTransport(truck2);

            Order small = new Order(1, "Documents", 2, 5);
            Order far = new Order(2, "Flowers", 3, 25);
            Order heavy = new Order(3, "Microwave", 150, 12);
            Order huge = new Order(4, "Furniture", 1000, 30);
            Order tooBig = new Order(5, "Machinery", 10000, 40);
            Order badWeight = new Order(6, "Empty box", 0, 10);
            Order badDist = new Order(7, "Parcel", 5, -5);

            Cash cash = new Cash();
            Card card = new Card();

            Console.WriteLine("---------------- Пустi списки ----------------");
            service.ShowHistory();
            service.ShowActive();

            Console.WriteLine("\n---------------- Цiна доставки ----------------");
            service.ShowCost(small);
            service.ShowCost(far);
            service.ShowCost(heavy);
            service.ShowCost(huge);
            service.ShowCost(tooBig);
            service.ShowCost(badWeight);
            service.ShowCost(badDist);

            Console.WriteLine("\n---------------- Некоректнi призначення ----------------");
            service.AssignOrder(badWeight, car);
            service.AssignOrder(badDist, car);

            Console.WriteLine("\n---------------- Непiдходящий транспорт ----------------");
            service.AssignOrder(heavy, bike);
            service.AssignOrder(tooBig, truck1);

            Console.WriteLine("\n---------------- Типовий сценарiй ----------------");
            service.AssignOrder(small, car);
            service.ShowActive();
            service.Deliver(small, card);

            Console.WriteLine("\n---------------- Зайнятий транспорт ----------------");
            service.AssignOrder(far, car);
            service.AssignOrder(heavy, car);

            Console.WriteLine("\n---------------- Призначення iншого транспорту ----------------");
            service.AssignOrder(far, truck1);
            service.AssignOrder(heavy, car);
            service.ShowActive();

            Console.WriteLine("\n---------------- Призначення на той самий транспорт ----------------");
            service.AssignOrder(far, truck1);

            Console.WriteLine("\n---------------- Доставка з cash; неактивного замовлення ----------------");
            service.Deliver(far, cash);
            service.Deliver(far, cash);
            service.Deliver(huge, cash);

            Console.WriteLine("\n---------------- Iсторiя ----------------");

            service.ShowHistory();
            service.ShowActive();
        }
    }
}
