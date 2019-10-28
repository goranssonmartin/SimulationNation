using System.Collections.Generic;

namespace Bakery
{
    public class MediumCake : ICake
    {

        public int Cost
        {
            get
            {
                return 100;
            }
            set
            {

            }
        }

        public int BakeTime
        {
            get
            {
                return 25;
            }
            set
            {

            }
        }
        public List<IIngredient> CakeIngredients
        {
            get
            {
                return new List<IIngredient>() { new Sugar(), new Butter(), new Egg() };

            }
            set
            {

            }
        }

    }
}
