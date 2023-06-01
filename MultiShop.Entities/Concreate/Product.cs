using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MultiShop.Core.DataAcces.MongoDB.MongoSettings;
using MultiShop.Core.Entities.Abstract;

namespace MultiShop.Entities.Concreate
{

    // Ozumuz Yazdigimiz 
    // todo  Gedib Table Kimki adi bele dduusun 
    [BsonCollection("products")]
    public class Product : IEntity
    {
        [BsonId] //  id Ler MongoDb de String Formatinda olur 
        [BsonRepresentation(BsonType.ObjectId)]  // Object Id Bunlar bize hazir Id leri Hazirlayir 
        public string Id { get; set; }
        public List<ProductLanguage> ProductLanguages { get; set; }
        public List<string> PhotoUrl { get; set; }
        [BsonRepresentation(BsonType.Decimal128)] // Decimal Ucun Bu olmalidir 
        public decimal Price { get; set; }
        [BsonRepresentation(BsonType.Decimal128)] // Decimal Ucun Bu olmalidir 
        public decimal Discount { get; set; }
        public DateTime DiscountEndDate { get; set; }
        public List<string> Categories { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        //TOdo sonra 
        //public List<Specification> Specifications { get; set; }

    }
}
