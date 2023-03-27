using final_programming_project.Source;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_programming_project.Objects
{
    public class WorkType : IListViewable, ISQLNameDescObject<WorkType>
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public WorkType(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public WorkType(SqlDataReader reader) 
        { 
            ID = reader.GetInt32(0);
            Name = reader.GetString(1);
            Description = reader.GetString(2);
        }

        public ListViewItem ToListViewItem()
        {
            return new ListViewItem(new string[] { ID.ToString(), Name, Description });
        }

        public Dictionary<string, object> ToSQLParams()
        {
            return new Dictionary<string, object>()
            {
                {"id", ID.ToString()},
                {"name", Name},
                {"description", Description}
            };
        }
    }
}
