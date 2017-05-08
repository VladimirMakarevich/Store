using Store.BL.Repository.Interfaces;
using Store.DAL.Context;
using Store.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL.Repository
{
    public class ProductRepository : IProductRepository<Product>
    {
        private StoreContext _db;

        public ProductRepository(StoreContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _db.Products.ToListAsync();
        }

        public async Task<Product> GetAsync(int id)
        {
            return await _db.Products.FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
