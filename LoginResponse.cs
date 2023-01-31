using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_programming_project
{
    public class LoginResponse
    {
        public User? User { get; }
        public LoginStatus Status { get; }
        public LoginResponse(User? user, LoginStatus status) { 
            User = user;
            Status = status;
        }
    }
    public enum LoginStatus
    {
        SUCCESS,
        PASSWORD_INCORRECT,
        USERNAME_NOT_EXIST
    }
}
