using InventoryManagement.Core.Dto;
using InventoryManagement.Database.Model;
using InventoryManagement.Services.InterFace;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierServices _supplierservices;
        public SuppliersController(ISupplierServices supplierservices)
        {
            _supplierservices = supplierservices;
        }

        /// <summary>
        /// EndPoint retrive one item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetItem")]
        public virtual async Task<IActionResult> GetSupplierById(int id)
        {

            var Sup = await _supplierservices.GetByIdAsync(id);
            if (id == null)
                return BadRequest($"The Item With Id {id} Doesn't Exist!");
            
            return Ok(Sup);
        }
        /// <summary>
        /// EndPoint retrive All item
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllCategories")]
        public virtual async Task<IActionResult> GetAllSuppliers()
        {
            var Sup = await _supplierservices.GetAllAsync();
            var Display = Sup.Select(Sup => new Supplier
            {
               SupplierId=Sup.SupplierId,
                SupplierName = Sup.SupplierName,
                ContactEmail = Sup.ContactEmail

        });
            return Ok(Display);

        }
        /// <summary>
        /// EndPoint Add new item
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("AddSupplier")]
        public async Task<IActionResult> AddSupplier(SupplierDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var Sup = new Supplier
            {
                SupplierName = dto.SupplierName,
                ContactEmail = dto.ContactEmail

            };

            var Result = await _supplierservices.AddAsync(Sup);
            return Ok(Result);

        }
        /// <summary>
        /// EndPoint delete one item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteSupplier")]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            var Result = await _supplierservices.DeleteAsync(id);
            
            return Ok(Result);

        }
        /// <summary>
        /// EndPoint update one item
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("UpdateSupplier")]
        public IActionResult UpdateSupplier(SupplierDto dto,int id)
        {
            var supplier = _supplierservices.GetById(id);
            if (supplier == null)
            {
                return NotFound($"no book in this id={id}");
            }
            supplier.SupplierName = dto.SupplierName;
            supplier.ContactEmail = dto.ContactEmail;
            supplier.SupplierId = id;
            _supplierservices.Update(supplier);
            return Ok(supplier);
        }
    }
}
