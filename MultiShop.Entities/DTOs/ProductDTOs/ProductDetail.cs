using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiShop.Entities.DTOs.ProductDTOs
{
    public class ProductDetail
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SeoUrl { get; set; }
        public string LangCode { get; set; }
        public List<string> PhotoUrl { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public DateTime DiscountEndDate { get; set; }
        public List<string> Categories { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}