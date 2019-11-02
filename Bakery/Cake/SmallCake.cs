using System.Collections.Generic;

namespace BakeryLibrary
{
    public class SmallCake : ICake
    {
        public int Cost { get; set; }

        public int BakeTime { get; set; }
        public List<IIngredient> CakeIngredients { get; set; }

        public SmallCake()
        {
            Cost = 90;
            BakeTime = 15;
            CakeIngredients = new List<IIngredient>() { new Sugar(), new Butter() };
        }


    }

}
