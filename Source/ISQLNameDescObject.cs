using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace final_programming_project.Source
{
    public interface ISQLNameDescObject<T> : ISQLSerializable
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public static T? Construct(string name, string description)
        {
            ConstructorInfo? ctor = typeof(T).GetConstructor(new Type[] { typeof(string), typeof(string) });
            if (ctor == null) return default;
            return (T)ctor.Invoke(new object[] { name, description });
        }
    }
}
