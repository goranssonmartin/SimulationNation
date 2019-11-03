using System.Collections.Generic;

namespace BakeryLibrary
{
    public class SmallCake : ICake
    {
        public int Cost { get; set; }

        public int BakeTime { get; set; }
        public List<Ingredient> CakeIngredients { get; set; }
        private Sugar sugar = Sugar.GetInstance();
        private Butter butter = Butter.GetInstance();
        public SmallCake()
        {
            Cost = 90;
            BakeTime = 15;
            CakeIngredients = new List<Ingredient>() { sugar, butter};
        }


    }

}
