namespace AuthTest.Src.Application.Features.Auth.Services.Interfaces
{
    public interface IHasher
    {
        public string Hash(string credentials);
    }
}
