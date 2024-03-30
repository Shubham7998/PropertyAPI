using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Property.DTO
{
    public record CreatePropertyDto(
                                    [Required(ErrorMessage = "Please enter a property title")] string PropertyTitle,
                                    [Required(ErrorMessage = "Please select a property type")] int PropertyTypeId,
                                    [Required(ErrorMessage = "Please enter a property description")] string PropertyDescription,
                                    [Required(ErrorMessage = "Please enter a property address")] string PropertyAddress,
                                    [Required(ErrorMessage = "Please enter a property price")] int PropertyPrice,
                                    [Required(ErrorMessage = "Please select a property size")] int PropertySize,
                                    [Required(ErrorMessage = "Please select the number of bedrooms")] int PropertyBedrooms,
                                    [Required(ErrorMessage = "Please select a property status")] int PropertyStatusId
                                    );
    public record UpdatePropertyDto(int PropertyId,
                                    [Required(ErrorMessage = "Please enter a property title")] string PropertyTitle,
                                    [Required(ErrorMessage = "Please select a property type")] int PropertyTypeId,
                                    [Required(ErrorMessage = "Please enter a property description")] string PropertyDescription,
                                    [Required(ErrorMessage = "Please enter a property address")] string PropertyAddress,
                                    [Required(ErrorMessage = "Please enter a property price")] int PropertyPrice,
                                    [Required(ErrorMessage = "Please select a property size")] int PropertySize,
                                    [Required(ErrorMessage = "Please select the number of bedrooms")] int PropertyBedrooms,
                                    [Required(ErrorMessage = "Please select a property status")] int PropertyStatusId
                                    );
    public record GetPropertyDto(   int PropertyId,
                                    string PropertyTitle,
                                    int PropertyTypeId,
                                    string PropertyDescription,
                                    string PropertyAddress,
                                    int PropertyPrice,
                                    int PropertySize,
                                    int PropertyBedrooms,
                                    int PropertyStatusId
                                    );
    public record GetPropertiesDto(
                                   int PropertyId,
                                  string PropertyTitle,
                                  int PropertyTypeId,
                                  string PropertyDescription,
                                  string PropertyAddress,
                                  int PropertyPrice,
                                  int PropertySize,
                                  int PropertyBedrooms,
                                  int PropertyStatusId,
                                  string PropertyTypeName,
                                  string PropertyStatuseName
                                  );
}

