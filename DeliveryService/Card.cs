namespace Delivery
{
    internal class Card : IPayment
    {
        public void Pay(double sum)
        {
            Console.WriteLine($"   Paid {sum} hrn by card.");
        }
    }
}
