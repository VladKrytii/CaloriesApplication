using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaloriesApplication
{

    public class Dish
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal KiloCaloriesPer100Grams { get; set; }
        public string? Description { get; set; }
    }
}
