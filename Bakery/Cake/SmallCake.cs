using System.Collections.Generic;

namespace Bakery
{
    public class SmallCake : ICake
    {
        public int Cost
        {
            get
            {
                return 60;
            }
            set
            {

            }
        }

        public int BakeTime
        {
            get
            {
                return 15;
            }
            set
            {

            }
        }
        public List<IIngredient> CakeIngredients
        {
            get
            {
                return new List<IIngredient>() { new Sugar(), new Butter() };
            }
            set
            {

            }
        }


    }

}
