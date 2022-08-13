using System.ComponentModel.DataAnnotations;

namespace FridgeManager.DTO.Product
{
    public class ProductForCreationDto
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
