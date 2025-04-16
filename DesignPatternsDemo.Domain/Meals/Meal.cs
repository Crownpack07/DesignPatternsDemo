using System.IO;

namespace DesignPatternsDemo.Domain.Meals
{
    public class Meal
    {
        public string Burger { get; set; } = string.Empty;
        public string? Drink { get; set; }
        public string? Side { get; set; }

        public override string ToString()
        {
            return $"{Burger}" +
                   (Drink != null ? $"with {Drink}" : "") +
                   (Side != null ? $"and {Side} on the side." : "");
        }
    }
}
