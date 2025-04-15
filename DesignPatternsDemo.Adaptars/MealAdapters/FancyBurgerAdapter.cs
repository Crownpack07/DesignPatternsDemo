using DesignPatternsDemo.Domain.Meals;
using DesignPatternsDemo.Integrations.Meals;
using DesignPatternsDemo.Prototypes.MealPrototypes;

namespace DesignPatternsDemo.Adaptars.MealAdapters
{
    public class FancyBurgerAdapter : IBaseAdapter
    {
        private  FancyMealIntegrationService _fancyMealIntegrationService = new FancyMealIntegrationService();

        public IBurgerPrototype BuildBaseBurger()
        {
            var fancyDetails = this._fancyMealIntegrationService.GetFancyBurgerDetails();

            return new Burger
            {
                Name = fancyDetails.FancyBurgerName,
                Sauce = fancyDetails.FancyBurgerSauce
            };
        }
    }
}
