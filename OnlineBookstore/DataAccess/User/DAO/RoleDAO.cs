namespace OnlineBookstore.DataAccess.User.DAO
{
    public class RoleDAO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<UserRoleDAO> UserRoles { get; set; }
    }
}
