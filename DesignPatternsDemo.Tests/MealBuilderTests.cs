using DesignPatternsDemo.Adaptars.MealAdapters;
using DesignPatternsDemo.Builders.MealBuilders;
using DesignPatternsDemo.Directors.MealDirectors;
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
            var burgerPrototype = fancyBurgerAdapter.BuildBaseBurger();

            var builder = new SpicyMealBurgerBuilder(burgerPrototype);
            var director = new MealDirector(builder);

            // Act
            Meal meal = director.Construct();

            // Assert
            Assert.That(meal.Burger, Does.Contain("Wagyu Beef with Spicy Sriracha"));
            Assert.That(meal.Drink, Is.EqualTo("Cola"));
            Assert.That(meal.Side, Is.EqualTo("Curly Fries"));
        }

        //[Test]
        //public void Build_Fancy_Burger()
        //{
        //    // Arrange
        //    var fancyBurgerAdapter = new FancyBurgerAdapter();
        //    var builder = new SmallMealBuilder(fancyBurgerAdapter);
        //    var director = new MealDirector(builder);

        //    // Act
        //    Meal meal = director.Construct();

        //    // Assert
        //    Assert.That(meal.Burger, Does.Contain("Wagyu Beef with Spicy Sriracha"));
        //    Assert.That(meal.Drink, Is.EqualTo("Cola"));
        //    Assert.That(meal.Side, Is.EqualTo("Curly Fries"));
        //}
    }
}
