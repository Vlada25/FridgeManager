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
