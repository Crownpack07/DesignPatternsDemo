using DesignPatternsDemo.Domain.Meals;
using DesignPatternsDemo.Prototypes.MealPrototypes;

namespace DesignPatternsDemo.Builders.MealBuilders
{
    public class SpicyMealBurgerBuilder : IMealBuilder
    {
        private Meal _meal = new Meal();
        private IBurgerPrototype _burgerPrototype;

        public SpicyMealBurgerBuilder(IBurgerPrototype burgerPrototype)
        {
            _burgerPrototype = burgerPrototype;
        }

        public void BuildBurger()
        {
            var spicyBurger = (Burger)_burgerPrototype.Clone();

            spicyBurger.Sauce = "Spicy Sriracha";

            this._meal.Burger = spicyBurger.GetBurger();
        }

        public void BuildDrink()
        {
            this._meal.Drink = "Cola";
        }

        public void BuildSide()
        {
            this._meal.Side = "Curly Fries";
        }

        public Meal GetMeal()
        {
            return this._meal;
        }
    }
}
