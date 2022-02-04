using Ecommerce.Application.Dto;
using Ecommerce.Application.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("CreateCategory")]
        public ActionResult CreateCategory(CategoryDto categoryInput)
        {
            _categoryService.CreateCategory(categoryInput);
            return Ok("Done!");
        }

        [HttpGet("GetAllCategories")]
        public ActionResult GetAllCategories()
        {
            return Ok(_categoryService.GetAllCategories());
        }

        [HttpGet("GetCategory")]
        public ActionResult GetCategory(Guid categoryId)
        {
            return Ok(_categoryService.GetCategory(categoryId));
        }

        [HttpPatch("UpdateCategory")]
        public ActionResult UpdateCategory(Guid Id, CategoryDto categoryInput)
        {
            return Ok(_categoryService.UpdateCategory(Id, categoryInput));
        }

        [HttpDelete("DeleteCategory")]
        public ActionResult DeleteCategory(Guid categoryId)
        {
            _categoryService.DeleteCategory(categoryId);
            return Ok("Deleted!");
        }

    }
}
