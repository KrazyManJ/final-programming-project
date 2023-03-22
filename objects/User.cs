using final_programming_project.objects;
using final_programming_project.src;
using System.Data.SqlClient;

namespace final_programming_project.obj_str;

public class User : IListViewable
{
    public int ID { get; } = -1;
    public string Name { get; }
    public Role Role { get; }

    public User(string name, Role role)
    { 
        Name = name;
        Role = role;
    }

    public User(int iD, string name, Role role)
    {
        ID = iD;
        Name = name;
        Role = role;
    }

    public User(SqlDataReader reader)
    {
        ID = reader.GetInt32(0);
        Name = reader.GetString(1);
        Role = SQLManager.GetRoleByID(reader.GetInt32(4));
    }

    public ListViewItem ToListViewItem()
    {
        return new ListViewItem(new string[] { ID.ToString(), Name, Role.Name });
    }
}