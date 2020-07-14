using RestaurantOrder.Models.ENUN;
using System.Collections.Generic;

namespace RestaurantOrder.Models
{
    public class Order
    {
        public List<Dish> Dishes { get; set; }

        public string Period { get; set; }
    }
}
