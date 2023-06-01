using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Entities.DTOs
{
    public class ProductHomeDTO
    {
        public string Id { get; set; }
        public string PhotoUrl { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
    }
}
