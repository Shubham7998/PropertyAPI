using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Model
{
    public class PropertyType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PropertyTypeId { get; set; }

        [Required(ErrorMessage = "Please enter a property type")]
        [StringLength(10, ErrorMessage = "The property type must be between 1 and 10 characters", MinimumLength = 1)]
        public string TypeName { get; set; }
    }
}

