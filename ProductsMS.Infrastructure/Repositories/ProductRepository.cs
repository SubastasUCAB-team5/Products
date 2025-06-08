using Azure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductMS.Core.Repositories;
using ProductMS.Domain.Entities;
using ProductMS.Infrastructure.DataBase;
using ProductMS.Infrastructure.Exceptions;


namespace ProductMS.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductsDbContext _dbContext;

        public ProductRepository(ProductsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid productId)
        {
            var productEntity = await _dbContext.Products.FindAsync(productId);
            if (productEntity == null)
            {
                throw new Exception("Product not found.");
            }
            _dbContext.Products.Remove(productEntity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Product?> GetByIdAsync(Guid productId)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(u => u.Id == productId);
        }

        public async Task<Product?> GetByCategoryAsync(string category)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(u => u.Category == category);
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }
    }

}
