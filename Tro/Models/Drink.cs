using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tro.Models
{
    public class Drink
    {
        [Required]
        public string Name { get; set; }
        public double  Price { get; set; }
    }
}

