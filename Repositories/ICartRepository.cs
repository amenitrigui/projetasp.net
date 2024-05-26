
using global::Admin.Models.Entities;
using System.Threading.Tasks;

namespace Admin.Repositories
{
   


    public interface ICartRepository
    {


        Task<int> AddItem(int bookId, int qty);
        Task<int> RemoveItem(int bookId);
        Task<Product> GetUserCart();
        Task<int> GetCartItemCount(string userId = "");
        Task<Product> GetCart(string userId);
        Task<bool> DoCheckout(CheckoutModel model);
    }


}
