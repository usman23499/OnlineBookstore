using OnlineBookStore.User.DataAccess.DAO;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineBookStore.User.Core;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace OnlineBookStore.User.DataAccess
{
    public class UserRepository: IUserRepository
    {
        private readonly UserDBContext _context;
        private readonly IMapper _mapper;
        public UserRepository(UserDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UserRM> Login(string email, string password)
        {
            UserDAO user = await _context
                .Users
                .Include(x => x.UserRoles)
                .FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
            if (user == null)
                return null;

            List<UserRoleDAO> userRoles = await _context.UserRoles.Where(x => x.UserId == user.Id).ToListAsync();

            List<string> roles = new List<string>();
            foreach (UserRoleDAO role in userRoles)
            {
                RoleDAO roleDAO = await _context.Roles.FirstOrDefaultAsync(x => x.Id == role.RoleId);
                roles.Add(roleDAO.Name);
            }

            return new UserRM()
            {
                Email = email,
                Name = user.Name,
                Roles = roles,
            };
        }

        public async Task<Core.User> Register(Core.User user)
        {
            UserDAO userDAO = _mapper.Map<UserDAO>(user);
            userDAO.UserRoles = _mapper.Map<List<UserRoleDAO>>(user._UserRoles);
            await _context.Users.AddAsync(userDAO);
            await _context.SaveChangesAsync();

            return user;
        }
        public async Task<RoleRM> AddRole(Role role)
        {
            RoleDAO roleDAO = _mapper.Map<RoleDAO>(role);
            await _context.Roles.AddAsync(roleDAO);
            await _context.SaveChangesAsync();

            return new RoleRM()
            {
                Id = role.Id,
                Name = role.Name,
            };
        }
        public async Task<UserRole> AssignRole(UserRole role)
        {
            UserRoleDAO userRoleDAO = _mapper.Map<UserRoleDAO>(role);
            await _context.UserRoles.AddAsync(userRoleDAO);
            await _context.SaveChangesAsync();

            return role;
        }

        public async Task<Role> GetRoleByName(string roleName)
        {
            RoleDAO roleDAO = await _context
                .Roles
                .FirstOrDefaultAsync(x => x.Name == roleName);

            if (roleDAO == null)
                return null;
            return Role.Create(roleDAO.Id, roleDAO.Name);
        }

        public async Task<Core.User> GetUserByEmail(string email)
        {
            UserDAO userDAO = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
            if (userDAO == null)
                return null;

            return Core.User
                .Create(userDAO.Id,
                userDAO.Name,
                userDAO.Email,
                userDAO.Password
                );
        }
    }
}
