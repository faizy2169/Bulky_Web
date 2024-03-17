using BulkeyWeb.Data;
using BulkeyWeb.Models;
using BulkeyWeb.Repository.IRepository;
using System.Linq.Expressions;

namespace BulkeyWeb.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
           _db.SaveChanges();
        }

        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}
