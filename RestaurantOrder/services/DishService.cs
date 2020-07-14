using RestaurantOrder.Models;
using RestaurantOrder.Models.ENUN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOrder.services
{
    public class DishServices : IDishServices
    {
        private readonly List<Dish> _dishes;

        public DishServices()
        {
            _dishes = new List<Dish>() {
                new Dish { DishType = DishType.entree, Period = "morning", Name = "Eggs"},
                new Dish { DishType = DishType.side, Period = "morning", Name = "Toast"},
                new Dish { DishType = DishType.drink, Period = "morning", Name = "Coffee", Repeat = true },
                new Dish { DishType = DishType.entree, Period = "night", Name = "Steak"},
                new Dish { DishType = DishType.side, Period = "night", Name = "Potato", Repeat = true},
                new Dish { DishType = DishType.drink, Period = "night", Name = "Wine"},
                new Dish { DishType = DishType.dessert, Period = "night", Name = "Cake"},
            };
        }

        public string AddOrder(string order)
        {
            if (string.IsNullOrEmpty(order))
                throw new Exception("Invalid Order!");

            var orderSplit = order.Trim().Split(',');
            var period = orderSplit[0];
            List<Dish> dishes = new List<Dish>();

            if (period != "morning" && period != "night")
            {
                throw new Exception("Invalid period!");
            }

            for (var i = 1; i < orderSplit.Length; i++)
            {
                var dish = _dishes.Where(w => (int)w.DishType == Convert.ToInt32(orderSplit[i]) && w.Period == period).FirstOrDefault();

                if (dish != null && !dishes.Any(a => a.DishType == dish.DishType && !dish.Repeat) )
                    dishes.Add(dish);
                else
                {
                    var repeatedOrderError = dishes.Where(a => a.Repeat == true).ToList();

                    var repeatedResultError = string.Empty;
                    if (repeatedOrderError.Count > 1)
                    {
                        repeatedResultError = repeatedOrderError.First().Name + "(x" + repeatedOrderError.Count + ")";
                    }

                    string resultError = string.Empty;
                    foreach (var dishAsked in dishes.OrderBy(o => o.DishType).Distinct().ToList())
                    {
                        if (dishAsked.Repeat == true && !string.IsNullOrEmpty(repeatedResultError))
                        {
                            resultError += repeatedResultError + ", ";
                        }
                        else
                        {
                            resultError += dishAsked.Name + ", ";
                        }
                    }

                    resultError += "error";

                    return resultError;
                }
            }

            if (dishes.Count == 0)
                throw new Exception("Invalid order!");

          
            var repeatedOrder = dishes.Where(a => a.Repeat == true).ToList();

            var repeatedResult = string.Empty;
            if(repeatedOrder.Count > 1)
            {
                repeatedResult = repeatedOrder.First().Name + "(x" + repeatedOrder.Count + ")";
            }

            string result = string.Empty;
            foreach (var dish in dishes.OrderBy(o => o.DishType).Distinct().ToList())
            {
                if(dish.Repeat == true && !string.IsNullOrEmpty(repeatedResult))
                {
                    result += repeatedResult + ", ";
                }
                else
                {
                    result += dish.Name + ", ";
                }
            }

            return result.TrimEnd(' ').TrimEnd(',');
        }
    }
}
