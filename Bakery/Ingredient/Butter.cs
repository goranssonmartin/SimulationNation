namespace Bakery
{
    public class Butter : IIngredient
    {
        public Butter()
        {
            Name = "Butter";
            Cost = 20;
        }

        public string Name
        {
            get
            {
                return "Butter";
            }
            set
            {
            }
        }
        public int Cost
        {
            get
            {
                return 20;
            }
            set
            {
            }
        }

    }
}
