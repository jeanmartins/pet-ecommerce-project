﻿using Pet.Commerce.Domain.Models;

namespace Pet.Commerce.Domain.IRepositories
{
    public interface IRepository <T> where T : class
    {
        public ICollection<T> GetAll();
        public T Get(int Id);
        public T Insert(T entidade);
        public T Update(T entidade);
        public bool Delete(T entidade);

    }
}
