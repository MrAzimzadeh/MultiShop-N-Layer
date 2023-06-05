using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiShop.Entities.Concreate;

namespace MultiShop.Entities.DTOs.ProductDTOs
{
    public class ProductCategoryDTO
    {
        public string Id { get; set; }
        public List<CategoryLanguage> CategoryLanguages { get; set; }

    }
}
