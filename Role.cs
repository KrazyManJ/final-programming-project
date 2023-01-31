using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_programming_project
{
    public class Role
    {
        public string Name { get; }
        public bool Full_Perm { get; } = false;

        public Role(string name, bool full_perm) { 
            this.Name = name;
            this.Full_Perm = full_perm;
        }
    }
}
