using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MultiShop.Core.DataAcces.MongoDB.MongoSettings;
using MultiShop.Core.Entities.Abstract;

namespace MultiShop.Core.DataAcces.MongoDB.Concrete
{
    public class MongoRepository<TDocument> : IRepositoryBase<TDocument>
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
        public void Add(TDocument model)
        {
            throw new NotImplementedException();
        }

        public void Update(TDocument model)
        {
            throw new NotImplementedException();
        }

        public void Delete(TDocument model)
        {
            throw new NotImplementedException();
        }

        public TDocument Get(Expression<Func<TDocument, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<TDocument> GetAll(Expression<Func<TDocument, bool>>? filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
