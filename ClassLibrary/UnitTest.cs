using NUnit.Framework;
using JoePizzaPortal.Controllers;
using JoePizzaPortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClassLibrary
{
    public class Tests
    {
        [TestFixture]
        public class PizzaControllerTests
        {
            private PizzaController pizzaController;

            [SetUp]
            public void Setup()
            {
                pizzaController = new PizzaController();
            }

            [Test]
            public void Index_ReturnsViewWithPizzaDetails()
            {

                var result = pizzaController.Index() as ViewResult;


                Assert.IsNotNull(result);
                Assert.IsInstanceOf<IEnumerable<Pizza>>(result.Model);
            }
            [Test]
            public void Index_ReturnsFirstPizza()
            {
                var result = pizzaController.Index();


                Assert.IsNotNull(result);

            }

            [Test]
            public void Checkout_ReturnsViewWithOrderDetails()
            {

                var result = pizzaController.Checkout() as ViewResult;


                Assert.IsNotNull(result);
                Assert.IsInstanceOf<IEnumerable<OrderInfo>>(result.Model);
            }

        }
    }
}