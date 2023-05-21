using Pet.Commerce.Domain.IRepositories;
using Pet.Commerce.Domain.Models;

namespace Pet.Commerce.Infra.Infra.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private EcommerceContext _ecommerceContext;
        public Repository(EcommerceContext ecommerceContext)
        {
            _ecommerceContext = ecommerceContext;
        }

        public bool Delete(T entidade)
        {
            _ecommerceContext.Set<T>().Remove(entidade);
            var result = _ecommerceContext.SaveChanges();
            return Convert.ToBoolean(result);
        }
        public T Insert(T entidade)
        {
            var ent = _ecommerceContext.Set<T>().Add(entidade);
            _ecommerceContext.SaveChanges();
            return entidade;
        }

        public T Update(T entidade)
        {
           _ecommerceContext.Set<T>().Update(entidade);
           _ecommerceContext.SaveChanges();
           return entidade;
        }

        public ICollection<T> GetAll()
        {
            return _ecommerceContext.Set<T>().ToList();
        }

        public T Get(int id)
        {
            return _ecommerceContext.Set<T>().Find(id);
        }
    }
}
