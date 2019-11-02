namespace BakeryLibrary
{
    public class Butter : IIngredient
    {
        public Butter()
        {
            Name = "Butter";
            Cost = 15;
        }

        public string Name { get; set; }
        public int Cost { get; set; }

    }
}
