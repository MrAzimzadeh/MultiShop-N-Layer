using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MultiShop.Core.Entities.Abstract;

namespace MultiShop.Core.DataAcces
{
    //Engin Demirog Polymorphisim
    public interface IRepositoryBase<TEntity> 
    where TEntity : class ,  IEntity 
    {
        //
        void Add(TEntity model); // 
        void Update(TEntity model); //
        void Delete(TEntity model); // 
        TEntity Get(Expression<Func<TEntity, bool>> filter); //
        List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null); // 
    
    }
}
