using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace final_programming_project
{
    public static class SQLManager
    {
        private static readonly string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=final-programming-project-db;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    
        public static LoginResponse CheckLoginData(string username, string password)
        {
            SqlConnection connection = new(connectionString);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT passwordhash,passwordsalt FROM users WHERE name=@name";
            cmd.Parameters.AddWithValue("name", username);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                HMACSHA512 hmac = new((byte[])reader[1]);
                return hmac.ComputeHash(Encoding.UTF8.GetBytes(password)).SequenceEqual((byte[])reader[0])
                    ? LoginResponse.SUCCESS : LoginResponse.PASSWORD_INCORRECT;
            }
            else return LoginResponse.USERNAME_NOT_EXIST;
        }
        
        public static void RegisterUser(string username, string password)
        {
            HMACSHA512 hmac = new();
            SqlConnection sqlConnection = new(connectionString);
            sqlConnection.Open();
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = "INSERT INTO users (name,passwordhash,passwordsalt) VALUES (@name,@hash,@salt)";
            cmd.Parameters.AddWithValue("name", username);
            cmd.Parameters.AddWithValue("hash", hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
            cmd.Parameters.AddWithValue("salt", hmac.Key);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
    public enum LoginResponse
    {
        SUCCESS,
        PASSWORD_INCORRECT,
        USERNAME_NOT_EXIST
    }
}
