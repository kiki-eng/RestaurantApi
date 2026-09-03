namespace Restaurant.DTOs.ResponseDTOs
{
    public class LoginUserResponse
    {
        public string Token { get; set; } = string.Empty;

        public DateTime ExpiresAt { get; set; }
    }
}
