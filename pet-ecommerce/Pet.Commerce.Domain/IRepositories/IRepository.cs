using Pet.Commerce.Domain.Models;

namespace Pet.Commerce.Domain.IRepositories
{
    public interface IRepository <T> where T : class
    {
        public ICollection<T> GetAll();
        public T Insert(T entidade);
        public T Update(T entidade);
        public void Delete(T entidade);

    }
}
