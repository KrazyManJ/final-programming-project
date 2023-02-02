using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_programming_project
{
    public class User
    {
        public string Name { get; }
        public Role Role { get; }
        public User(string name, Role role)
        {
            this.Name = name;
            Role = role;
        }
    }
}
