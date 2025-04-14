using DesignPatternsDemo.Domain.Meals;

namespace DesignPatternsDemo.Builders.MealBuilders
{
    public class SmallMealBuilder : IMealBuilder
    {
        private Meal _meal = new();

        public void BuildBurger()
        {
            this._meal.Burger = "Small Burger";
        }

        public void BuildDrink()
        {
            this._meal.Drink = "Small Drink";
        }

        public void BuildSide()
        {
            this._meal.Side = "Small Side";
        }

        public Meal GetMeal()
        {
            return this._meal;
        }
    }
}
