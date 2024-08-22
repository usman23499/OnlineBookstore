namespace OnlineBookstore.DataAccess.User.DAO
{
    public class UserRoleDAO
    {
        public Guid UserId { get; set; }
        public virtual UserDAO User { get; set; }
        public Guid RoleId { get; set; }
        public virtual RoleDAO Role { get; set; }
    }
}
