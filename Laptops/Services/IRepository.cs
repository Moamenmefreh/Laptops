using Laptops.DTo;
using Laptops.Model;

namespace Laptops.Services
{
    public interface IRepository
    {
        public IEnumerable<Laptop> allLaptops();
        public void Add(StorageDTO storage);
        public User SearchbyuserId(int id);
    }
}
