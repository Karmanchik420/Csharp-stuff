namespace Delivery
{
    abstract class Transport
    {
        protected int MaxWeight;
        protected bool Availability = true;
        protected Transport(int maxWeight)
        {
            MaxWeight = maxWeight;
        }
        public abstract double CalculateCost(Order order);
        public virtual bool CanTake(Order order)
        {
            if (order.Weight <= MaxWeight)
                return true;
            return false;
        }
        public bool IsFree()
        {
            return Availability;
        }
        public void Assign()
        {
            Availability = false;
        }
        public void Release()
        {
            Availability = true;
        }
        public override string ToString() => GetType().Name;
    }
}
