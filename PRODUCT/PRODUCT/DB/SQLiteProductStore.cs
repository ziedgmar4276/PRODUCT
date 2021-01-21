using PRODUCT.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PRODUCT.DB
{

    public class SQLiteProductStore : IProductStore
    {
        private SQLiteAsyncConnection _connection;
        public SQLiteProductStore(ISQLiteDb db)
        {
            _connection = db.GetConnection();
            _connection.CreateTableAsync<Product>();
        }
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _connection.Table<Product>().ToListAsync();
        }
        public async Task DeleteProduct(Product product)
        {
            await _connection.DeleteAsync(product);
        }
        public async Task AddProduct(Product product)
        {
            await _connection.InsertAsync(product);
        }
        public async Task UpdateProduct(Product product)
        {
            await _connection.UpdateAsync(product);
        }
        public async Task<Product> GetProduct(int id)
        {
            return await _connection.FindAsync<Product>(id);
        }


      

     
    }
}
