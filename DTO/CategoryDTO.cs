namespace FinalApi.DTO;

 public class UpdateShoppingItemDTO
    {
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public bool Purchased { get; set; }
        public string? CategoryId { get; set; }
    }

     public class CreateCategoryDTO
    {
        public string Name { get; set; } = string.Empty;
    }