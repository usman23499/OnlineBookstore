namespace OnlineBookstore.Core.User
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Token { get; private set; }
        public List<UserRole> _UserRoles { get; private set; }
        private User(Guid id, string name, string email, string password, string token)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            Token = token;
            _UserRoles = new List<UserRole>();
        }

        public static User Create(Guid id, string name, string email, string password, string token)
        {
            User user = new (id, name, email, password, token);
            return user;
        }
        public static User Create(string name, string email, string password, string token)
        {
            User user = new(Guid.NewGuid(), name, email, password, token);
            return user;
        }

        public void AddUserRole(Guid roleId)
        {
            UserRole userRole = UserRole.Create(Id, roleId);
            _UserRoles.Add(userRole);
        }

        public void AddUserRole(Guid roleId, string roleName)
        {
            UserRole userRole = UserRole.Create(Id, roleId, roleName);
            _UserRoles.Add(userRole);
        }
    }
}
