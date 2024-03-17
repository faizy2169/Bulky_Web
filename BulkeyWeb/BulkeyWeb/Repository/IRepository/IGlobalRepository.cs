using BulkeyWeb.Models;

namespace BulkeyWeb.Repository.IRepository
{
    public interface IGlobalRepository 
    {
        ICategoryRepository categoryRepo { get; }
        public void Save();

        public void Update(Category obj);

    }
}
