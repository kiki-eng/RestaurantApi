namespace Restaurant.DTOs.ResponseDTOs
{
    public class RegisterUserResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;
    }
}
