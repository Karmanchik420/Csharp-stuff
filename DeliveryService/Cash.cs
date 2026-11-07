namespace Delivery
{
    internal class Cash : IPayment
    {
        public void Pay(double sum)
        {
            Console.WriteLine($"   Paid {sum} hrn with cash.");
        }
    }
}
