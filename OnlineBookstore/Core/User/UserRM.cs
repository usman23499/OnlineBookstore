namespace OnlineBookstore.Core.User
{
    public class UserRM
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Token { get;  set; }
        public List<string> Roles { get; set; }
    }
}
