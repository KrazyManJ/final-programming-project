using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using final_programming_project.obj_str;

namespace final_programming_project.src;

public static class SQLManager
{

    private static readonly int DEFAULT_ROLE_ID = 1;
    private static readonly string DEFAULT_ROLE_NAME = "user";

    private static readonly string CONNECTION_STRING =
        @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=final-programming-project-db;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


    public static SqlConnection InitConnection()
    {
        SqlConnection conn = new SqlConnection(CONNECTION_STRING);
        conn.Open();
        return conn;
    }

    public static SqlCommand Command(SqlConnection connection, string commandText)
    {
        SqlCommand command = connection.CreateCommand();
        command.CommandText = commandText;
        return command;
    }

    public static bool IsUserRegistered(string username)
    {
        SqlConnection connection = InitConnection();
        SqlCommand command = Command(connection, "SELECT id FROM users WHERE name=@name");
        command.Parameters.AddWithValue("name", username);
        SqlDataReader reader = command.ExecuteReader();
        bool val = reader.Read();
        reader.Close();
        connection.Close();
        return val;
    }

    public static LoginResponse CheckLoginData(string username, string password)
    {
        SqlConnection connection = InitConnection();
        SqlCommand cmd = Command(connection, "SELECT id,passwordhash,passwordsalt,name,role FROM users WHERE name=@name");
        cmd.Parameters.AddWithValue("name", username);
        var reader = cmd.ExecuteReader();
        LoginResponse response = new(null, LoginStatus.USERNAME_NOT_EXIST);
        if (reader.Read())
        {
            HMACSHA512 hmac = new((byte[])reader[2]);
            response = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)).SequenceEqual((byte[])reader[1])
                ? new LoginResponse(new User(reader.GetInt32(0), reader.GetString(3), GetRoleByID(reader.GetInt32(4))), LoginStatus.SUCCESS)
                : new LoginResponse(null, LoginStatus.PASSWORD_INCORRECT);
        }

        reader.Close();
        connection.Close();
        return response;
    }

    public static Role GetRoleByID(int id)
    {
        SqlConnection connection = InitConnection();
        var cmd = Command(connection, "SELECT * FROM roles WHERE id=@id");
        cmd.Parameters.AddWithValue("id", id);
        Role role = new("User", false);
        var reader = cmd.ExecuteReader();
        if (reader.Read()) role = new Role(reader.GetString(1), reader.GetBoolean(2));
        reader.Close();
        connection.Close();
        return role;
    }
    public static int GetIdByRoleName(string roleName)
    {
        SqlConnection connection = InitConnection();
        var cmd = Command(connection, "SELECT id FROM roles WHERE name=@name");
        cmd.Parameters.AddWithValue("name", roleName);
        var reader = cmd.ExecuteReader();
        int val = DEFAULT_ROLE_ID;
        if (reader.Read()) val = reader.GetInt32(0);
        reader.Close();
        connection.Close();
        return val;
    }

    public static RegisterResponse RegisterUser(string username, string password, string? role)
    {
        role ??= DEFAULT_ROLE_NAME;
        if (IsUserRegistered(username)) return RegisterResponse.ALREADY_EXISTS;
        HMACSHA512 hmac = new();
        SqlConnection connection = InitConnection();
        var cmd = Command(connection, "INSERT INTO users (name,passwordhash,passwordsalt,role) VALUES (@name,@hash,@salt,@roleid)");
        cmd.Parameters.AddWithValue("name", username);
        cmd.Parameters.AddWithValue("hash", hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
        cmd.Parameters.AddWithValue("salt", hmac.Key);
        cmd.Parameters.AddWithValue("roleid", GetIdByRoleName(role));
        cmd.ExecuteNonQuery();
        connection.Close();
        return RegisterResponse.SUCCESS;
    }

    public static List<User> RegisteredUsers()
    {
        SqlConnection connection = InitConnection();
        var cmd = Command(connection, "SELECT * FROM users");
        SqlDataReader reader = cmd.ExecuteReader();
        List<User> users = new();
        while (reader.Read()) users.Add(new User(reader.GetInt32(0), reader.GetString(1), GetRoleByID(reader.GetInt32(4))));
        reader.Close();
        connection.Close();
        return users;
    }

    public static List<Role> RegisteredRoles()
    {
        SqlConnection connection = InitConnection();
        SqlCommand cmd = Command(connection, "SELECT * FROM roles");
        SqlDataReader reader = cmd.ExecuteReader();
        List<Role> roles = new();
        while (reader.Read()) roles.Add(new Role(reader.GetString(1), reader.GetBoolean(2)));
        return roles;
    }

}

public enum RegisterResponse
{
    SUCCESS,
    ALREADY_EXISTS
}