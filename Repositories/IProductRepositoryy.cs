using Admin.Models.Entities;

namespace Admin.Repositories
{
    public interface IProductRepositoryy<Product>
    {
        IList<Product> GetAll();
        Product GetById(int id);
        void Add(Product c);
        void Edit(Product c);
        void Delete(Product c);
        //double StudentAgeAverage(int ProductId);
        int ProductCount(int ProductId);

    }
}



   


