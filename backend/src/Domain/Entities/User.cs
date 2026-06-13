namespace AuthApi.Src.Domain.Entities
{
    sealed public class User
    {
        public Guid Id { private get; set; } = Guid.NewGuid();

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public string Login { get; private set; } = string.Empty;
        public string Phone { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public required string PasswordHash { private get; set; }

        public bool IsActive { get; private set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


        public void SetLogin(string login) { Login = login; }
        public void SetPhone(string phone) { Phone = phone; }
        public void SetEmail(string email) { Email = email; }
        public void Deactivate() { IsActive = false; }
    }
}