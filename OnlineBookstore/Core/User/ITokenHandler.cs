namespace OnlineBookstore.Core.User
{
    public interface ITokenHandler
    {
        public Task<string> CreateToker(UserRM user);
    }
}
