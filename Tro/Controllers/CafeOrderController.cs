using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tro.Helpers;
using Tro.Models;

namespace Tro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CafeOrderController : ControllerBase
    {

        private readonly ILogger<CafeOrderController> _logger;
        private readonly IDrinkRepository _drinkRepo;

        public CafeOrderController(ILogger<CafeOrderController> logger, IDrinkRepository drinkRepo)
        {
            _logger = logger;
            _drinkRepo = drinkRepo;
        }


        [HttpPost]
        [Route("/Sale")]
        public ActionResult<string> CreateReceipt(List<Drink> drinks)
        {

            if (drinks != null )
            {
                var drinkMenu = _drinkRepo.GetDrinks();
                var purchased = new CafeOrder();
                foreach (var (menuItem, item) in drinkMenu.SelectMany(menuItem => drinks.Select(item => (menuItem, item))))
                {
                    if (menuItem.Name.ToLower() == item.Name.ToLower())
                    {
                        double subtotal = drinks.Sum(x => x.Price);
                        double total = GetTotal(drinks, subtotal);
                        return $"total cost {subtotal:c} after discount {total:c}";
                    }
                    else
                        return $"An item not in the menu was added.";

                }
            }

            return $"No drinks entered";

        }





        private static double GetTotal(List<Drink> drinks, double subtotal)
        {
            if (drinks.Count() is > 3 and < 6)
            {
                subtotal -= (subtotal * 0.1);
            }
            if (drinks.Count() is > 6 and < 10)
            {
                subtotal -= (subtotal * 0.2);
            }
            if (drinks.Count > 10)
            {
                subtotal -= (subtotal * 0.1);
                subtotal -= (subtotal * 0.2);
            }

            return subtotal;
        }
    }
}

