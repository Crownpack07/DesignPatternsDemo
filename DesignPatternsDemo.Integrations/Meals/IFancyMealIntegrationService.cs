using DesignPatternsDemo.Integrations.Models;

namespace DesignPatternsDemo.Integrations.Meals
{
    public interface IFancyMealIntegrationService
    {
        FancyBurgerReadModel GetFancyBurgerDetails();
    }
}
