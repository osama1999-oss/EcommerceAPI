using Ecommerce.Application.Dto;
using Ecommerce.Application.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        
        [HttpPost("CreateBrand")]
        public ActionResult CreateBrand(BrandDto brandInput)
        {
            _brandService.CreateBrand(brandInput);
            return Ok("Done!");
        }

        [HttpGet("GetAllBrands")]
        public ActionResult GetAllBrands()
        {
            return Ok(_brandService.GetAllBrands());
        }

        [HttpGet("GetBrand")]
        public ActionResult GetBrand(Guid brandId)
        {
            return Ok(_brandService.GetBrand(brandId));
        }

        [HttpPatch("UpdateBrand")]
        public ActionResult UpdateBrand(Guid Id, BrandDto brandinput)
        {

            return Ok(_brandService.UpdateBrand(Id, brandinput));
        }

        [HttpDelete("DeleteBrand")]
        public ActionResult DeleteBrand(Guid brandId)
        {
            _brandService.DeleteBrand(brandId);
            return Ok("Deleted!");
        }

    }
}
