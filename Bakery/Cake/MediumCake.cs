using System.Collections.Generic;

namespace BakeryLibrary
{
    public class MediumCake : ICake
    {
        public int Cost { get; set; }

        public int BakeTime { get; set; }
        public List<IIngredient> CakeIngredients { get; set; }

        public MediumCake() {
            Cost = 150;
            BakeTime = 25;
            CakeIngredients=new List<IIngredient>() { new Sugar(), new Butter(), new Egg() };
        }
        

    }
}
