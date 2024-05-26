using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Admin.Models.Entities
{
    public class CartDetail
    {
      
            public int Id { get; set; }
            [Required]
            public int ShoppingCartId { get; set; }
            [Required]
            public int BookId { get; set; }
            [Required]
            public int Quantity { get; set; }
            [Required]
            public double UnitPrice { get; set; }
            public Product product { get; set; }
       
    }

}

