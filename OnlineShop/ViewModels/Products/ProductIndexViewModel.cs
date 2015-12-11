using OnlineShop.Infrastructure.Mapping;
using OnlineShop.Models;
using System;

namespace OnlineShop.ViewModels.Products
{
    public class ProductIndexViewModel : IMapFrom <Product>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Category Category { get; set; }

        public float Price { get; set; }

        public DateTime Published { get; set; }
    }
}
