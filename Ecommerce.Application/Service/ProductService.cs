using AutoMapper;
using Ecommerce.Application.Dto;
using Ecommerce.Application.IService;
using Ecommerce.Application.ViewModel;
using Ecommerce.Core.Model;
using Ecommerce.Infrastructure.AppContext;
using Ecommerce.Infrastructure.IBaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Service
{
    internal class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly EcommerceDbContext _context;
        private readonly IMapper _mapper;

        public ProductService
            (
            IRepository<Product> productRepository,
            EcommerceDbContext context,
            IMapper mapper
            )
        {
            _productRepository = productRepository;
            _context = context;
            _mapper = mapper;
        }

        public void CreateProduct(ProductDto productInput)
        {
            Product product = _mapper.Map<Product>(productInput);
            product.Id = Guid.NewGuid();
            _productRepository.Add(product);
        }

        public void DeleteProduct(Guid id)
        {
            var x = _productRepository.FindOne(p => p.Id == id);
            _productRepository.Delete(x);
        }

        public List<ProductViewModel> GetAllProducts()
        {
            var products = _productRepository.Get();

            var productsViewModel = new List<ProductViewModel>();

            foreach (var product in products)
            {
                var productViewModel = _mapper.Map<ProductViewModel>(product);

                productsViewModel.Add(productViewModel);
            }

            return productsViewModel;
        }

        public ProductViewModel GetProduct(Guid id)
        {
            var product = _productRepository.Get().Where(p => p.Id == id).FirstOrDefault();

            return _mapper.Map<ProductViewModel>(product);
        }

        public ProductViewModel UpdateProduct(Guid productId, ProductDto productInput)
        {
            var selectedProduct = _productRepository.Get().Where(p => p.Id == productId).FirstOrDefault();

            selectedProduct.Name = productInput.Name;
            selectedProduct.Description = productInput.Description;
            selectedProduct.BrandId = productInput.BrandId;
            selectedProduct.ProductionDate = productInput.ProductionDate;

            _productRepository.Edit(selectedProduct);

            return _mapper.Map<ProductViewModel>(selectedProduct);
        }
    }
}
