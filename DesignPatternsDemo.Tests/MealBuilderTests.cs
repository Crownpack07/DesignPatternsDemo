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

        [Test]
        public void Build_Fancy_Burger()
        {
            // Arrange
            var baseBurger = BaseBurger;

            var builder = new SmallMealBuilder(baseBurger);
            var director = new MealDirector(builder);

            // Act
            Meal meal = director.Construct();

            // Assert
            Assert.That(meal.Burger, Does.Contain("Design Pat Mac with Tomato"));
            Assert.That(meal.Drink, Is.EqualTo("Small Drink"));
            Assert.That(meal.Side, Is.EqualTo("Small Side"));
        }

        [Test]
        public void Build_Complex_Meal()
        {
            // Arrange

            var builder = new ComplexMealBuilder();

            // Act
            var meal = builder.SetBurger("Chicken Burger")
                              .SetSide("Apple")
                              .Build();

            //Assert
            Assert.That(meal.Burger, Is.EqualTo("Chicken Burger"));
            Assert.That(meal.Side, Is.EqualTo("Apple"));
            Assert.That(meal.Drink, Is.Null);
        }

        private static Burger BaseBurger => new Burger { Name = "Design Pat Mac", Sauce = "Tomato" };
    }
}
