using System.Data.SqlClient;

namespace final_programming_project.Objects;

public class Role
{
    public Role(string name, bool full_perm)
    {
        Name = name;
        Full_Perm = full_perm;
    }

    public Role(SqlDataReader reader)
    {
        ID = reader.GetInt32(0);
        Name = reader.GetString(1);
        Full_Perm = reader.GetBoolean(2);
    }

    public int ID { get; } = 1;
    public string Name { get; }
    public bool Full_Perm { get; }
}