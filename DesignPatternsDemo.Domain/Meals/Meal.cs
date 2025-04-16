using System.IO;

namespace DesignPatternsDemo.Domain.Meals
{
    public class Meal
    {
        public Burger Burger { get; set; } = null!;
        public string? Drink { get; set; }
        public string? Side { get; set; }

        public override string ToString()
        {
            return $"{Burger}" +
                   (Drink != null ? $" with {Drink}" : "") +
                   (Side != null ? $" and {Side} on the side." : "");
        }
    }
}
