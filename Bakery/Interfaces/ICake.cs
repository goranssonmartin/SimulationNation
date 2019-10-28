using System.Collections.Generic;

namespace Bakery
{
    public interface ICake
    {

        int Cost { get; set; }
        int BakeTime { get; set; }
        List<IIngredient> CakeIngredients { get; set; }
    }
}