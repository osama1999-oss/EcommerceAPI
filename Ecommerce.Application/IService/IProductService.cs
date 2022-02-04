using Ecommerce.Application.Dto;
using Ecommerce.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.IService
{
    public interface IProductService
    {
        void CreateProduct(ProductDto productInput);
        List<ProductViewModel> GetAllProducts();
        ProductViewModel GetProduct(Guid id);
        ProductViewModel UpdateProduct(Guid productId, ProductDto productInput);
        void DeleteProduct(Guid id);

    }
}
