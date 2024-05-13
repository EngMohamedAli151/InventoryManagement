using InventoryManagement.Core.Dto;
using InventoryManagement.Database.Model;
using InventoryManagement.Services.InterFace;
using InventoryManagement.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationServices _locationServices;
        public LocationsController(ILocationServices locationServices)
        {
            _locationServices = locationServices;
        }
        /// <summary>
        /// This is EndPoint retrive One Location By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetLocation")]
        public virtual async Task<IActionResult> GetById(int id)
        {

            var item = await _locationServices.GetByIdAsync(id);
            if (id == 0)
                return BadRequest($"The Location With Id {id} Doesn't Exist!");

            return Ok(item);
        }

        /// <summary>
        /// This is EndPoint retrive All Customers
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllLocation")]
        public virtual async Task<IActionResult> GetAll()
        {
            var locations = await _locationServices.GetAllAsync();

            return Ok(locations);

        }

        /// <summary>
        /// This is EndPoint Add a new Location
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("AddNewLocation")]
        public async Task<IActionResult> AddLocation([FromBody] LocationDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var location = new Location()
            {
                Name = dto.Name,
                Description = dto.Description,
            };

            var Result = await _locationServices.AddAsync(location);
            return Ok(Result);

        }

        /// <summary>
        /// This is EndPoint Delete a Location
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteLocation")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            var Result = await _locationServices.DeleteAsync(id);
            return Ok(Result);

        }

        /// <summary>
        /// This is EndPoint Update  Location
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("UpdateLocation")]
        public IActionResult UpdateLocation([FromBody] LocationDto dto, int id)
        {
            if (id == 0)
                return BadRequest($"Not Found Id=>{id}");
            Location updatedLocation = _locationServices.GetById(id);
            updatedLocation. Name = dto.Name;
           updatedLocation.Description = dto.Description;
          

            var result = _locationServices.Update(updatedLocation);
            return Ok(result);

        }
    }
}
