using System.Data.SqlClient;
using final_programming_project.Source;

namespace final_programming_project.Objects;

public class User : IListViewable, ISQLIndexable
{
    public int ID { get; set; }
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
        Role = SQLManager.SelectById<Role>(TableName.roles,reader.GetInt32(4)) ?? Role.DEFAULT;
    }

    public ListViewItem ToListViewItem()
    {
        return new ListViewItem(new[] { ID.ToString(), Name, Role.Name });
    }
}