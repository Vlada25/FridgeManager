﻿using System.ComponentModel.DataAnnotations;

namespace FridgeManager.DTO.FridgeModel
{
    public class FridgeModelForUpdateDto
    {
        [Required(ErrorMessage = "Id is not specified")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The name of the model is not specified")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The year of the model is not specified")]
        public int Year { get; set; }
    }
}
