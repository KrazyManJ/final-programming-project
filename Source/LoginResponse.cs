using final_programming_project.Objects;

namespace final_programming_project.Source;

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