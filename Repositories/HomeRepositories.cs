using Admin.Data;
using Admin.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Repositories
{
    public class HomeRepositories : IHomeRepository
    {
        private readonly AplicationDbContext dbContext;

        public HomeRepositories(AplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Product>> DisplayBooks(string searchTerm = "", int categoryId = 0)
        {
            // Utiliser la méthode de requête LINQ pour obtenir les livres de la base de données
            var query = dbContext.products.AsQueryable();

            // Filtrer par terme de recherche s'il est spécifié
            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(book => book.Name.Contains(searchTerm));
            }

            // Filtrer par catégorie si l'ID de catégorie est spécifié
            if (categoryId != 0)
            {
                query = query.Where(book => book.IdCategory == categoryId);
            }

            // Projeter les résultats dans la classe Book
            var books = await query
                .Select(book => new Product
                {
                    Id = book.Id,
                    Name = book.Name,
                    description = book.description,
                    IdCategory = book.IdCategory, // Assurez-vous que le modèle Book a une propriété Category pour stocker le nom de la catégorie
                    prix = book.prix
                }) .ToListAsync();
          

            return books;
        }
    }
}

