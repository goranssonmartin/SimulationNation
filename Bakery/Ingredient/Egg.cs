namespace BakeryLibrary
{
    public class Egg : IIngredient
    {

        public Egg()
        {
            Name = "Egg";
            Cost = 20;
        }

        public string Name { get; set; }
        public int Cost { get; set; }
    }
}
