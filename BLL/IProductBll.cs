using RetailStoreAPI.Entities.Models;
using RetailStoreAPI.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IProductBll
    {
        public Task<List<Product>> GetProducts();
        public ValueTask<Product?> GetProductById(Guid id);
        public  Task<Product> SaveProduct(AddProductRequest addProduct);
        public Task<Product?> UpdateProduct(Guid id, UpdateProduct updateProduct);
        public Task<Product?> DeleteProduct(Guid id);
    }
}
