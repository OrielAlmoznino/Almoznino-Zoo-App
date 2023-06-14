using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooDAL.Entities
{
    public class Comment : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Content field is required.")]
        [MaxLength(500, ErrorMessage = "The Content field cannot exceed 500 characters.")]
        public string Content { get; set; }

        [ForeignKey("Animal")]
        public Guid AnimalID { get; set; }
        public Animal Animal { get; set; } // Navigation property
    }
}
