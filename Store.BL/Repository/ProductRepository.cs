using Store.BL.Repository.Interfaces;
using Store.DAL.Context;
using Store.DAL.Entities;
using System;
using System.Collections.Generic;
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
    }
}
