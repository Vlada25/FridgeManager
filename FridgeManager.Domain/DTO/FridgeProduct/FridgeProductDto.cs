using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeManager.Domain.DTO.FridgeProduct
{
    public class FridgeProductDto
    {
        public Guid Id { get; set; }
        public string Fridge { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
    }
}
