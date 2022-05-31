using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeManager.Domain.DTO.Fridge
{
    public class FridgeForUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string OwnerName { get; set; }
        public Guid ModelId { get; set; }
    }
}
