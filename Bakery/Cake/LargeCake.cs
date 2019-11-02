using System.Collections.Generic;

namespace BakeryLibrary
{
    public class LargeCake : ICake
    {
        public int Cost { get; set; }

        public int BakeTime { get; set; }
        public List<IIngredient> CakeIngredients { get; set; }

        public LargeCake()
        {
            Cost = 250;
            BakeTime = 50;
            CakeIngredients = new List<IIngredient>() { new Sugar(), new Sugar(), new Butter(), new Butter(), new Egg(), new Egg(), new Egg() };
        }
    }


}

