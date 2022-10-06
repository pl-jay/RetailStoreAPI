using Microsoft.EntityFrameworkCore;
using RetailStoreAPI.DAL;
using RetailStoreAPI.Entities.Models;
using RetailStoreAPI.Entities.ViewModels;

namespace BLL
{
    public class ProductBll: IProductBll
    {
        private readonly RetailStoreDbContext retailStoreDbContext;

        public ProductBll(RetailStoreDbContext retailStoreDbContext)
        {
            this.retailStoreDbContext = retailStoreDbContext;
        }


        public ValueTask<Product?> GetProductById(Guid id)
        {
            try
            {
                return retailStoreDbContext.Products.FindAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<List<Product>> GetProducts()
        {
            try
            {
                return retailStoreDbContext.Products.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Product> SaveProduct(AddProductRequest addProduct)
        {
            var Product = new Product();
            try
            {
                Product = new Product()
                {
                    Id = Guid.NewGuid(),
                    ProductName = addProduct.ProductName,
                    Price = addProduct.Price
                };

                await retailStoreDbContext.Products.AddAsync(Product);
                await retailStoreDbContext.SaveChangesAsync();
            } catch(Exception)
            {
                throw;
            }

            return Product;
        }

        public async Task<Product?> UpdateProduct(Guid id, UpdateProduct updateProduct)
        {
            try
            {
                var Product = await retailStoreDbContext.Products.FindAsync(id);

                if (Product != null)
                {
                    Product.ProductName = updateProduct.ProductName;
                    Product.Price = updateProduct.Price;

                    await retailStoreDbContext.SaveChangesAsync();
                }
                return Product;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Product?> DeleteProduct(Guid id)
        {
            var Product = await retailStoreDbContext.Products.FindAsync(id);

            if (Product != null)
            {
                retailStoreDbContext.Remove(Product);
                await retailStoreDbContext.SaveChangesAsync();
            }
            return Product;
        }
    }
}