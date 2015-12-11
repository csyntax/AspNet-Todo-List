using System;
using System.ComponentModel.DataAnnotations;
using OnlineShop.Models;
using MyAutoMapping;

namespace OnlineShop.ViewModels.Products
{
    public class ProductViewModel : IMapFrom<Product>
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public DateTime Published { get; set; }
    }
}
