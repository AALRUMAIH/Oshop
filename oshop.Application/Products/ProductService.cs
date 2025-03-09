using oshop.Application.Common.Interfaces;
using oshop.Domain.Entities;
using oshop.Infrastructure.Common.Interfaces;
using oshop.Infrastructure.Repositories;

namespace oshop.Application.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _productRepository.GetAll();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _productRepository.GetById(id);
        }

        public async Task<Product> CreateProduct(Product product)
        {
            
            return await _productRepository.Add(product);
        }

        public async Task<Product> UpdateProduct(int id, Product product)
        {
            return await _productRepository.Update(id, product);
        }

        public async Task<bool> DeleteProduct(int id)
        {
            return await _productRepository.Delete(id);
        }
    }
}
