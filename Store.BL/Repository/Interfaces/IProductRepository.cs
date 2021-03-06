﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.BL.Repository.Interfaces
{
    public interface IProductRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);
    }
}
