namespace AtlasLMS.Shared.Responses;

public class AuthResponse
{
    public required string Token { get; set; }
    public DateTime Expiration { get; set; }
}
