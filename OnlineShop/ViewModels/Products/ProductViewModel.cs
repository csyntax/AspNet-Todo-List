using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnlineShop.Models;
using OnlineShop.Infrastructure.Mapping;

namespace OnlineShop.ViewModels.Products
{
    public class ProductViewModel : IMapFrom<Product>
    {

        public string Name { get; set; }

        public string Description { get; set; }

    }
}
