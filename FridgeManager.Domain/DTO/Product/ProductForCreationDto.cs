using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeManager.Domain.DTO.Product
{
    public class ProductForCreationDto
    {
        public string Name { get; set; }
        public int DefaultQuantity { get; set; }
        public string ImageSource { get; set; }
    }
}
