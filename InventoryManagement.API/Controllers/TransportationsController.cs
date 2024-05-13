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
    public class TransportationsController : ControllerBase
    {
        private readonly ITransportationServices _transportationServices;
        public TransportationsController(ITransportationServices transportationServices)
        {
            _transportationServices= transportationServices;
        }
        /// <summary>
        /// This is EndPoint retrive One Cutomer By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetCustomer")]
        public virtual async Task<IActionResult> GetById(int id)
        {

            var item = await _transportationServices.GetByIdAsync(id);
            if (id == null)
                return BadRequest($"The Item With Id {id} Doesn't Exist!");

            return Ok(item);
        }

        /// <summary>
        /// This is EndPoint retrive All Customers
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllItems")]
        public virtual async Task<IActionResult> GetAll()
        {
            var item = await _transportationServices.GetAllAsync();

            return Ok(item);

        }

        /// <summary>
        /// This is EndPoint Add a new Transportations
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("AddNewTransportation")]
        public async Task<IActionResult> AddTransportation([FromBody] TransportationDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var transportations = new Transportation()
            {
                ItemFk= dto.ItemID,
                Type=dto.Type,
                Date=dto.Date,
                Quantity=dto.Quantity,
                
               
            };

            var Result = await _transportationServices.AddAsync(transportations);
            return Ok(Result);

        }

        /// <summary>
        /// This is EndPoint Delete a Transportation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteTransportation")]
        public async Task<IActionResult> DeleteTransportation(int id)
        {
            var Result = await _transportationServices.DeleteAsync(id);
            return Ok(Result);

        }

        /// <summary>
        /// This is EndPoint Update  Transportation
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("UpdateTransportation")]
        public IActionResult UpdateTransportation([FromBody] TransportationDto dto, int id)
        {
            if (id == 0)
                return BadRequest($"Not Found Id=>{id}");
            Transportation updatedTransportation = _transportationServices.GetById(id);
           updatedTransportation.ItemFk = dto.ItemID;   
           updatedTransportation.Type = dto.Type;
           updatedTransportation.Quantity = dto.Quantity;
           updatedTransportation.Date = dto.Date;

            var result = _transportationServices.Update(updatedTransportation);
            return Ok(result);

        }
    }
}
