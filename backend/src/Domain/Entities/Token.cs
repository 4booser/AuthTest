namespace AuthTest.Src.Domain.Entities
{
    public class Token
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Hash { get; set; } = null!;
        public DateTime ExpiresAt { get; set; } 
    }
}