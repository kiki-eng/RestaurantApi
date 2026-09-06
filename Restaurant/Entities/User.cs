namespace Restaurant.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Passwordhash { get; set; } = string.Empty;
        public ICollection<Food> Foods { get; set; } = new List<Food>();
    }
}
