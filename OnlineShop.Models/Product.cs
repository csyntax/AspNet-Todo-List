﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        [Required]
        [Column(TypeName = "Text")]
        public string Description { get; set; }
    }
}