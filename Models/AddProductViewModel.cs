using Admin.Models.Entities;

namespace Admin.Models
{
    public class AddProductViewModel
    {
        public string Name { get; set; }
        public string description { get; set; }
        public string categorie { get; set; }
        public float prix { get; set; }
        public string imagefille { get; set; }
        public int IdCategory { get; set; } // Clé étrangère pour la relation avec la table Categorie
        public Categorie Categories { get; set; }
        public CartDetail CartDetail { get; set; }
        //public IFormFile imgPath { get; set; }

    }
}
