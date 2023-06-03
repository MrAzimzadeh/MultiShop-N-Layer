using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MultiShop.Core.DataAcces.MongoDB.MongoSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiShop.Core.Entities.Abstract;

namespace MultiShop.Entities.Concreate
{
    [BsonCollection("category")]
    public class Category :  IEntity
    {
        [BsonId] //  id Ler MongoDb de String Formatinda olur 
        [BsonRepresentation(BsonType.ObjectId)]  // Object Id Bunlar bize hazir Id leri Hazirlayir 
        public string Id { get; set; }

        public List<CategoryLanguage> CategoryLanguages { get; set; }
        public string PhotoUrl { get; set; }

        
    }
}
