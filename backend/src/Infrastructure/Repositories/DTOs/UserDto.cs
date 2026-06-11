namespace AuthTest.Src.Infrastructure.Repositories.DTOs
{
    public record UserDto(
        Guid id,
        string first_name,
        string last_name,
        string login,
        string phone,
        string email,
        string password_hash,
        DateTime created_at,
        bool is_active
    ) {}
}