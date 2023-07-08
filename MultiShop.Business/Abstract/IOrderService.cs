using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MultiShop.Entities.DTOs.OrderDTO;

namespace MultiShop.Business.Abstract
{
	public interface IOrderService
	{
		void OrderProduct(OrderItemDTO orderItem);
	}
}