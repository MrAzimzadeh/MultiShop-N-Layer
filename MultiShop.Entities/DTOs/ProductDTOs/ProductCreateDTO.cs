using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MultiShop.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Entities.DTOs.ProductDTOs
{
    public class ProductCreateDTO
    {

        // public string Id { get; set; } //  CCreate de Id olmamalidir!
        public List<ProductLanguageDTO> ProductLanguages { get; set; }
        public List<string> PhotoUrl { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public DateTime DiscountEndDate { get; set; }
        public List<string> Categories { get; set; }
    }
}
