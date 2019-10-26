using System.Collections.Generic;

namespace Bakery
{
    public class Cake
    {
        public int Cost { get; protected set; }
        public int BakeTime { get; protected set; }
        public List<Ingredient> CakeIngredients { get; protected set; }
    }


}
