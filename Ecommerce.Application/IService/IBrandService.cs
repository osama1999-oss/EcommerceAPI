using Ecommerce.Application.Dto;
using Ecommerce.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.IService
{
    public interface IBrandService
    {
        void CreateBrand(BrandDto brandInput);
        List<BrandViewModel> GetAllBrands();
        BrandViewModel GetBrand(Guid id);
        BrandViewModel UpdateBrand(Guid brandId, BrandDto brandInput);
        void DeleteBrand(Guid id);
    }
}
