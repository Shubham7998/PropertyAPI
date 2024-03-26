using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Model
{
    public class PropertyStatusType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PropertyStatusId { get; set; }

        [Required(ErrorMessage = "Please enter a property status")]
        [StringLength(10, ErrorMessage = "The property status must be between 1 and 10 characters", MinimumLength = 1)]
        public string StatusName { get; set; } = string.Empty;
    }
}
