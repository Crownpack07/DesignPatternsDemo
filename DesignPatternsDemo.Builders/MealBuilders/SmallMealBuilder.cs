using DesignPatternsDemo.Domain.Meals;
using DesignPatternsDemo.Prototypes.MealPrototypes;

namespace DesignPatternsDemo.Builders.MealBuilders
{
    public class SmallMealBuilder : IMealBuilder
    {
        protected Meal Meal { get; set; } = new Meal();
        protected IBurgerPrototype _burgerPrototype;

        public SmallMealBuilder(IBurgerPrototype burgerPrototype)
        {
            this._burgerPrototype = burgerPrototype;
        }

        public void BuildBurger()
        {
            var burger = (Burger)this._burgerPrototype.BuildBaseBurger();

            this.Meal.Burger = burger.GetBurger();
        }

        public void BuildDrink()
        {
            this.Meal.Drink = "Small Drink";
        }

        public void BuildSide()
        {
            this.Meal.Side = "Small Side";
        }

        public Meal GetMeal()
        {
            return this.Meal;
        }
    }
}
