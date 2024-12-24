using Laptops.DTo;
using Laptops.Model;

namespace Laptops.Services
{
    public interface ICrud<T> where T : class
    {
        public void Add(T entity);
        public void Update(T entity);
        public void Delete(T entity);
        public  IEnumerable<Laptop> All();
        public T Find(int id);
        public void savechanges();
    }
}
