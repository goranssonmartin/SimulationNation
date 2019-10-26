namespace Bakery
{
    public class MediumCake : Cake
    {
        MediumCake()
        {
            bakeTime = 25;
            cost = 50;
            CakeIngredients.Add(new Sugar());
            CakeIngredients.Add(new Butter());
            CakeIngredients.Add(new Egg());
        }

    }
}
