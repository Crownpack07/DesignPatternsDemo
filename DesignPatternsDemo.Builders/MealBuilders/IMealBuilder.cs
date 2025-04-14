using DesignPatternsDemo.Domain.Meals;

namespace DesignPatternsDemo.Builders.MealBuilders
{
    public interface IMealBuilder
    {
        void BuildBurger();
        void BuildDrink();
        void BuildSide();
        Meal GetMeal();
    }
}
