using Property.DTO;
using Property.IRepositories;
using Property.IServices;
using Property.Model;
using System.ComponentModel;

namespace Property.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository;

        public PropertyService(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public async Task<GetPropertyDto> CreatePropertyAsync(CreatePropertyDto propertyDto)
        {
            try
            {
                var property = await _propertyRepository.CreateAsync(new Propertys()
                {
                    PropertyTitle = propertyDto.PropertyTitle,
                    PropertyTypeId = propertyDto.PropertyTypeId,
                    PropertyDescription = propertyDto.PropertyDescription,
                    PropertyAddress = propertyDto.PropertyAddress,
                    PropertyPrice = propertyDto.PropertyPrice,
                    PropertySize = propertyDto.PropertySize,
                    PropertyBedrooms = propertyDto.PropertyBedrooms,
                    PropertyStatusId = propertyDto.PropertyStatusId,
                });
                return new GetPropertyDto(property.PropertyId,
                                            property.PropertyTitle,
                                            property.PropertyTypeId,
                                            property.PropertyDescription,
                                            property.PropertyAddress,
                                            property.PropertyPrice,
                                            property.PropertySize,
                                            property.PropertyBedrooms,
                                            property.PropertyStatusId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public async Task<bool> DeletePropertyAsync(int Id)
        {
            try
            {
                var property = await _propertyRepository.GetByIdAsync(Id);

                if (property != null)
                {
                    await _propertyRepository.DeleteAsync(property);
                    return true;
                }
                
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return false;
        }

        public async Task<GetPropertyDto> GetPropertyAsync(int Id)
        {
            try
            {
                var property = await _propertyRepository.GetByIdAsync(Id);

                if(property != null)
                {
                    return new GetPropertyDto(property.PropertyId,
                                            property.PropertyTitle,
                                            property.PropertyTypeId,
                                            property.PropertyDescription,
                                            property.PropertyAddress,
                                            property.PropertyPrice,
                                            property.PropertySize,
                                            property.PropertyBedrooms,
                                            property.PropertyStatusId);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message);  }
            return null;
        }

        public async Task<IEnumerable<GetPropertyDto>> GetPropertysAsync()
        {
            try
            {
                var propertys = await _propertyRepository.GetAllAsync();

                var propertyDto = propertys.Select(
                                                    property => new GetPropertyDto(property.PropertyId,
                                            property.PropertyTitle,
                                            property.PropertyTypeId,
                                            property.PropertyDescription,
                                            property.PropertyAddress,
                                            property.PropertyPrice,
                                            property.PropertySize,
                                            property.PropertyBedrooms,
                                            property.PropertyStatusId));

                return propertyDto;
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message); return null;
            }
        }

        public async Task<GetPropertyDto> UpdatePropertyAsync(int Id, UpdatePropertyDto carDto)
        {
            try
            {
                var property = await _propertyRepository.GetByIdAsync(Id);

                if (property != null)
                {
                    property.PropertyTitle = carDto.PropertyTitle;
                    property.PropertyTypeId = carDto.PropertyTypeId;
                    property.PropertyDescription = carDto.PropertyDescription;
                    property.PropertyAddress = carDto.PropertyAddress;
                    property.PropertyPrice = carDto.PropertyPrice;
                    property.PropertySize = carDto.PropertySize;
                    property.PropertyBedrooms = carDto.PropertyBedrooms;
                    property.PropertyStatusId = carDto.PropertyStatusId;

                    await _propertyRepository.UpdateAsync(property);

                    return new GetPropertyDto(property.PropertyId,
                                            property.PropertyTitle,
                                            property.PropertyTypeId,
                                            property.PropertyDescription,
                                            property.PropertyAddress,
                                            property.PropertyPrice,
                                            property.PropertySize,
                                            property.PropertyBedrooms,
                                            property.PropertyStatusId);

                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
                return null;
        }
    }
}
