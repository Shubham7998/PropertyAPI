using Microsoft.AspNetCore.Mvc;
using Property.DTO;
using Property.IServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Property.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertysController : ControllerBase
    {
        private readonly IPropertyService _propertyService;

        public PropertysController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        // GET: api/<PropertysController>
        [HttpGet]
        public Task<IEnumerable<GetPropertyDto>> Get()
        {
            return _propertyService.GetPropertysAsync();
        }

        // GET api/<PropertysController>/5
        [HttpGet("{id}")]
        public async Task<GetPropertyDto> Get(int id)
        {
            return await _propertyService.GetPropertyAsync(id);
        }

        // POST api/<PropertysController>
        [HttpPost]
        public async Task<GetPropertyDto> Post([FromBody] CreatePropertyDto propertyDto)
        {
            return await _propertyService.CreatePropertyAsync(propertyDto);
        }

        // PUT api/<PropertysController>/5
        [HttpPut("{id}")]
        public async Task<GetPropertyDto> Put(int id, [FromBody] UpdatePropertyDto updatePropertyDto)
        {
            return await _propertyService.UpdatePropertyAsync(id, updatePropertyDto);
        }

        // DELETE api/<PropertysController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _propertyService.DeletePropertyAsync(id);
        }
    }
}
