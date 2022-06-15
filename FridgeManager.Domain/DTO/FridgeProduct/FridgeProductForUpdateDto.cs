using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeManager.Domain.DTO.FridgeProduct
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
