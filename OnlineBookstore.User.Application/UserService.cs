using OnlineBookstore.User.Application.Dto;
using OnlineBookStore.User.Core;
using System;
using System.Threading.Tasks;

namespace OnlineBookstore.User.Application
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenHandler _tokenHandler;

        public UserService(IUserRepository userRepository, ITokenHandler tokenHandler)
        {
            _userRepository = userRepository;
            _tokenHandler = tokenHandler;
        }
        public async Task<RoleRM> AddRole(string roleName)
        {
            Role role = Role.Create(roleName);
            Role CheckRole = await _userRepository.GetRoleByName(roleName);
            if (CheckRole != null)
            {
                throw new ArgumentNullException("Role Already Exsist");
            }
            return await _userRepository.AddRole(role);
        }

        public async Task<UserRM> Login(string username, string password)
        {
            UserRM userRm = await _userRepository.Login(username, password);
            if(userRm == null)
            {
                throw new ArgumentNullException("No User Exsist");
            }
            userRm.Token = await _tokenHandler.CreateToker(userRm); 
            
            return userRm;
        }

        public async Task<OnlineBookStore.User.Core.User> Register(UserDTO user)
        {
            OnlineBookStore.User.Core.User newUser = OnlineBookStore.User.Core.User.Create(
                user.Name,
                user.Email,
                user.Password
                );

            OnlineBookStore.User.Core.User CheckUser = await _userRepository.GetUserByEmail(user.Email);
            
            if(CheckUser != null)
                throw new ArgumentNullException("User Already Exsist");
            if (user.UserRoleName == null)
                throw new ArgumentNullException("Invalid Role");

            foreach (string roleName in user.UserRoleName)
            {
                Role CheckRole = await _userRepository.GetRoleByName(roleName);
                if (CheckRole == null)
                    throw new ArgumentNullException("Invalid Role");
                newUser.AddUserRole(CheckRole.Id);   
            }

            await _userRepository.Register(newUser);
            return newUser;
        }
    }
}
