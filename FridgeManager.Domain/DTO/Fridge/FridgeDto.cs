using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeManager.Domain.DTO.Fridge
{
    public class FridgeDto
    {
        public Guid Id { get; set; }
        public string OwnerName { get; set; }
        public string FullModelName { get; set; }
    }
}
