using System.ComponentModel.DataAnnotations;

namespace FridgeManager.Domain.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
