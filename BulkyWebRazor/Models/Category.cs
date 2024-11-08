﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWebRazor.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        [MaxLength(30)]
        public string Name { get; set; }

        [DisplayName("Display Order")]
        [Range(1,300,ErrorMessage = "The field Display Order must be between 1 and 300.")]
        public int DisplayOrder { get; set; }
    }
}
