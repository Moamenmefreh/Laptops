using AutoMapper;
using Laptops.Data;
using Laptops.DTo;
using Laptops.Model;
using Microsoft.EntityFrameworkCore;

namespace Laptops.Services
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper mapper;
        public Repository(AppDbContext context, IMapper mappe)
        {
            _context = context;
            this.mapper = mappe;
        }

        public IEnumerable<Laptop> allLaptops()
        {
          IEnumerable<Laptop> all=_context.Laptop.Include(x=>x.Processor)
                .Include(x=>x.Ram).Include(x=>x.Storage)
                .ToList();
          
            return all;
        }
        public void Add(StorageDTO storage) {
            var item = mapper.Map<Storage>(storage);
            _context.storages.Add(item);
            _context.SaveChanges();
        }

        public User SearchbyuserId(int id)
        {
            var item = _context.Users.Include(x=>x.Laptop).SingleOrDefault(x => x.Id == id);
            if (item != null)
            {
                return item;
            }
            else
            {
                return null;
            }
        }
    }
}
