using OnlineShop.Models;
using OnlineShop.Infrastructure.Mapping;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.ViewModels.Products
{
    public class ProductViewModel : IMapFrom<Product>
    {

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}
