using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace final_programming_project;

public static class SQLManager
{
    private static readonly string connectionString =
        @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=final-programming-project-db;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

    public static LoginResponse CheckLoginData(string username, string password)
    {
        SqlConnection connection = new(connectionString);
        connection.Open();
        var cmd = connection.CreateCommand();
        cmd.CommandText = "SELECT id,passwordhash,passwordsalt,name,role FROM users WHERE name=@name";
        cmd.Parameters.AddWithValue("name", username);
        var reader = cmd.ExecuteReader();
        LoginResponse response = new(null, LoginStatus.USERNAME_NOT_EXIST);
        if (reader.Read())
        {
            HMACSHA512 hmac = new((byte[])reader[2]);
            response = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)).SequenceEqual((byte[])reader[1])
                ? new LoginResponse(new User(reader.GetInt32(0) ,reader.GetString(3), GetRoleByID(reader.GetInt32(4))), LoginStatus.SUCCESS)
                : new LoginResponse(null, LoginStatus.PASSWORD_INCORRECT);
        }

        reader.Close();
        connection.Close();
        return response;
    }

    public static Role GetRoleByID(int id)
    {
        SqlConnection connection = new(connectionString);
        connection.Open();
        var cmd = connection.CreateCommand();
        cmd.CommandText = "SELECT * FROM roles WHERE id=@id";
        cmd.Parameters.AddWithValue("id", id);
        Role role = new("User", false);
        var reader = cmd.ExecuteReader();
        if (reader.Read()) role = new Role(reader.GetString(1), reader.GetBoolean(2));
        reader.Close();
        connection.Close();
        return role;
    }

    public static void RegisterUser(string username, string password)
    {
        HMACSHA512 hmac = new();
        SqlConnection sqlConnection = new(connectionString);
        sqlConnection.Open();
        var cmd = sqlConnection.CreateCommand();
        cmd.CommandText = "INSERT INTO users (name,passwordhash,passwordsalt) VALUES (@name,@hash,@salt)";
        cmd.Parameters.AddWithValue("name", username);
        cmd.Parameters.AddWithValue("hash", hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
        cmd.Parameters.AddWithValue("salt", hmac.Key);
        cmd.ExecuteNonQuery();
        sqlConnection.Close();
    }

    public static List<User> RegisteredUsers()
    {
        SqlConnection sqlConnection = new(connectionString);
        sqlConnection.Open();
        var cmd = sqlConnection.CreateCommand();
        cmd.CommandText = "SELECT * FROM users";
        SqlDataReader reader = cmd.ExecuteReader();
        List<User> users = new();
        while (reader.Read())
        {
            Role role = GetRoleByID(reader.GetInt32(4));
            users.Add(new User(reader.GetInt32(0),reader.GetString(1), role));
        }
        reader.Close();
        sqlConnection.Close();
        return users;
    }
}