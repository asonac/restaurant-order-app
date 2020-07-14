using Microsoft.AspNetCore.Mvc;
using RestaurantOrder.services;
using System;
using Xunit;

namespace web_api_tests
{
    public class DishServiceUnitTest
    {
        [Fact]
        public void TestInvalidInputOrder()
        {
            var dishService = new DishServices();

           Assert.Throws<Exception>(() => dishService.AddOrder("This is a test"));
        }

        [Fact]
        public void TestValidInputOrder()
        {
            var dishService = new DishServices();

            Assert.Equal("Eggs, Toast, Coffee(x4)", dishService.AddOrder("morning, 1,2,3,3,3,3"));
        }


        [Fact]
        public void TestValidInputOrderWithError()
        {
            var dishService = new DishServices();

            Assert.Contains("error", dishService.AddOrder("night, 1,2,3,5"));
        }
    }
}
