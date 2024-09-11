using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStore.User.Core
{
    public class Role
    {
        private Role(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public static Role Create(Guid id, string name)
        {
            Role role = new (id, name);
            return role;
        }
        public static Role Create(string name)
        {
            validate(name);
            Role role = new(Guid.NewGuid(), name);
            return role;
        }

        private static void validate(string name)
        {
            if(name== null)
            {
                throw new ArgumentNullException("name");
            }
        }
    }
}
