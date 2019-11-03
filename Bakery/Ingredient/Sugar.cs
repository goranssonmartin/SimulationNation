namespace BakeryLibrary
{
    public sealed class Sugar : Ingredient
    {
        public override string Name { get; set; }
        public override int Cost { get; set; }

        private Sugar()
        {
            Name = "Sugar";
            Cost = 5;
        }

        private static Sugar instance;

        public static Sugar GetInstance()
        {
            if (instance == null)
            {
                instance = new Sugar();
            }
            return instance;
        }
    }
}
