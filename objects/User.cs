namespace final_programming_project.obj_str;

public class User
{
    public int ID { get; }
    public string Name { get; }
    public Role Role { get; }

    public User(int iD, string name, Role role)
    {
        ID = iD;
        Name = name;
        Role = role;
    }
}