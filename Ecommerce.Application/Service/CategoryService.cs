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
    internal class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly EcommerceDbContext _context;
        private readonly IMapper _mapper;

        public CategoryService(
            IRepository<Category> categoryRepository,
            EcommerceDbContext context,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _context = context;
            _mapper = mapper;
        }
        public void CreateCategory(CategoryDto categoryInput)
        {
            Category category = _mapper.Map<Category>(categoryInput);
            category.Id = Guid.NewGuid();
            _categoryRepository.Add(category);
        }

        public void DeleteCategory(Guid id)
        {
            var x = _categoryRepository.FindOne(p => p.Id == id);
            _categoryRepository.Delete(x);
        }

        public List<CategoryViewModel> GetAllCategories()
        {
            var categories = _categoryRepository.Get();

            var categoriesViewModel = new List<CategoryViewModel>();

            foreach (var category in categories)
            {
                var categoryViewModel = _mapper.Map<CategoryViewModel>(category);

                categoriesViewModel.Add(categoryViewModel);
            }
            return categoriesViewModel;
        }

        public CategoryViewModel GetCategory(Guid id)
        {
            var category = _categoryRepository.Get().Where(c => c.Id == id).FirstOrDefault();

            return _mapper.Map<CategoryViewModel>(category);
        }

        public CategoryViewModel UpdateCategory(Guid categoryId, CategoryDto categoryInput)
        {
            var selectedCategory = _categoryRepository.Get().Where(c => c.Id == categoryId).FirstOrDefault();

            selectedCategory.Name = categoryInput.Name;
            selectedCategory.Brief = categoryInput.Brief;
            selectedCategory.InternalSubCategory = categoryInput.InternalSubCategory;

            _categoryRepository.Edit(selectedCategory);

            return _mapper.Map<CategoryViewModel>(selectedCategory);
        }
    }
}
