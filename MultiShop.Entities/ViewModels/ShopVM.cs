using MultiShop.Entities.DTOs.Category;
using MultiShop.Entities.DTOs.ProductDTOs;

namespace MultiShop.Entities.ViewModels;

public class ShopVM
{
    public List<RecentProductDTO> ProductList { get; set; }
    public List<CategoryListDTO> Categories { get; set; }
}