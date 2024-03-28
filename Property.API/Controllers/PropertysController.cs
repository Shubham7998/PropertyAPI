using Microsoft.AspNetCore.Mvc;
using Property.DTO;
using Property.IServices;
using Property.Model;

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
        public Task<IEnumerable<GetPropertiesDto>> Get()
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

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<GetPropertyDto>>> SearchInput(string find)
        {
            try
            {
                var bikeinfo = await _propertyService.GetSearchAsync(find);
                return Ok(bikeinfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving bike infos: {ex.Message}");

            }
        }
    }
}
