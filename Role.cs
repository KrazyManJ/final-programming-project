namespace final_programming_project;

public class Role
{
    public Role(string name, bool full_perm)
    {
        Name = name;
        Full_Perm = full_perm;
    }

    public string Name { get; }
    public bool Full_Perm { get; }
}