using Microsoft.EntityFrameworkCore;
using oshop.Domain.Entities;
using oshop.Infrastructure.Common.Interfaces;
using oshop.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace oshop.Infrastructure.Repositories
{
    public class CategoryController : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        
        public async Task <IEnumerable<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }

     
        public  async Task<string> Add(Category category)
        {
            if (string.IsNullOrWhiteSpace(category.category))
            {
                return  "Category name cannot be empty.";
            }


            if (_context.Categories.Any(c => c.category == category.category))
            {
                return  "Category already exists." ;
            }

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return "Category added successfully.";
        }
    }
}
