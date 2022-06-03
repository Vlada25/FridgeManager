using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeManager.Domain.DTO.FridgeProduct
{
    public class FridgeProductTotalDto
    {
        public string Fridge { get; set; }
        public string Product { get; set; }
        public int TotalQuantity { get; set; }
    }
}
