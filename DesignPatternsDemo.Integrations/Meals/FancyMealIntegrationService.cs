namespace DesignPatternsDemo.Integrations.Meals
{
    public class FancyMealIntegrationService : IFancyMealIntegrationService
    {
        public string GetFancyBurgerDetails()
        {
            return "Wagyu Beef Burger with Truffle Aioli (from FancyBurgerService)";
        }
    }
}
