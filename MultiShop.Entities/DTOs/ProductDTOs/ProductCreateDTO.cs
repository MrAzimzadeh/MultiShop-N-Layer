using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MultiShop.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Entities.DTOs.ProductDTOs
{
    public class ProductCreateDTO
    {
        //public string Id { get; set; } //  CCreate de Id olmamalidir!
        [Required]
        public List<ProductLanguageDTO> ProductLanguages { get; set; }
        [Required]
        public List<string> PhotoUrl { get; set; }
        [Required]
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public DateTime DiscountEndDate { get; set; }
        public List<string>? Categories { get; set; }
    }
}
