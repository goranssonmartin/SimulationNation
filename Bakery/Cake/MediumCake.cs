using System.Collections.Generic;

namespace BakeryLibrary
{
    public class MediumCake : ICake
    {
        public int Cost { get; set; }

        public int BakeTime { get; set; }
        public List<Ingredient> CakeIngredients { get; set; }
        private Sugar sugar = Sugar.GetInstance();
        private Butter butter = Butter.GetInstance();
        private Egg egg = Egg.GetInstance();
        public MediumCake()
        {
            Cost = 150;
            BakeTime = 25;
            CakeIngredients = new List<Ingredient>() { sugar, butter, egg};
        }


    }
}
