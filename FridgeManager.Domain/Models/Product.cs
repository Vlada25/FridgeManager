namespace FridgeManager.Domain.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int DefaultQuantity { get; set; }
        public string ImageSource { get; set; }
    }
}
