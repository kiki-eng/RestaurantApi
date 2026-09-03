namespace Restaurant.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Passwordhash { get; set; }
        public ICollection<Food> Foods { get; set; } = new List<Food>();
    }
}
