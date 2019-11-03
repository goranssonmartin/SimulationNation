namespace BakeryLibrary
{
    public sealed class Egg : Ingredient
    {
        public override string Name { get; set; }
        public override int Cost { get; set; }

        private Egg()
        {
            Name = "Egg";
            Cost = 20;
        }
        
        private static Egg instance;

        public static Egg GetInstance()
        {
            if (instance == null)
            {
                instance = new Egg();
            }
            return instance;
        }

    }
}
