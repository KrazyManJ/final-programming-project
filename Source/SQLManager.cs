﻿using System.Data.SqlClient;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using final_programming_project.Objects;

namespace final_programming_project.Source;

public static class SQLManager
{
    
    // UTILS

    public static string Quote(string sql) => new SqlCommandBuilder().QuoteIdentifier(sql);
    
    private static ConstructorInfo? GetSQLCtor<T>() => typeof(T).GetConstructor(new Type[] { typeof(SqlDataReader) });

    // GENERIC METHODS

    public static List<T> SelectAll<T>(TableName name)
    {
        ConstructorInfo? constructor = GetSQLCtor<T>();
        if (constructor == null) return new List<T>();
        return new SQLExecuter("SELECT * FROM " + Quote(name.ToString()))
            .ExecuteReadAll(r => (T)constructor.Invoke(new object[] { r }));
    }

    public static void Insert<T>(TableName name, T value) where T : ISQLSerializable
    {
        Dictionary<string,object> paramsdict = value.ToSQLParams();
        paramsdict.Remove("id");
        string columnnames = string.Join(',', paramsdict.Keys);
        string paramnames = string.Join(',', paramsdict.Keys. Select(k => '@' + k));
        new SQLExecuter($"INSERT INTO {Quote(name.ToString())} ({columnnames}) VALUES ({paramnames})")
            .Parameters(paramsdict)
            .Execute();
    }

    public static void Update<T>(TableName name, int id, T value) where T : ISQLSerializable
    {
        Dictionary<string, object> paramsdict = value.ToSQLParams();
        paramsdict.Remove("id");
        string updateString = string.Join(",", paramsdict.Keys.Select(k => $"{k}=@{k}"));
        new SQLExecuter($"UPDATE {Quote(name.ToString())} SET {updateString} WHERE id=@id")
            .Parameters(paramsdict)
            .Parameter("id",id)
            .Execute();
    }

    public static void RemoveById(TableName name, int id)
    {
        new SQLExecuter($"DELETE FROM {Quote(name.ToString())} WHERE id=@id").Parameter("id", id).Execute();
    }

    public static T? SelectById<T>(TableName name, int id)
    {
        ConstructorInfo? constructor = GetSQLCtor<T>();
        if (constructor == null) return default;
        return new SQLExecuter($"SELECT * FROM {Quote(name.ToString())} WHERE id=@id")
            .Parameter("id", id)
            .ExecuteReadFirst(r => (T)constructor.Invoke(new object[] { r }));
    }

    public static T? SelectByName<T>(TableName tableName, string name)
    {
        ConstructorInfo? constructor = GetSQLCtor<T>();
        if (constructor == null) return default;
        return new SQLExecuter("SELECT * FROM " + Quote(tableName.ToString()) + " WHERE name=@name")
            .Parameter("name",name)
            .ExecuteReadFirst(r => (T)constructor.Invoke(new object[] { r }));
    }

    // USERS

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

    public static RegisterResponse RegisterUser(string username, string password, string? role)
    {
        role ??= Role.DEFAULT.Name;
        if (IsUserRegistered(username)) return RegisterResponse.ALREADY_EXISTS;
        var hash = new PasswordHash(password);
        new SQLExecuter("INSERT INTO users (name,passwordhash,passwordsalt,role) VALUES (@name,@hash,@salt,@roleid)")
            .Parameter("name", username)
            .Parameter("hash", hash.Hash)
            .Parameter("salt", hash.Salt)
            .Parameter("roleid", (SelectByName<Role>(TableName.roles,role) ?? Role.DEFAULT).ID)
            .Execute();
        return RegisterResponse.SUCCESS;
    }

    public static void EditUser(int id, string name, string role, string? password = null)
    {
        new SQLExecuter("UPDATE users SET name=@name,role=@role WHERE id=@id")
            .Parameter("name",name).Parameter("role", (SelectByName<Role>(TableName.roles, role) ?? Role.DEFAULT).ID).Parameter("id",id)
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

    //CONTRACTS

    public static List<WorkHours> GetWorkHours(Contract contract)
    {
        ConstructorInfo? constructor = GetSQLCtor<WorkHours>();
        if (constructor == null) return new List<WorkHours>();
        return new SQLExecuter("SELECT * FROM workhours WHERE contract=@contract")
            .Parameter("contract", contract.ID)
            .ExecuteReadAll(r => (WorkHours)constructor.Invoke(new object[] { r }));
    }
    
    public static bool IsInWorkHours(WorkHoursIndexes columnname, ISQLIndexable indexable)
    {
        return new SQLExecuter($"SELECT * FROM workhours WHERE {Quote(columnname.ToString())}=@id")
            .Parameter("id", indexable.ID)
            .ExecuteReadAny();
    }

    public static void RemoveContract(Contract contract)
    {
        new SQLExecuter("DELETE FROM workhours WHERE contract=@id;DELETE FROM contracts WHERE id=@id")
            .Parameter("id", contract.ID)
            .Execute();
    }

}

public enum WorkHoursIndexes
{
    employee,
    contract,
    worktype,
    insertuser
}

public enum TableName
{
    users,
    roles,
    contracts,
    employees,
    worktypes,
    workhours
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