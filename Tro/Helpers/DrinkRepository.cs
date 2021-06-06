using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tro.Models;

namespace Tro.Helpers
{
    public class DrinkRepository : IDrinkRepository
    {
        public List<Drink> GetDrinks()
        {
            return new List<Drink>()
            {
            new Drink(){Name ="Coffee", Price =1.5},
            new Drink(){Name ="Tea", Price = 1.2},
            new Drink(){Name ="Hot Chocolate", Price = 2.0},
            new Drink(){Name ="Sugar", Price = 0.01},
            new Drink(){Name ="Milk", Price = 0.3},
            new Drink(){Name ="Marshmallows", Price = 0.6}
            };
        }
    }
}
