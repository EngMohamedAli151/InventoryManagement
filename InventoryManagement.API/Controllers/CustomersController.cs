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
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerServices _customerServices;
        public CustomersController(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }
        /// <summary>
        /// This is EndPoint retrive One Cutomer By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetCustomer")]
        public virtual async Task<IActionResult> GetById(int id)
        {

            var item = await _customerServices.GetByIdAsync(id);
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
            var item = await _customerServices.GetAllAsync();

            return Ok(item);

        }

        /// <summary>
        /// This is EndPoint Add a new Customer
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("AddNewCustomer")]
        public async Task<IActionResult> AddCustomer([FromBody]CustomerDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var customer = new Customer()
            {
              CustomerName=dto.CustomerName,
              Email=dto.Email,
              Phone=dto.Phone,
              Address = dto.Address
            };

            var Result = await _customerServices.AddAsync(customer);
            return Ok(Result);

        }

        /// <summary>
        /// This is EndPoint Delete a Customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var Result = await _customerServices.DeleteAsync(id);
            return Ok(Result);

        }

        /// <summary>
        /// This is EndPoint Update  Customer
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("UpdateCustomer")]
        public IActionResult UpdateCustomer([FromBody] CustomerDto dto, int id)
        {
            if (id == 0)
                return BadRequest($"Not Found Id=>{id}");
            Customer updatedCustomer = _customerServices.GetById(id);
            updatedCustomer.CustomerName = dto.CustomerName;
            updatedCustomer.Email = dto.Email;
            updatedCustomer.Phone = dto.Phone;
            updatedCustomer.Address = dto.Address;

            var result = _customerServices.Update(updatedCustomer);
            return Ok(result);

        }
    }
}
