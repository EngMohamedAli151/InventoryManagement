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
    public class OrdersController : ControllerBase
    {
        private readonly IOrderServices _orderServices;
        public OrdersController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }
        /// <summary>
        /// This is EndPoint retrive One Order By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetOrder")]
        public virtual async Task<IActionResult> GetById(int id)
        {

            var order = await _orderServices.GetByIdAsync(id);
            if (id == null)
                return BadRequest($"The Item With Id {id} Doesn't Exist!");

            return Ok(order);
        }

        /// <summary>
        /// This is EndPoint retrive All Orders
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllOrders")]
        public virtual async Task<IActionResult> GetAll()
        {
            var order = await _orderServices.GetAllAsync();

            return Ok(order);

        }

        /// <summary>
        /// This is EndPoint Add a new Order
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("AddNewOrder")]
        public async Task<IActionResult> AddOrder([FromBody] OrderDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var order = new Order()
            {
                CustomerFk = dto.CustomerID,
                OrderDate = dto.OrderDate,
                Status = dto.Status,
                TotalAmount = dto.TotalAmount
            };

            var Result = await _orderServices.AddAsync(order);
            return Ok(Result);

        }

        /// <summary>
        /// This is EndPoint Delete a Order
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteOrder")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var Result = await _orderServices.DeleteAsync(id);
            return Ok(Result);

        }

        /// <summary>
        /// This is EndPoint Update  Customer
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("UpdateOrder")]
        public IActionResult UpdateOrder([FromBody] OrderDto dto, int id)
        {
            if (id == 0)
                return BadRequest($"Not Found Id=>{id}");
            Order updatedOrder = _orderServices.GetById(id);
            updatedOrder.CustomerFk= dto.CustomerID;
            updatedOrder.OrderDate = dto.OrderDate;
            updatedOrder.Status = dto.Status;
            updatedOrder.TotalAmount = dto.TotalAmount;

            var result = _orderServices.Update(updatedOrder);
            return Ok(result);

        }
    }
}
