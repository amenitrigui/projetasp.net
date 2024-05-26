using Admin.Data;
using Admin.Models;
using Admin.Models.Entities;
using Admin.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting.Internal;
using System;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;


//using System.Data.Entity;
using System.IO;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Net.WebRequestMethods;





//using System.Data;
//using System.Data.SqlClient;
//using System.Web.Mvc;

namespace Admin.Controllers
{
    public class ProductController1 : Controller
    {
        private readonly AplicationDbContext dbcontext;
        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment webHostEnvironmentt;
        private readonly IProductRepositoryy<Product> productRepositoryy;


        SqlConnection con = new SqlConnection();
        SqlCommand conn = new SqlCommand();
        SqlDataReader dr;
        //private object _webHostEnvironment;

        //public ActionResult AfficherProduitsAvecCategorie()
        //{
        //    List<Product> produitsAvecCategorie = new List<Product>();

        //    using (var context = new DbContext())
        //    {
        //        produitsAvecCategorie = (from p in context.products
        //                                 join c in context.Categories on p.CategorieID equals c.ID
        //                                 select new Product
        //                                 {
        //                                     Id = p.Id,
        //                                     Name = p.Name,
        //                                     description = p.Description,
        //                                     prix = p.prix,
        //                                     imagefile = p.imagefile,

        //                                     IdCategory = p.IdCategory,
        //                                     Categories = c.Designation // Ajoutez cette propriété si nécessaire
        //                                 }).ToList();
        //    }

        //    return View(produitsAvecCategorie);
        //}













        public ProductController1(AplicationDbContext dbContext, IConfiguration configuration, IWebHostEnvironment webHostEnvironment, IProductRepositoryy<Product> productRepositoryy)
        {
            this.dbcontext = dbContext;
            this.configuration = configuration;
            webHostEnvironmentt = webHostEnvironment;
            this.productRepositoryy = productRepositoryy;


        }

     
        public IActionResult Index()
        {
            var products = dbcontext.products.Include("Categories");
            return View(products);
        }
      
        //public ActionResult Listt ()

        // {
        //    ViewBag.Message = "hhhh";
        //     ViewBag.path = @"C:\Images\08631c5a-25d5-49b8-b009-eb867b035db2_22-06-F-ST005-D001-55_01.jpg";
        //     return View();
        // }

        // public FileContentResult myaction(string path)
        // {
        //     byte[] immarray= System.IO.File.ReadAllBytes(path);

        //     return new FileContentResult(immarray,"image/jpg");
        // }





        class Program
        {
            static void Main()
            {
                // Chemin vers le fichier image
                string cheminImage = @"C:\Users\Ameni Trigui\Downloads\csharp\Admin\wwwroot\Images\";

                try
                {
                    // Lire le contenu de l'image en tant que tableau d'octets
                    //    byte[] tableauOctets = System.IO.ReadAllBytes(cheminImage);


                    // Utiliser le tableau d'octets à votre convenance, par exemple, pour l'enregistrer dans une base de données
                    // ou pour le transmettre via un service web, etc.
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Une erreur s'est produite lors de la lecture de l'image : " + ex.Message);
                }
            }
        }









        [NonAction]
        private void loaccategorie()
        {
            var categories = dbcontext.Categories.ToList();
            ViewBag.categorie = new SelectList(categories, "Id", "designation");
        }
        //[HttpPost]
        //public IActionResult Add(Product model)

        //{
        //    dbcontext.products.Add(model);
        //   dbcontext.SaveChanges();
        //   return RedirectToAction("List");


        //}
        [HttpGet]
        public IActionResult Add()
        {
            loaccategorie();
            return View();
        }
        [HttpPost]

        public async Task<ActionResult> Add(Product film, IFormFile posterImage)
        {
         
            try
            {

                ViewBag.categorie = new SelectList(productRepositoryy.GetAll(), "Id", "Name");
                //if (posterImage == null || posterImage.Length == 0)
                //{
                //    return View(film);
                //}

                string uploadsFolder = Path.Combine(webHostEnvironmentt.WebRootPath, "Images");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(posterImage.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
             

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {

                    await posterImage.CopyToAsync(fileStream);
                }


                film.imagefile = uniqueFileName;
                productRepositoryy.Add(film);
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }






    //    public async Task<IActionResult> Add(AddProductViewModel viewModel)
    //{
    //    // Vérifiez si un fichier a été téléchargé
    //    if (viewModel.imagefille != null && viewModel.imagefille.Length > 0)
    //    {
    //        // Chemin de stockage pour l'image (dossier wwwroot/images)
    //        string uploadsFolder = Path.Combine(webHostEnvironmentt.WebRootPath, "images");

    //        // Générer un nom de fichier unique pour l'image téléchargée
    //        string uniqueFileName = Path.GetRandomFileName() + Path.GetExtension(viewModel.imagefille.FileName);

    //        // Chemin complet du fichier où l'image sera enregistrée
    //        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

    //        // Enregistrer l'image sur le serveur
    //        using (var fileStream = new FileStream(filePath, FileMode.Create))
    //        {
    //                await viewModel.imagefille.CopyToAsync(fileStream);
    //        }

    //        // Enregistrez le chemin du fichier dans votre modèle ou effectuez toute autre opération nécessaire
    //        viewModel.imgPath = uniqueFileName;
    //    }

    //    // Créer un nouvel objet Product à partir des données du viewModel
    //    var product = new Product
    //    {
    //        Name = viewModel.Name,
    //        description = viewModel.description,
    //        Categories = viewModel.Categories,
    //        IdCategory = viewModel.IdCategory,
    //        prix = viewModel.prix,
    //        // Assurez-vous d'assigner le nom du fichier à la propriété imagefile
    //        imagefile = viewModel.imgPath // Assurez-vous que ImageFile est de type string dans votre modèle Product
    //    };

    //    // Ajouter le produit à votre contexte de base de données
    //    // Pensez à injecter votre DbContext dans ce contrôleur et à appeler la méthode Add() pour ajouter le produit
    //    if (viewModel.IsValid)
    //    {
    //        DbContext.Products.Add(product);
    //        await DbContext.SaveChangesAsync();

    //        // Rediriger vers une action de confirmation ou toute autre page appropriée
    //        return RedirectToAction("List");
    //    }

    //    // Si le modèle n'est pas valide, réafficher le formulaire avec les erreurs de validation
    //    return View(viewModel);
    //}



    //[HttpPost]
    //public async Task<IActionResult> Add(AddProductViewModel viewModel)
    //{
    //    var product = new Product
    //    {
    //        Name = viewModel.Name,
    //        description = viewModel.description,
    //         Categories = viewModel.Categories,
    //        IdCategory = viewModel.IdCategory,

    //        prix = viewModel.prix,
    //        if (ModelState.IsValid)
    //    {
    //        // Vérifiez si un fichier a été téléchargé
    //        if (viewModel.imagefille != null && viewModel.imagefille.Length > 0)
    //        {
    //            // Chemin de stockage pour l'image (dossier wwwroot/images)
    //            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");

    //            // Générer un nom de fichier unique pour l'image téléchargée
    //            string uniqueFileName = Guid.NewGuid().ToString() + "_" + viewModel.imagefille.FileName;

    //            // Chemin complet du fichier où l'image sera enregistrée
    //            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

    //            // Enregistrer l'image sur le serveur
    //            using (var fileStream = new FileStream(filePath, FileMode.Create))
    //            {
    //                await viewModel.imagefille.CopyToAsync(fileStream);
    //            }

    //            // Enregistrez le nom du fichier dans votre modèle ou effectuez toute autre opération nécessaire
    //            // Par exemple, vous pouvez stocker le nom du fichier dans une base de données
    //            viewModel.imagefille = uniqueFileName;
    //        }

    //        //categorie = viewModel.categorie,
    //        //  imagefile=viewModel.imagefille,


    //   };
    //   await dbcontext.products.AddAsync(product);

    //await dbcontext.SaveChangesAsync();
    //   return RedirectToAction("List");
    //}
    [HttpGet]
        public async Task<IActionResult> List()
        {
            var product = await dbcontext.products.ToListAsync();
            return View(product);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var Product = await dbcontext.products.FindAsync(id);
            loaccategorie();
            return View(Product);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Product viewModel)
        {
            var product = await dbcontext.products.FindAsync(viewModel.Id);
            if (product != null)
            {
                product.Name = viewModel.Name;
                product.description = viewModel.description;
                product.prix = viewModel.prix;
                //product.categorie = viewModel.categorie;
                await dbcontext.SaveChangesAsync();

            }
            return RedirectToAction("List");
        }
        public ActionResult loginAdmin(string email, string Motpasse)
        {
            // var admin = db.Admin.ToList();
            if (email == null || Motpasse == null)
            {
                ViewBag.ErrorMessage = "Please provide both address and password.";
                return View("Login");
            }
            Loginn admin = new Loginn();

            string query = "select email , Motpasse from Loginn where email LIKE @email + '%' and Motpasse LIKE @Motpasse + '%';";
            string connectionString = configuration.GetConnectionString("produitPortal");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@Motpasse", Motpasse);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        /* if (admin.adresse != adr && admin.mdp != mdppp)
                         {
                             return RedirectToAction("Add");
                         }
                         ViewBag.ErrorMessage = "Invalid credentials. Please try again.";
                         return View("loginAdmin");*/
                        while (reader.Read())
                        {
                            return RedirectToAction("List");
                        }
                    }
                }
            }
            /*if( admin.adresse==adr && admin.mdp==mdppp)
            {
                return View("Add");
            }
            return View("loginAdmin");*/



            return View("Login");
        }















        //[HttpGet]
        //public ActionResult Login()
        //{
        //    return View();
        //}
        //void connectionString()
        //{
        //    con.ConnectionString = "data source=AMENI\\SQLEXPRESS; database=produit;integrated security=SSPI;";

        //}
        //[HttpPost]
        //public ActionResult Verify(Loginn acc)
        //{
        //    try
        //    {
        //        using (var con = new SqlConnection("data source=AMENI\\SQLEXPRESS; database=produit;integrated security=SSPI;"))
        //        {
        //            con.Open();

        //            using (var cmd = new SqlCommand("SELECT * FROM Loginn WHERE email=@email AND Motpasse=@Motpasse", con))
        //            {
        //                cmd.Parameters.AddWithValue("@email", acc.email);
        //                cmd.Parameters.AddWithValue("@Motpasse", acc.Motpasse);

        //                using (var dr = cmd.ExecuteReader())
        //                {
        //                    if (dr.Read())
        //                    {
        //                        return View("List");
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return View("Error");
        //    }

        //    return View("Error");
        //}

        //[HttpPost]
        ////public async Task<ActionResult> Deleteconfirmed(Product viewModel)
        //{
        //    var product = await dbcontext.products.AsNoTracking().FirstOrDefaultAsync(x => x.Id == viewModel.Id);
        //    if (product != null)
        //    {
        //        dbcontext.products.Remove(viewModel);
        //        await dbcontext.SaveChangesAsync();
        //    }
        //    return RedirectToAction("List");

        //}



        [HttpPost]
        public async Task<IActionResult> delete(Product model)
        {
            var employee = await dbcontext.products.FindAsync(model.Id);
            if (employee != null)
            {
                dbcontext.products.Remove(employee);

                await dbcontext.SaveChangesAsync();
                return RedirectToAction("List");
            }
            return RedirectToAction("List");

        }

        //public Categorie GetCategorieByCode(int code)
        //{
        //    string connectionString = ;
        //    int code = 123; // For example
        //    return View();

        //}
        public IActionResult Recherche(string searchTxt)
        { List<Product> results = new List<Product>();
            if (searchTxt == null) 
            { searchTxt = ""; } 
            else 
            { string query = "SELECT Name FROM products WHERE Name LIKE @Name + '%';";
                string connectionString = configuration.GetConnectionString("produitPortal");
                using (SqlConnection connection = new SqlConnection(connectionString)) 
                { connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection)) 
                    { command.Parameters.AddWithValue("@Name", searchTxt); 
                        using (SqlDataReader reader = command.ExecuteReader()) 
                        {
                            while (reader.Read()) 
                            {
                                Product employee = new Product()
                            {
                                Name = reader["Name"].ToString() 
                            }; 
                                results.Add(employee);
                            }
                        } 
                    }
                }
            }
            return Json(results);
        }








        [HttpGet]
        public IActionResult delete(int? id)


        {
           if (id != null)
            {
               NotFound();
           }
           loaccategorie();
           var product = dbcontext.products.Find(id);
           return View(product);
       }
        //[HttpPost]
        //public IActionResult Deleteconfirmed(Product model)
        //{
        //    dbcontext.products.Remove(model);
        //    return RedirectToAction(nameof(List));
        //}


       



    }

    
}
