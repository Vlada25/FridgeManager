using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeManager.Domain.DTO.FridgeProduct
{
    public class FridgeProductForCreationDto
    {
        public Guid Id { get; set; }
        public Guid FridgeId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
