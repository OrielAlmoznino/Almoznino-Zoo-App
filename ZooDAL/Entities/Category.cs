using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooDAL.Entities
{
    public class Category : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        [MaxLength(100, ErrorMessage = "The Name field cannot exceed 100 characters.")]
        public string Name { get; set; }

    }
}
