using AutoMapper;
using Ecommerce.Application.Dto;
using Ecommerce.Application.ViewModel;
using Ecommerce.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.MappingProfile
{
    internal class ModelsProfile : Profile
    {
        public ModelsProfile()
        {
            CreateMap<Brand, BrandDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();

            CreateMap<BrandViewModel, Brand>().ReverseMap();
            CreateMap<CategoryViewModel,Category>().ReverseMap();
            CreateMap<ProductViewModel, Product>().ReverseMap();
        }
    }
}
