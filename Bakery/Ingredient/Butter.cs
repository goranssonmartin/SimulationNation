namespace BakeryLibrary
{
    public sealed class Butter : Ingredient
    {
        public override string Name { get; set; }
        public override int Cost { get; set; }
        private Butter()
        {
            Name = "Butter";
            Cost = 15;
        }
        private static Butter instance;

        public static Butter GetInstance()
        {
            if (instance == null)
            {
                instance = new Butter();
            }
            return instance;
        }



    }
}
