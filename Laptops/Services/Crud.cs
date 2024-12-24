using AutoMapper;
using Laptops.Data;
using Laptops.DTo;
using Laptops.Model;
using Microsoft.EntityFrameworkCore;

namespace Laptops.Services
{
    public class Crud<T> : ICrud<T> where T : class
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper mapper;
        public Crud(AppDbContext appDbContext, IMapper _mapper)
        {
            _appDbContext = appDbContext;
            mapper = _mapper;
        }

        public void Add(T entity)
        {
            _appDbContext.Set<T>().Add(entity);
            _appDbContext.SaveChanges();
        }

        public  IEnumerable<Laptop> All()
        {
           IEnumerable<Laptop> result = _appDbContext.Laptop.ToList();
            return result;
        }

        public void Delete(T entity) 
        {
            _appDbContext.Set<T>().Remove(entity);

        }

        public T Find(int id)
        {
          var item= _appDbContext.Set<T>().Find(id);
            return item;
        }

        public void Update(T entity)
        {
           _appDbContext.Update(entity);
        }
        public void savechanges()
        {
            _appDbContext.SaveChanges();
        }
    }
}
