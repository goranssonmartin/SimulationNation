namespace Bakery
{
    public class LargeCake : Cake
    {

        LargeCake()
        {
            bakeTime = 50;
            cost = 150;
            CakeIngredients.Add(new Sugar());
            CakeIngredients.Add(new Sugar());
            CakeIngredients.Add(new Butter());
            CakeIngredients.Add(new Butter());
            CakeIngredients.Add(new Egg());
            CakeIngredients.Add(new Egg());
            CakeIngredients.Add(new Egg());
        }
    }
}
