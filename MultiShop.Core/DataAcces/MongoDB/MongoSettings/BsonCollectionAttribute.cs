using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Core.DataAcces.MongoDB.MongoSettings
{

    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class BsonCollectionAttribute : Attribute
    {
        public BsonCollectionAttribute(string collectionName)
        {
            CollectionName = collectionName;
        }

        public string CollectionName { get; set; }
    }
}
