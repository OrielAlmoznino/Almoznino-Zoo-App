using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooDAL.Entities
{
    public class Animal : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        [MaxLength(100, ErrorMessage = "The Name field cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "The Age field must be a positive number.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "The Image Path field is required.")]
        [MaxLength(150, ErrorMessage = "The ImagePath field cannot exceed 100 characters.")]
        public string ImagePath { get; set; }

        [Required(ErrorMessage = "The Description field is required.")]
        public string Description { get; set; }

        [ForeignKey("Category")]
        public Guid CategoryID { get; set; }

        public Category? Category { get; set; } // Navigation property

        public IEnumerable<Comment>? Comments { get; set; }
        
    }

}
