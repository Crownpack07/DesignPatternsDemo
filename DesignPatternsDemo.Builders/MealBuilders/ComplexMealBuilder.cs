using DesignPatternsDemo.Domain.Meals;

namespace DesignPatternsDemo.Builders.MealBuilders
{
    public class ComplexMealBuilder
    {
        private readonly Meal _meal = new();

        public ComplexMealBuilder SetBurger(string burger)
        {
            this._meal.Burger = burger;
            return this;
        }

        public ComplexMealBuilder SetDrink(string drink)
        {
            this._meal.Drink = drink;
            return this;
        }

        public ComplexMealBuilder SetSide(string side)
        {
            this._meal.Side = side;
            return this;
        }

        public Meal Build()
        {
            return _meal;
        }
    }
}
