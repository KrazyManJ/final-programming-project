using System.Data.SqlClient;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using final_programming_project.Objects;

namespace final_programming_project.Source;

public static class SQLManager
{
    private static readonly string DEFAULT_ROLE_NAME = "user";

    public static bool IsUserRegistered(string username)
    {
        return new SQLExecuter("SELECT id FROM users WHERE name=@username")
            .Parameter("username", username)
            .ExecuteReadAny();
    }

    public static LoginResponse CheckLoginData(string username, string password)
    {
        return new SQLExecuter("SELECT * FROM users WHERE name=@username")
            .Parameter("username", username)
            .ExecuteReadFirst(r =>
            {
                var pass = new PasswordHash(password, (byte[])r[3]);
                return pass.Hash.SequenceEqual((byte[])r[2])
                    ? new LoginResponse(new User(r), LoginStatus.SUCCESS)
                    : new LoginResponse(null, LoginStatus.PASSWORD_INCORRECT);
            }) ?? new(null, LoginStatus.USERNAME_NOT_EXIST);
    }

    public static Role GetRoleByID(int id)
    {
        return new SQLExecuter("SELECT * FROM roles WHERE id=@id")
            .Parameter("id", id)
            .ExecuteReadFirst(r => new Role(r)) ?? new Role("user",false);
    }

    public static int GetIdByRoleName(string roleName)
    {
        return new SQLExecuter("SELECT id FROM roles WHERE name=@name")
            .Parameter("name", roleName)
            .ExecuteReadFirst(r => r.GetInt32(0));
    }

    public static Role GetRoleByName(string roleName)
    {
        return GetRoleByID(GetIdByRoleName(roleName));
    }

    public static RegisterResponse RegisterUser(string username, string password, string? role)
    {
        role ??= DEFAULT_ROLE_NAME;
        if (IsUserRegistered(username)) return RegisterResponse.ALREADY_EXISTS;
        var hash = new PasswordHash(password);
        new SQLExecuter("INSERT INTO users (name,passwordhash,passwordsalt,role) VALUES (@name,@hash,@salt,@roleid)")
            .Parameter("name", username)
            .Parameter("hash", hash.Hash)
            .Parameter("salt", hash.Salt)
            .Parameter("roleid", GetIdByRoleName(role))
            .Execute();
        return RegisterResponse.SUCCESS;
    }

    public static void EditUser(int id, string name, string role, string? password = null)
    {
        new SQLExecuter("UPDATE users SET name=@name,role=@role WHERE id=@id")
            .Parameter("name",name).Parameter("role",role).Parameter("id",id)
            .Execute();
        if (password != null)
        {
            var hash = new PasswordHash(password);
            new SQLExecuter("UPDATE users SET passwordhash=@hash,passwordsalt=@salt WHERE id=@id")
                .Parameter("hash",hash.Hash)
                .Parameter("salt",hash.Salt)
                .Execute();
        }
    }

    public static List<T> GetAll<T>(string tableName)
    {
        ConstructorInfo? constructor = typeof(T).GetConstructor(new Type[] { typeof(SqlDataReader) });
        if (constructor == null) return new List<T>();
        return new SQLExecuter("SELECT * FROM "+SQLExecuter.Quote(tableName))
            .ExecuteReadAll(r =>(T)constructor.Invoke(new object[] { r }));
    }

    public static void RemoveUserByID(int id)
    {
        new SQLExecuter("DELETE FROM users WHERE id=@id").Parameter("id", id).Execute();
    }
}

public enum RegisterResponse
{
    SUCCESS,
    ALREADY_EXISTS
}

internal class PasswordHash
{
    public PasswordHash(string password, byte[]? salt = null)
    {
        HMACSHA512 hmac = new();
        if (salt != null) hmac.Key = salt;
        Hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        Salt = hmac.Key;
    }

    public byte[] Hash { get; set; }
    public byte[] Salt { get; set; }
}