using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStore.User.Core
{
    public interface ITokenHandler
    {
        public Task<string> CreateToker(UserRM user);
    }
}
