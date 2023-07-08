using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MultiShop.Core.Entities.Concreate;
using MultiShop.Entities.DTOs.CartDTO;

namespace MultiShop.Entities.ViewModels
{
	public class CheckOutVM
	{
		public User User { get; set; }
		public List<CartProductDTO> CartProducts { get; set; }
	}
}