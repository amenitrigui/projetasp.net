using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Admin.Models.Entities
{
   public class Categorie
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Categorie")]

        public string designation { get; set; } 
        
      //public Products Category { get; set; }
   }
}
