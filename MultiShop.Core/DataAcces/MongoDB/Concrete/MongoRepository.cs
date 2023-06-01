using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MultiShop.Core.DataAcces.MongoDB.MongoSettings;
using MultiShop.Core.Entities.Abstract;
using SharpCompress.Common;

namespace MultiShop.Core.DataAcces.MongoDB.Concrete
{
    public class MongoRepository<TDocument> : IMongoRepository<TDocument>
        where TDocument : class, IEntity
    {
        private readonly IMongoCollection<TDocument> _collection;

        private protected string GetCollectionName(Type documentType)
        {
            return ((BsonCollectionAttribute)documentType.GetCustomAttributes(typeof(BsonCollectionAttribute), true).FirstOrDefault())?.CollectionName;
        }
        public MongoRepository(IDatabseSettings databseSettings)
        {
            // Json Dan bpara metre goturmek ucun 
            var database = new MongoClient(databseSettings.ConnectionString).GetDatabase(databseSettings.DatabaseName);
            _collection = database.GetCollection<TDocument>(GetCollectionName(typeof(
                TDocument)));
        }

        public List<TDocument> GetAll()
        {
            // Bos OlANDA Hma=sini Cagira bilmediyimiz ucun BeLE Yazmaliyiq 
            return _collection.Find(FilterDefinition<TDocument>.Empty).ToList();
        }

        public TDocument Get(string id)
        {
            var filter = Builders<TDocument>.Filter.Eq("_id", ObjectId.Parse(id));

            return _collection.Find(filter).FirstOrDefault();
        }

        public void Add(TDocument model)
        {
            //  Bu Mongo DB nin _contexti Kimi bir seydir!!!
            _collection.InsertOne(model);
        }
        public void Update(string id, TDocument entity)
        {
            // Id NI TAPIB 
            var filter = Builders<TDocument>.Filter.Eq("_id", ObjectId.Parse(id));

            // uPDATE eDIR 
            _collection.ReplaceOne(filter, entity);
        }

        public void Remove(string id)
        {
            // Id NI TAPIB 
            var filter = Builders<TDocument>.Filter.Eq("_id", ObjectId.Parse(id));

            // uPDATE eDIR 
            _collection.DeleteOne(filter);
        }
    }
}
