using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeManager.Domain.Models
{
    public class FridgeProduct : BaseEntity
    {
        [Required(ErrorMessage = "The fridge is not specified")]
        public Guid FridgeId { get; set; }
        public Fridge Fridge { get; set; }

        [Required(ErrorMessage = "The product is not specified")]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        [Required(ErrorMessage = "The quantity of the product is not specified")]
        [Range(0, 300, ErrorMessage = "Too much products")]
        public int Quantity { get; set; }
    }
}
