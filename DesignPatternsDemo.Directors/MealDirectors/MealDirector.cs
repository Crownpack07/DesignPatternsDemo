using DesignPatternsDemo.Builders.MealBuilders;
using DesignPatternsDemo.Domain.Meals;

namespace DesignPatternsDemo.Directors.MealDirectors
{
    public class MealDirector
    {
        private readonly IMealBuilder _builder;

        public MealDirector(IMealBuilder builder)
        {
            _builder = builder;
        }

        public Meal Construct()
        {
            _builder.BuildBurger();
            _builder.BuildDrink();
            _builder.BuildSide();
            return _builder.GetMeal();
        }
    }
}
