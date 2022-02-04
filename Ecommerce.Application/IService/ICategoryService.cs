using Ecommerce.Application.Dto;
using Ecommerce.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.IService
{
    public interface ICategoryService
    {
        void CreateCategory(CategoryDto categoryInput);
        List<CategoryViewModel> GetAllCategories();
        CategoryViewModel GetCategory(Guid id);
        CategoryViewModel UpdateCategory(Guid categoryId, CategoryDto categoryInput);
        void DeleteCategory(Guid id);
    }
}
