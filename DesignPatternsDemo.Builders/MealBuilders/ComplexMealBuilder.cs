using DesignPatternsDemo.Domain.Meals;
using DesignPatternsDemo.Prototypes.MealPrototypes;

namespace DesignPatternsDemo.Builders.MealBuilders
{
    public class ComplexMealBuilder
    {
        private readonly Meal _meal = new();
        protected IBurgerPrototype _burgerPrototype;

        public ComplexMealBuilder(IBurgerPrototype burgerPrototype)
        {
            this._burgerPrototype = burgerPrototype;
        }

        public ComplexMealBuilder SetBurger(string name, string? sauce = null)
        {
            var burger = (Burger) _burgerPrototype.Clone();

            burger.Name = name;

            if (sauce != null)
            {
                burger.Sauce = sauce;
            }

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
