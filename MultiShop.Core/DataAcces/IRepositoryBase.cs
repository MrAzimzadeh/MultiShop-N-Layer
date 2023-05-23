using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Core.DataAcces
{
    // Engin Demirog Polymorphisim 
    public interface IRepositoryBase<TEntity>

    {
        void Add(TEntity model);
        void Update(TEntity model);
        void Delete(TEntity model);
        TEntity Get(Expression<Func<TEntity, bool>> filter); // 
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter);
    }
}
