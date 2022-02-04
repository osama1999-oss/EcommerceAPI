using Ecommerce.Infrastructure.AppContext;
using Ecommerce.Infrastructure.IBaseRepository;
using System.Linq.Expressions;

namespace Ecommerce.Infrastructure.BaseRepository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly EcommerceDbContext _context;

        public Repository(EcommerceDbContext context)
        {
            _context = context;
        }
        public void Add(T model)
        {
            _context.Set<T>().Add(model);
            Save();
        }

        public void Delete(T model)
        {
            _context.Remove(model);
            Save();
        }

        public T Edit(T model)
        {
            _context.Set<T>().Update(model);
            Save();
            return model;
        }

        public IList<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }

        public T FindOne(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).SingleOrDefault();
        }

        public IList<T> Get()
        {
            return _context.Set<T>().ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
