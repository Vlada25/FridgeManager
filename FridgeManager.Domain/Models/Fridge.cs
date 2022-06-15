using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeManager.Domain.Models
{
    public class Fridge : BaseEntity
    {
        public string Name { get; set; }
        public string OwnerName { get; set; }
        public Guid ModelId { get; set; }
        public FridgeModel Model { get; set; }
    }
}
