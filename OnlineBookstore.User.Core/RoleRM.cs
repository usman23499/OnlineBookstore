using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStore.User.Core
{
    public class RoleRM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
