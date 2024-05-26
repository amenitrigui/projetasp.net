using Admin.Models.Entities;

using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

using Admin.Data;
using Microsoft.AspNetCore.Identity;


using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting.Internal;
using System;

//namespace Admin.Repositories
//{
    //public class CartRepository : ICartRepository
    //{
    //    private readonly ApplicationDbContextt _db;
    //    private readonly UserManager<IdentityUser> _userManager;
    //    private readonly IHttpContextAccessor _httpContextAccessor;
    //    private object _httpcontextaccessor;
    //    private object _usermanager;

    //    public Task<int> AddItem(int bookId, int qty)
    //    {
    //        throw new NotImplementedException();
    //    }

        //public CartRepository(ApplicationDbContext db, IHttpContextAccessor httpContextAccessor, UserManager<IdentityUser> userManager)
        // {
        //     _db = db;
        //    _userManager = userManager;
        //    _httpContextAccessor = httpContextAccessor;
        // }
        //private readonly ApplicationDbContextt context;
        //public CartRepository(ApplicationDbContextt context)
        //{
        //    this.context = context;
        //}

        //public Task<int> AddItem(int bookId, int qty)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<bool> DoCheckout(CheckoutModel model)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Product> GetCart(string userId)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<int> GetCartItemCount(string userId = "")
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<Product> GetUserCart()
        //{
        //    var userCart = await context.CartDetails.GetAll();
        //    return userCart;
        //}

        //public Task<int> RemoveItem(int bookId)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task <int> AddItem(int bookid, int qty)
        //{

        //    try
        //    {
        //        string userid = getuserid();
        //        if (string.IsNullOrEmpty(userid))
        //            throw new Exception("l'utilisateur n'est pas connecté");

              
        //        {
        //            var cart = await GetCart(userid);
        //            if (cart == null)
        //            {
        //                cart = new Product { Name = userid };
        //                //_db.cartdetails(cart);
        //                //await _db.savechangesasync();
        //            }

        //            var cartitem = await _db.cartdetail.firstordefaultasync(a => a.shoppingcartid == cart.id && a.bookid == bookid);
        //            if (cartitem != null)
        //            {
        //                cartitem.quantity += qty;
        //            }
        //            else
        //            {
        //                var book = await _db.products.findasync(bookid);
        //                if (book == null)
        //                    throw new Exception("livre non trouvé");

        //                cartitem = new  CartDetail
        //                {
        //                    BookId = bookid,
        //                    ShoppingCartId = cart.Id,
        //                 Quantity = qty,
        //                   UnitPrice= book.price
        //                };
        //                _db.add(cartitem);
        //            }

        //            await _db.savechangesasync();
                  
        //        }

        //        return await getcartitemcount(userid);
        //    }
        //    catch (Exception ex)
        //    {
        //        // loguer l'erreur
        //        throw; // renvoyer l'exception pour la gérer plus haut
        //    }
        //}

        //        //public async Task<int> RemoveItem(int bookId)
        //        //{
        //        //    try
        //        //    {
        //        //        string userId = GetUserId();
        //        //        if (string.IsNullOrEmpty(userId))
        //        //            throw new Exception("L'utilisateur n'est pas connecté");

        //        //        using (var transaction = _db.Database.BeginTransaction())
        //        //        {
        //        //            var cart = await GetCart(userId);
        //        //            if (cart == null)
        //        //                throw new Exception("Panier invalide");

        //        //            var cartItem = await _db.CartDetails.FirstOrDefaultAsync(a => a.ShoppingCartId == cart.Id && a.BookId == bookId);
        //        //            if (cartItem == null)
        //        //                throw new Exception("Aucun article dans le panier");

        //        //            if (cartItem.Quantity == 1)
        //        //            {
        //        //                _db.CartDetails.Remove(cartItem);
        //        //            }
        //        //            else
        //        //            {
        //        //                cartItem.Quantity -= 1;
        //        //            }

        //        //            await _db.SaveChangesAsync();
        //        //            transaction.Commit();
        //        //        }

        //        //        return await GetCartItemCount(userId);
        //        //    }
        //        //    catch (Exception ex)
        //        //    {
        //        //        // Loguer l'erreur
        //        //        throw; // Renvoyer l'exception pour la gérer plus haut
        //        //    }
        //        //}
        //public async Task<Product> GetUserCart()
        //{
        //    try
        //    {
        //        string userId = getuserid();
        //        if (string.IsNullOrEmpty(userId))
        //            throw new Exception("Utilisateur invalide");

        //        // Assurez-vous que _db.products est de type IQueryable<Product>
        //        IQueryable<Product> query = (IQueryable<Product>)_db.products;

        //        return await query.FirstOrDefaultAsync(a => a.Name == userId);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Loguer l'erreur
        //        throw; // Renvoyer l'exception pour la gérer plus haut
        //    }
        //}

        //public async Task  <Product> getusercart()
        //{
        //    try
        //    {
        //        string userid = getuserid();
        //        if (string.IsNullOrEmpty(userid))
        //            throw new Exception("utilisateur invalide");

        //        // assurez-vous que _db.products est de type iqueryable<product>
        //        iqueryable<Product> query = (iqueryable<Product>)_db.products;


        //        return await _db.products
        //        //.include(a => a.cartdetails)
        //        //    .theninclude(a => a.bookid)
        //        //.firstordefaultasync(a => a.name == userid);


        //                }
        //    catch (Exception ex)
        //    {
        //        // loguer l'erreur
        //        throw; // renvoyer l'exception pour la gérer plus haut
        //    }
        //}

        //public async Task  <int> getcartitemcount(string userid = "")
        //{
        //    try
        //    {
        //        if (!string.IsNullOrEmpty(userid))
        //        {
        //            userid = getuserid();
        //        }
        //        var data = await (from cart in _db.s
        //                          join cartdetail in _db.products
        //                          on cart.id equals cartdetail.id
        //                          select new { cartdetail.id }
        //                       ).tolistasync();
        //        return data.count;


        //    }
        //    catch (Exception ex)
        //    {
        //        // loguer l'erreur
        //        throw; // renvoyer l'exception pour la gérer plus haut
        //    }
        //}

        //        public async Task<bool> DoCheckout(CheckoutModel model)
        //        {
        //            try
        //            {
        //                // Logique de validation et de traitement de la commande
        //                // Utilisation de transactions si nécessaire

        //                return true; // Succès
        //            }
        //            catch (Exception ex)
        //            {
        //                // Loguer l'erreur
        //                throw; // Renvoyer l'exception pour la gérer plus haut
        //            }
        //        }

        //private string getuserid()
        //{
        //    var principal = _httpcontextaccessor.httpcontext.user;
        //    string userid = _usermanager.getuserid(principal);
        //    return userid;
        //}

        //public Task<Product> GetUserCart()
        //{
        //    throw new NotImplementedException();
        //}

        //Task<int> ICartRepository.AddItem(int bookId, int qty)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Product> GetUserCart()
        //{
        //    throw new NotImplementedException();
//        //}
//    }
//}
