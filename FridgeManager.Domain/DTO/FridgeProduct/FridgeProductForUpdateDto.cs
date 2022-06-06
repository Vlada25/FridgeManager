using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeManager.Domain.DTO.FridgeProduct
{
    public class FridgeProductForUpdateDto
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
    }
}
