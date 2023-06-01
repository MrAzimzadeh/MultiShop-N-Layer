using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Entities.DTOs.Category
{
    public class CategoryListDTO
    {
        public string PhotoUrl { get; set; }
        public string Name { get; set; }
        public string SeoUrl { get; set; }
        public string LangCode { get; set; }

        public int ProductCount { get; set; }

    }
}
