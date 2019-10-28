namespace Bakery
{
    public class Egg : IIngredient
    {

        public Egg()
        {
            Name = "Egg";
            Cost = 30;
        }

        public string Name
        {
            get
            {
                return "Egg";
            }
            set
            {
            }
        }
        public int Cost
        {
            get
            {
                return 30;
            }
            set
            {
            }
        }
    }
}
