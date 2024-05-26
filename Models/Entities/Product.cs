using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Admin.Models.Entities
{
    public class Product
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string description { get; set; }

        //public string categorie { get; set; } = " ";
        public float prix { get; set; }
        public string imagefile { get; set; }
        [ForeignKey("Categories")]
        public int IdCategory { get; set; } // Clé étrangère pour la relation avec la table Categorie
        public virtual Categorie Categories { get; set; }
       public ICollection<CartDetail> CartDetails { get; set; }

        //    public List<Categorie> Categories { get; set; }

    }
}
