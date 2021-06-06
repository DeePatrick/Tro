using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tro.Models
{
    public class CafeOrder
    {
        public double TenDiscount { get; set; } = 0.1;
        public double TwentyDiscount { get; set; } = 0.2;

        public List<Drink> items = new List<Drink>();
    }
}

