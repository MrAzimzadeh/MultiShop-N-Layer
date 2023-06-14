using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiShop.Entities.DTOs.Category;
using MultiShop.Entities.DTOs.ProductDTOs;

namespace MultiShop.Entities.ViewModels
{
    public class HomeVM
    {
        public List<CategoryListDTO> CategoryList { get; set; }
        public List<RecentProductDTO> RecentProductDtos { get; set; }
        public List<DiscountProductDTO> DiscountProductDtos { get; set; }
    }
}
