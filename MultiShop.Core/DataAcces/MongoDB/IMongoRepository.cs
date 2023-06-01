using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiShop.Core.Entities.Abstract;

namespace MultiShop.Core.DataAcces.MongoDB
{
    public interface IMongoRepository <TDocumnet> 
    where TDocumnet : class , IEntity
    {
        List<TDocumnet> GetAll();
        TDocumnet Get(string id);
        void Add(TDocumnet entity);
        void Update(string id , TDocumnet entity);
        void Remove (string id);
    }
}
