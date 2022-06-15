using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeManager.Domain.DTO.Fridge
{
    public class FridgeForCreationDto
    {
        [Required(ErrorMessage = "The name of the fridge is not specified")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string Name { get; set; }

        [MaxLength(30, ErrorMessage = "Maximum length for the OwnerName is 30 characters.")]
        public string OwnerName { get; set; }

        [Required(ErrorMessage = "The model of the fridge is not specified")]
        public Guid ModelId { get; set; }
    }
}
