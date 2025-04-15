using DesignPatternsDemo.Integrations.Models;

namespace DesignPatternsDemo.Integrations.Meals
{
    public class FancyMealIntegrationService : IFancyMealIntegrationService
    {
        public FancyBurgerReadModel GetFancyBurgerDetails()
        {
            return new FancyBurgerReadModel
            {
                FancyBurgerName = "Wagyu Beef",
                FancyBurgerDrink = "Wine",
                FancyBurgerSauce = "Parmasean",
                FancyBurgerSide = "Veg"
            };
        }
    }
}
