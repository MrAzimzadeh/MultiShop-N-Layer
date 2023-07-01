using MultiShop.Core.DataAcces.EntityFramework;
using MultiShop.DataAcces.Abstract;
using MultiShop.Entities.Concreate;

namespace MultiShop.DataAcces.Concrete.EntityFramework;

public class EfOrderDal : EfRepositoryBase<Order, AppDbContext>, IOrderDal
{
}