using System.Collections.Generic;

namespace BakeryLibrary
{
    public interface ICake
    {
        int Cost { get; set; }
        int BakeTime { get; set; }
        List<Ingredient> CakeIngredients { get; set; }
    }
}