using System.Collections.Generic;

namespace BakeryLibrary
{
    public class LargeCake : ICake
    {
        public int Cost { get; set; }

        public int BakeTime { get; set; }
        public List<Ingredient> CakeIngredients { get; set; }
        private Sugar sugar = Sugar.GetInstance();
        private Butter butter = Butter.GetInstance();
        private Egg egg = Egg.GetInstance();

        public LargeCake()
        {
            Cost = 250;
            BakeTime = 50;
            CakeIngredients = new List<Ingredient>() { sugar, sugar, butter, butter, egg, egg, egg};
        }
    }


}

