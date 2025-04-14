using DesignPatternsDemo.Adaptars.MealAdapters;
using DesignPatternsDemo.Builders.MealBuilders;
using DesignPatternsDemo.Domain.Meals;
using NUnit.Framework;

namespace DesignPatternsDemo.Tests
{
    [TestFixture]
    public class MealBuilderTests
    {
        [Test]
        public void Build_Fancy_Spicy_Burger()
        {
            // Arrange
            var fancyBurgerAdapter = new FancyBurgerAdapter();
            var builder = new SpicyMealBurgerBuilder(fancyBurgerAdapter);
            var director = new MealDirector(builder);

            // Act
            Meal meal = director.Construct();

            // Assert
            Assert.That(meal.Burger, Does.Contain("Wagyu Beef"));
            Assert.That(meal.Burger, Does.Contain("Extra Spicy"));
            Assert.That(meal.Drink, Is.EqualTo("Sparkling Water"));
            Assert.That(meal.Side, Is.EqualTo("Truffle Fries"));

            // Output (optional for console)
            TestContext.WriteLine("Constructed Meal:");
            TestContext.WriteLine(meal.ToString());
        }
    }
}
