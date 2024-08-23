using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Mango.Services.ShppingCartAPI.Models.Dto;

namespace Mango.Services.ShppingCartAPI.Models
{
    public class CartDetails
    {
        [Key]
        public int CardDetailsId { get; set; }
        public int HeaderId { get; set; }
        [ForeignKey("CartHeaderId")]
        public CartHeader CartHeader { get; set; }
        public int ProductId { get; set; }
        [NotMapped]
        public ProductDto Product { get; set; }
        public int Count { get; set; }
    }
}
