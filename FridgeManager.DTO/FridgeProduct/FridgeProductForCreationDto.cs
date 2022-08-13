﻿using System.ComponentModel.DataAnnotations;

namespace FridgeManager.DTO.FridgeProduct
{
    public class FridgeProductForCreationDto
    {
        [Required(ErrorMessage = "The fridge is not specified")]
        public Guid FridgeId { get; set; }

        [Required(ErrorMessage = "The product is not specified")]
        public Guid ProductId { get; set; }

        [Required(ErrorMessage = "The quantity of the product is not specified")]
        [Range(0, 300, ErrorMessage = "Too much products")]
        public int Quantity { get; set; }
    }
}
