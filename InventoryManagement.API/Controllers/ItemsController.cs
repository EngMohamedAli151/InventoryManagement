using InventoryManagement.Core.Dto;
using InventoryManagement.Database.Model;
using InventoryManagement.Services.InterFace;
using InventoryManagement.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace InventoryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemServices _itemServices;
        public ItemsController(IItemServices itemServices)
        {
            _itemServices= itemServices;
        }
        /// <summary>
        /// This is EndPoint retrive One Item By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetItem")]
        public virtual async Task <IActionResult> GetById(int id) 
        {
           
            var item = await _itemServices.GetByIdAsync(id);
            if (id == null)
                return BadRequest($"The Item With Id {id} Doesn't Exist!");
            var Display = new ItemDto
            {
                ItemName =item.ItemName ,
                Price = item.Price,
                SupplierId = item.SupplierId
            };
            return Ok(Display);
        }

        /// <summary>
        /// This is EndPoint retrive All Items
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllItems")]
        public virtual async Task<IActionResult>GetAll()
        {
            var items = await _itemServices.GetAllAsync();
            return Ok(items);
           
        }

        /// <summary>
        /// This is EndPoint Add a new Item
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("AddNewItem")]
        public async Task<IActionResult> AddItem(ItemDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item=new Item()
            {
                ItemName = dto.ItemName,
                Price = dto.Price,
                SupplierId = dto.SupplierId
            };

            var Result = await _itemServices.AddAsync(item);
            return Ok(Result);
            
             }

        /// <summary>
        /// This is EndPoint Delete a Item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteItem")]
        public async Task<IActionResult> DeleteItem(int id) 
        {
            var Result = await _itemServices.DeleteAsync(id);
            return Ok(Result);
            
        }

        /// <summary>
        /// This is EndPoint Update  Item
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("UpdateItem")]
        public IActionResult Update([FromBody]ItemDto dto, int id)
        {
            if (id == 0)
                return BadRequest($"Not Found Id=>{id}");
           Item updatedItem= _itemServices.GetById(id);

            updatedItem.ItemName = dto.ItemName;
            updatedItem.Price = dto.Price;
            updatedItem.SupplierId= dto.SupplierId;
            var result = _itemServices.Update(updatedItem);
            return Ok(result);

        }
    }
}
