using Admin.Data;
using Admin.Models.Entities;

namespace Admin.Repositories
{
    public class ProductRepository :IProductRepositoryy<Product>
    {
        readonly AplicationDbContext context;
        public ProductRepository(AplicationDbContext context)
        {
            this.context = context;
        }
        public IList<Product> GetAll()
        {
            return context.products.OrderBy(c => c.Name).ToList();
        }
        public Product GetById(int id)
        {
            return context.products.Find(id);
        }
        public void Add(Product c)
        {
            context.products.Add(c);
            context.SaveChanges();
        }
        public void Edit(Product c)
        {
            Product c1 = context.products.Find(c.Id);
            if (c1 != null)
            {
                c1.Name = c.Name;
                c1.description = c.description;
                c1.imagefile = c.imagefile;
                context.SaveChanges();
            }
        }
        public void Delete(Product c)
        {
            Product c1 = context.products.Find(c.Id);
            if (c1 != null)
            {
                context.products.Remove(c1);
                context.SaveChanges();
            }
        }

        public int ProductCount(int ProductId)
        {
            return context.products.Where(c => c.Id ==
            ProductId).Count();
        }

        public int ClubCount(int clubId)
        {
            throw new NotImplementedException();
        }
    }
}



