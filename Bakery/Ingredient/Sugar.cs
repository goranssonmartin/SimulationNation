namespace Bakery
{
    public class Sugar : IIngredient
    {
        public Sugar()
        {
            Name = "Sugar";
            Cost = 10;
        }
        public string Name
        {
            get
            {
                return "Sugar";
            }
            set
            {
            }
        }
        public int Cost
        {
            get
            {
                return 10;
            }
            set
            {
            }
        }


    }
}
