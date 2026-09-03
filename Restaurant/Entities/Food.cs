namespace Restaurant.Entities
{
    public class Food
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;

        
        public DateTime CreatedAt { get; set; }

        public Guid CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; } = null!;

        public DateTime? UpdatedAt { get; set; }

        public Guid? UpdatedByUserId { get; set; }
        public User? UpdatedByUser { get; set; }

       
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }

        public Guid? DeletedByUserId { get; set; }
        public User? DeletedByUser { get; set; }
    }
}
