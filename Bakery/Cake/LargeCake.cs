using System.Collections.Generic;

namespace Bakery
{
    public class LargeCake : ICake
    {
        public int Cost
        {
            get
            {
                return 200;
            }
            set
            {

            }
        }

        public int BakeTime
        {
            get
            {
                return 50;
            }
            set
            {

            }
        }
        public List<IIngredient> CakeIngredients
        {
            get
            {
                return new List<IIngredient>() { new Sugar(), new Sugar(), new Butter(), new Butter(), new Egg(), new Egg(), new Egg() };

            }
            set
            {

            }
        }
    }
}
