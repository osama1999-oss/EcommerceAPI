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
    internal class BrandService : IBrandService
    {
        private readonly IRepository<Brand> _brandRepository;
        private readonly EcommerceDbContext _context;
        private readonly IMapper _mapper;

        public BrandService(
            IRepository<Brand> brandRepository,
            EcommerceDbContext context,
            IMapper mapper)
        {
            _brandRepository = brandRepository;
            _context = context;
            _mapper = mapper;
        }

        public void CreateBrand(BrandDto brandInput)
        {
            Brand brand = _mapper.Map<Brand>(brandInput);
            brand.Id = Guid.NewGuid();
            _brandRepository.Add(brand);
        }

        public void DeleteBrand(Guid id)
        {
            var x = _brandRepository.FindOne(p => p.Id == id);
            _brandRepository.Delete(x);
        }

        public List<BrandViewModel> GetAllBrands()
        {
            var brands = _brandRepository.Get();

            var brandsViewModel = new List<BrandViewModel>();

            foreach (var brand in brands)
            {
                var brandViewModel = _mapper.Map<BrandViewModel>(brand);

                brandsViewModel.Add(brandViewModel);
            }
            return brandsViewModel;
        }

        public BrandViewModel GetBrand(Guid id)
        {
            var brand = _brandRepository.Get().Where(b => b.Id == id).FirstOrDefault();

            return _mapper.Map<BrandViewModel>(brand);
        }

        public BrandViewModel UpdateBrand(Guid brandId, BrandDto brandInput)
        {
            var selectedBrand = _brandRepository.Get().Where(b => b.Id == brandId).FirstOrDefault();

            selectedBrand.Name = brandInput.Name;

            selectedBrand.Portfolio = brandInput.Portfolio;

            selectedBrand.FranchiseAssets = brandInput.FranchiseAssets;

            selectedBrand.AboutUs = brandInput.AboutUs;

            _brandRepository.Edit(selectedBrand);

            return _mapper.Map<BrandViewModel>(selectedBrand);
        }
    }
}
