using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeManager.Domain.Models
{
    public class Product : BaseEntity
    {
        [Required(ErrorMessage = "The name of the product is not specified")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The default quantity of the product is not specified")]
        [Range(0, 500, ErrorMessage = "Too much products")]
        public int DefaultQuantity { get; set; }

        public string ImageSource { get; set; }
    }
}
