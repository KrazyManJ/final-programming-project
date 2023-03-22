namespace final_programming_project.obj_str;

public class LoginResponse
{
    public LoginResponse(User? user, LoginStatus status)
    {
        User = user;
        Status = status;
    }

    public User? User { get; }
    public LoginStatus Status { get; }
}

public enum LoginStatus
{
    SUCCESS,
    PASSWORD_INCORRECT,
    USERNAME_NOT_EXIST
}