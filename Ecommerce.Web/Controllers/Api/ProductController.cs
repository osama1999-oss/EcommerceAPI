using Ecommerce.Application.Dto;
using Ecommerce.Application.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("CreateProduct")]
        public ActionResult CreateProduct(ProductDto productInput)
        {
            _productService.CreateProduct(productInput);
            return Ok("Done!");
        }

        [HttpGet("GetAllProducts")]
        public ActionResult GetAllProducts()
        {
            return Ok(_productService.GetAllProducts());
        }

        [HttpGet("GetProduct")]
        public ActionResult GetProduct(Guid productId)
        {
            return Ok(_productService.GetProduct(productId));
        }

        [HttpPatch("UpdateProduct")]
        public ActionResult UpdateProduct(Guid Id, ProductDto productInput)
        {
            return Ok(_productService.UpdateProduct(Id, productInput));
        }

        [HttpDelete("DeleteProduct")]
        public ActionResult DeleteProduct(Guid productId)
        {
            _productService.DeleteProduct(productId);
            return Ok("Deleted!");
        }
    }
}
