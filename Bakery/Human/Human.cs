namespace Bakery
{
    public abstract class Human
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public abstract void ProcessOrder(Order order);
    }
}
