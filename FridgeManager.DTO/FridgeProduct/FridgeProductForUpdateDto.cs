using System.ComponentModel.DataAnnotations;

namespace FridgeManager.DTO.FridgeProduct
{
    public class FridgeProductForUpdateDto
    {
        [Required(ErrorMessage = "Id is not specified")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The quantity of the product is not specified")]
        [Range(0, 300, ErrorMessage = "Too much products")]
        public int Quantity { get; set; }
    }
}
