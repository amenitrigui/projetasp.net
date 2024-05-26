using Admin.Models.Entities;

namespace Admin
{
    public interface IHomeRepository
    {
        Task<IEnumerable<Product>> DisplayBooks(string searchTerm = "", int categoryId = 0);
    }
}

