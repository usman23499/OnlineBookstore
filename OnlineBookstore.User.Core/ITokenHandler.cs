using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookstore.User.Core
{
    public interface ITokenHandler
    {
        public Task<string> CreateToker(UserRM user);
    }
}
