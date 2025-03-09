using oshop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oshop.Application.common.interfaces
{
    public interface ICategory
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task <String> AddCategory(Category category);
    }
}
