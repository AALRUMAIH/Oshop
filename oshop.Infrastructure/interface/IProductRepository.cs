using oshop.Domain.Entities;

namespace oshop.Infrastructure.Common.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(int id);
        Task<Product> Add(Product product);
        Task<Product> Update(int id, Product product);
        Task<bool> Delete(int id);
    }
}
