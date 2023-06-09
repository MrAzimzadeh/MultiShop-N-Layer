using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MultiShop.Entities.Concreate;

namespace MultiShop.Entities.DTOs.ProductDTOs
{
    public class ProductRemove
    {
        public string Id { get; set; }
        public List<string> PhotoUrl { get; set; }
        public List<ProductLanguage> ProductLanguage { get; set; }
    }
}
