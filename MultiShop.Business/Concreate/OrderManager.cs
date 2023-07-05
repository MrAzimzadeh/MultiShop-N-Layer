using MultiShop.Business.Abstract;
using MultiShop.DataAcces.Abstract;
using MultiShop.Entities.Concreate;
using MultiShop.Entities.DTOs.OrderDTO;

namespace MultiShop.Business.Concreate;

public class OrderManager : IOrderService
{
    private readonly IOrderDal _orderDal;

    public OrderManager(IOrderDal orderDal)
    {
        _orderDal = orderDal;
    }

    public void OrderProduct(OrderItemDTO orderItem)
    {
        for (int i = 0; i < orderItem.ProductId.Count; i++)
        {
            Order newOrder = new()
            {
                UserId = orderItem.UserId,
                ProductId = orderItem.ProductId[i],
                CreatedDate = DateTime.Now,
                Price = orderItem.Price[i],
                Quantity = orderItem.Quantity[i],
            };
            _orderDal.Add(newOrder);
        }
    }
}