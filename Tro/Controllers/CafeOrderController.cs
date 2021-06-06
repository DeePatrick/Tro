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

        [HttpGet]
        public ActionResult<List<Drink>> GetDrinks()
        {
            return _drinkRepo.GetDrinks();
        }


        [HttpPost]
        [Route("/Sale")]
        public ActionResult<string> CreateReceipt(List<Drink> drinks)
        {



            CafeOrder purchased = new CafeOrder();
            if (drinks != null)
            {
                double subtotal = drinks.Sum(x => x.Price);
                double total = GetTotal(drinks, subtotal);
                return $"total cost {subtotal:c} after discount {total:c}";
            }

            return $"No drinks entered";

        }


        private static double GetTotal(List<Drink> drinks, double subtotal)
        {
            if (drinks.Count() > 3 && drinks.Count() < 6)
            {
                subtotal = subtotal - (subtotal * 0.1);
            }
            if (drinks.Count() > 6 && drinks.Count() < 10)
            {
                subtotal = subtotal - (subtotal * 0.2);
            }
            if (drinks.Count > 10)
            {
                subtotal = subtotal - (subtotal * 0.1);
                subtotal = subtotal - (subtotal * 0.2);
            }

            return subtotal;
        }
    }






}
}
