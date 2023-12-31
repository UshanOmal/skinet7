using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _storeContext;
        public ProductRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        public async Task<IReadOnlyList<Product>> GetProductAsync()
        {
            // var typeId =1;
            // var producrts = _storeContext.Products
            // .Where(x => x.ProductTypeId == typeId).Include(x => x.ProductType).ToListAsync();

           return await _storeContext.Products
           .Include(p => p.ProductType)
           .Include(p => p.ProductBrand)
           .ToListAsync();
        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
           return await _storeContext.Products
           .Include(p => p.ProductType)
           .Include(p => p.ProductBrand)
           .FirstOrDefaultAsync(p =>p.Id == id);
        }
        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandAsync()
        {
            return await _storeContext.ProductBrands.ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypeAsync()
        {
            return await _storeContext.ProductTypes.ToArrayAsync();
        }
    }
}


