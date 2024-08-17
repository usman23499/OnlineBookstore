namespace OnlineBookstore.Core.User
{
    public class UserRole
    {
        public Guid UserId { get; private set; }
        public Guid RoleId { get; private set; }
        public string RoleName { get; private set; }

        private UserRole(Guid userId, Guid roleId, string roleName)
        {
            UserId = userId;
            RoleId = roleId;
            RoleName = roleName;
        }

        private UserRole(Guid userId, Guid roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }
        public static UserRole Create(Guid userId, Guid roleId, string roleName)
        {
            UserRole userRole = new (userId, roleId, roleName);
            return userRole;
        }

        public static UserRole Create(Guid userId, Guid roleId)
        {
            UserRole userRole = new (userId, roleId);
            return userRole;
        }
    }
}
