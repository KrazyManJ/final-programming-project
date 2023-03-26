using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_programming_project.Source
{
    public interface ISQLSerializable
    {
        public int ID { get; set; }
        public Dictionary<string,object> ToSQLParams();
    }
}
