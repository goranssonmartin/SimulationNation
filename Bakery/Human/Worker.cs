namespace Bakery
{
    public abstract class Worker
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual int Quality { get { return 1; } set { } }

        public int Salary { get { return Quality * 500; } set { } }

        public abstract void ProcessOrder();
    }
}
