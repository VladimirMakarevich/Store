using Store.BL.Repository;
using Store.DAL.Context;
using System;

namespace Store.BL.UnityOfWork
{
    public class UnityOfWork : IUnityOfWork, IDisposable
    {
        private StoreContext _db;
        private ProductRepository _productRepository;

        public UnityOfWork(StoreContext db)
        {
            _db = db;
        }

        public UnityOfWork()
        {
            _db = new StoreContext();
        }

        public ProductRepository Products
        {
            get
            {
                if (_productRepository == null)
                    _productRepository = new ProductRepository(_db);
                return _productRepository;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
