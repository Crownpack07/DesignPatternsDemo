using DesignPatternsDemo.Prototypes.MealPrototypes;

namespace DesignPatternsDemo.Domain.Meals
{
    public class Burger: IBurgerPrototype
    {
        public string Name { get; set; } = string.Empty;
        public string Sauce { get; set; } = string.Empty;

        public IBurgerPrototype Clone()
        {
            return (IBurgerPrototype)this.MemberwiseClone();
        }

        public Burger GetBurger()
        {
            return this;
        }
    }
}
