using System.Data.SqlClient;

namespace final_programming_project.Source
{
    public class SQLExecuter
    {

        public static string Quote(string sql)
        {
            return new SqlCommandBuilder().QuoteIdentifier(sql);
        }

        private static readonly string CONNECTION_STRING =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=final-programming-project-db;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        private readonly SqlConnection connection;
        private readonly SqlCommand command;

        public SQLExecuter(string command) { 
            connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();
            this.command = new SqlCommand(command, connection);
        }

        public SQLExecuter Parameter(string name, object value)
        {
            command.Parameters.AddWithValue(name,value);
            return this;
        }

        public void Execute()
        {
            command.ExecuteNonQuery();
            Close();
        }

        public List<T> ExecuteReadAll<T>(Func<SqlDataReader,T> func) {
            SqlDataReader reader = command.ExecuteReader();
            List<T> result = new List<T>();
            while (reader.Read()) result.Add(func(reader));
            reader.Close();
            Close();
            return result;
        }

        public T? ExecuteReadFirst<T>(Func<SqlDataReader,T> func)
        {
            SqlDataReader reader = command.ExecuteReader();
            T? val = default;
            if (reader.Read()) val = func(reader);
            reader.Close();
            Close();
            return val;
        }

        public bool ExecuteReadAny()
        {
            SqlDataReader reader = command.ExecuteReader();
            bool result = reader.Read();
            reader.Close();
            Close();
            return result;
        }

        public void Close() => connection.Close();

    }
}
