using BookUserWeb.Data.Repository.IRepository;
using BookUserWeb.Models;

using BBookWeb.DataAcess;
using BBookWeb.DataAccess.Data;

namespace BookUserWeb.Data.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        

        void ICategoryRepository.Update(Category obj)
        {
            _db.Update(obj);
        }
    }
}
