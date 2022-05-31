using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeManager.Domain.DTO.FridgeModel
{
    public class FridgeModelDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
    }
}
