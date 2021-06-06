using System.Collections.Generic;
using Tro.Models;

namespace Tro.Helpers
{
    public interface IDrinkRepository
    {
        List<Drink> GetDrinks();
    }
}