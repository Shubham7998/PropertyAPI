using Property.DTO;

namespace Property.IServices
{
    public interface IPropertyService
    {
        public Task<GetPropertyDto> CreatePropertyAsync(CreatePropertyDto carDto);
        public Task<GetPropertyDto> UpdatePropertyAsync(int Id, UpdatePropertyDto carDto);
        public Task<bool> DeletePropertyAsync(int Id);
        public Task<GetPropertyDto> GetPropertyAsync(int Id);
        public Task<IEnumerable<GetPropertyDto>> GetPropertysAsync();
    }
}
