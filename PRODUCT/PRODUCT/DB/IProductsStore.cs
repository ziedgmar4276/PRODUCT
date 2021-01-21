using PRODUCT.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PRODUCT.DB
{
    public interface IProductStore
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProduct(int id);
        Task AddProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(Product product);
    }
}
