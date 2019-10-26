using System.Collections.Generic;

namespace Bakery
{
    public class SmallCake : Cake
    {
        SmallCake()
        {
            BakeTime = 15;
            Cost = 25;
            CakeIngredients = new List<Ingredient>() { new Sugar(), new Butter() };
        }

        
    }

}
