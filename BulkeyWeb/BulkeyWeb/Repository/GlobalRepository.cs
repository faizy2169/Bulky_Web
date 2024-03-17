using BulkeyWeb.Data;
using BulkeyWeb.Models;
using BulkeyWeb.Repository.IRepository;

namespace BulkeyWeb.Repository
{
    public class GlobalRepository : IGlobalRepository
    {
        private readonly ApplicationDbContext _db;
        public ICategoryRepository categoryRepo { get; set; }

        public GlobalRepository(ApplicationDbContext db)
        {
            _db = db;
            categoryRepo = new CategoryRepository(_db);
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
