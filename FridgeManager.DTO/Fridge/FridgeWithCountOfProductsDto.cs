using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeManager.DTO.Fridge
{
    public class FridgeWithCountOfProductsDto
    {
        public Guid Id { get; set; }
        public string FullModelName { get; set; }
        public int Year { get; set; }
        public int ProductsCount { get; set; }
    }
}
