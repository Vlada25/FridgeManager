namespace FridgeManager.Domain.Models
{
    public class FridgeProduct : BaseEntity
    {
        public Guid FridgeId { get; set; }
        public Fridge Fridge { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
