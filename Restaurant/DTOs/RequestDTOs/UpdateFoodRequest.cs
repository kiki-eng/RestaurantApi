namespace Restaurant.DTOs
{
    public class UpdateFoodRequest
    {
        public string Name { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public string Description { get; set; } = string.Empty;
    }
}
