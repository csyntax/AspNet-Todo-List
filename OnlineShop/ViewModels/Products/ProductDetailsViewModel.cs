using System;
using MyAutoMapping;
using OnlineShop.Models;

namespace OnlineShop.ViewModels.Products
{
    public class ProductDetailsViewModel : IMapFrom<Product>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Category Category { get; set; }

        public float Price { get; set; }

        public DateTime Published { get; set; }
    }
}
