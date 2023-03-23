using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_programming_project.Source
{
    public class SQLBuilder
    {

        public static string Quote(string sql)
        {
            return new SqlCommandBuilder().QuoteIdentifier(sql);
        }

        public class SQLBuilderCommand
        {
            private readonly SqlCommand command;
            private readonly SQLBuilder builder;

            internal SQLBuilderCommand(SQLBuilder builder,string command) {
                this.builder = builder;
                this.command = new SqlCommand(command,builder.connection);
            }
            
            public SQLBuilderCommand Parameter(string name, object value)
            {
                command.Parameters.AddWithValue(name, value);
                return this;
            }

            public SQLBuilder Execute()
            {
                command.ExecuteNonQuery();
                return builder;
            }

            public SQLBuilder ExecuteReadAll(Action<SqlDataReader> lambda)
            {
                var reader = command.ExecuteReader();
                while (reader.Read()) lambda(reader);
                reader.Close();
                return builder;
            }
        }

        private static readonly string CONNECTION_STRING =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=final-programming-project-db;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        private readonly SqlConnection connection;

        public SQLBuilder() { 
            connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();
        }

        public void Close() => connection.Close();

        public SQLBuilderCommand Command(string command)
        {
            return new SQLBuilderCommand(this,command);
        }
    }
}
