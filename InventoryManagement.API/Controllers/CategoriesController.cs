using InventoryManagement.Core.Dto;
using InventoryManagement.Database.Model;
using InventoryManagement.Services.InterFace;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly ICategoryServices _categoryServices;
        public CategoriesController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        /// <summary>
        /// EndPoint retrive one Category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetCategory")]
        public virtual async Task<IActionResult> GetCategoryById(int id)
        {

            var category = await _categoryServices.GetByIdAsync(id);
            if (id == null)
                return BadRequest($"The Item With Id {id} Doesn't Exist!");

            return Ok(category);
        }

        /// <summary>
        /// EndPoint retrive All categories
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllCategories")]
        public virtual  async Task<IActionResult> GetAllCategories()
        {
            var category = await _categoryServices.GetAllAsync();
           
            return Ok( category);

        }
        /// <summary>
        /// EndPoint Add new category
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddCategory(CategoryDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var category = new Category
            {
                Name = dto.Name,
               Description = dto.Description

            };

            var Result = await _categoryServices.AddAsync(category);
            return Ok(Result);

        }
        /// <summary>
        /// EndPoint delete one category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var Result = await _categoryServices.DeleteAsync(id);

            return Ok(Result);

        }
        /// <summary>
        /// EndPoint update one category
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("UpdateCategory")]
        public IActionResult UpdateSupplier(CategoryDto dto, int id)
        {
            var category = _categoryServices.GetById(id);
            if (category == null)
            {
                return NotFound($"no book in this id={id}");
            }
            category.Name = dto.Name;
            category.Description = dto.Description;
             
            _categoryServices.Update(category);
            return Ok(category);
        }
    }
}
