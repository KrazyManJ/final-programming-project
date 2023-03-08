namespace final_programming_project.obj_str;

public class User
{
    public User(int id, string name, Role role)
    {
        ID = id;
        Name = name;
        Role = role;
    }
    public int ID { get; }
    public string Name { get; }
    public Role Role { get; }
}