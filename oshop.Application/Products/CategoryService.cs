using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using oshop.Application.common.interfaces;
using oshop.Domain.Entities;
using oshop.Infrastructure.Common.Interfaces;

namespace oshop.Application.Products
{
    public class CategoryService : ICategory
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task <IEnumerable<Category>> GetAllCategories()
        {
            return await _categoryRepository.GetAll();
        }
        
        public async Task<String> AddCategory(Category category)
        {
            return await _categoryRepository.Add(category);
        }
    }
}
