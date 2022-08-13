using System.ComponentModel.DataAnnotations;

namespace FridgeManager.DTO.Fridge
{
    public class FridgeForUpdateDto
    {
        [Required(ErrorMessage = "Id is not specified")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The name of the fridge is not specified")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string Name { get; set; }

        [MaxLength(30, ErrorMessage = "Maximum length for the OwnerName is 30 characters.")]
        public string OwnerName { get; set; }

        [Required(ErrorMessage = "The model of the fridge is not specified")]
        public Guid ModelId { get; set; }
    }
}
