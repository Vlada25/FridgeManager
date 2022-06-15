using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeManager.Domain.Models
{
    public class FridgeModel : BaseEntity
    {
        public string Name { get; set; }
        public int Year { get; set; }
    }
}
