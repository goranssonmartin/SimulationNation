namespace BakeryLibrary
{
    public class Sugar : IIngredient
    {
        public Sugar()
        {
            Name = "Sugar";
            Cost = 5;
        }
        public string Name { get; set; }
        public int Cost { get; set; }


    }
}
