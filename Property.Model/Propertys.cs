using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Property.Model
{
    [Table("Propertys")]
    public class Propertys
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PropertyId { get; set; }

        [Required(ErrorMessage = "Please enter a property title")]
        [StringLength(50, ErrorMessage = "The title must be between 1 and 50 characters", MinimumLength = 1)]
        public string PropertyTitle { get; set; }

        [Required(ErrorMessage = "Please select a property type")]
        [ForeignKey("PropertyType")]
        public int PropertyTypeId { get; set; }
        public virtual PropertyType PropertyType { get; set; }

        [Required(ErrorMessage = "Please enter a property description")]
        [StringLength(200, ErrorMessage = "The description must be between 20 and 200 characters", MinimumLength = 20)]
        public string PropertyDescription { get; set; }

        [Required(ErrorMessage = "Please enter a property address")]
        [StringLength(100, ErrorMessage = "The address must be between 1 and 100 characters", MinimumLength = 1)]
        public string PropertyAddress { get; set; }

        [Required(ErrorMessage = "Please enter a property price")]
        [Range(0, int.MaxValue, ErrorMessage = "Price must be a positive number")]
        public int PropertyPrice { get; set; }

        [Required(ErrorMessage = "Please select a property size")]
        [Range(0, int.MaxValue, ErrorMessage = "Size must be a positive number")]
        public int PropertySize { get; set; }

        [Required(ErrorMessage = "Please select the number of bedrooms")]
        [Range(0, int.MaxValue, ErrorMessage = "Bedrooms must be a positive number")]
        public int PropertyBedrooms { get; set; }

        [Required(ErrorMessage = "Please select a property status")]
        [ForeignKey("PropertyStatusType")]
        public int PropertyStatusId { get; set; }
        public virtual PropertyStatusType PropertyStatusType { get; set; }
    }
}
