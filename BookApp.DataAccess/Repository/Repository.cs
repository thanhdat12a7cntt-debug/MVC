using System.Linq.Expressions;
using BookUserWeb.Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

using BBookWeb.DataAccess.Data;
namespace BookUserWeb.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        private ApplicationDbContext db;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
            
        }

        
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query.Where(filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public void Remove(T entity)
        {
           dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            IQueryable<T> query = dbSet;
        }

        public void Update(T entity)
        {
           dbSet.Update(entity);
        }
    }
}
