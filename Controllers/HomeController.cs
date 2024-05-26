using Admin.Models;
using Admin.Models.Entities;
using Admin.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeRepository _homeRepository; 
        private readonly IProductRepositoryy<Product> _productRepositoryy;
            

        public HomeController(ILogger<HomeController> logger, IHomeRepository homeRepository, IProductRepositoryy<Product> _productRepositoryy)
        {
            _logger = logger;
            _homeRepository = homeRepository;
            this._productRepositoryy= _productRepositoryy;
        }

       

        public async Task <IActionResult> Index(string strerm="",int id=0)
        {
            IList<Product> Products = _productRepositoryy.GetAll();
            //IEnumerable<Product>  books = await  _homeRepository.DisplayBooks(strerm, id);
            return View(Products);
        }

        public IActionResult privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}