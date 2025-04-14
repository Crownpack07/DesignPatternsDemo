using DesignPatternsDemo.Integrations.Meals;
using DesignPatternsDemo.Prototypes.MealPrototypes;

namespace DesignPatternsDemo.Adaptars.MealAdapters
{
    public class FancyBurgerAdapter : IBurgerPrototype
    {

        private  FancyMealIntegrationService _fancyMealIntegrationService = new FancyMealIntegrationService();

        public IBurgerPrototype Clone()
        {
            return new FancyBurgerAdapter();
        }

        public string GetBurger()
        {
            return this._fancyMealIntegrationService.GetFancyBurgerDetails();
        }
    }
}
