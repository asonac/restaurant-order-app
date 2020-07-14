using RestaurantOrder.Models.ENUN;

namespace RestaurantOrder.Models
{
    public class Dish
    {

        public DishType DishType { get; set; }
        public string Period { get; set; }
        public string Name { get; set; }
        public bool Repeat { get; set; }
    }
}
