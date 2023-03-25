using final_programming_project.Source;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_programming_project.Objects
{
    public class Employee : IListViewable, ISQLSerializable
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Employee(int iD, string firstName, string lastName, DateTime birthDate, string email, string phoneNumber)
        {
            ID = iD;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public Employee(SqlDataReader reader)
        {
            ID = reader.GetInt32(0);
            FirstName = reader.GetString(1);
            LastName = reader.GetString(2);
            BirthDate = reader.GetDateTime(3);
            Email = reader.GetString(4);
            PhoneNumber = reader.GetString(5);
        }

        public ListViewItem ToListViewItem()
        {
            return new ListViewItem(new string[] { ID.ToString(), FirstName, LastName, BirthDate.ToShortDateString(), Email, PhoneNumber });
        }

        public string Query(string tablename)
        {
            return $"INSERT INTO {tablename} (firstname,lastname,birthdate,email,phonenumber) VALUES (@firstname,@lastname,@birthdate,@email,@phonenumber)";
        }

        public Dictionary<string, object> ToSQLParams()
        {
            return new Dictionary<string, object>() {
                { "firstname", FirstName },
                { "lastname", LastName },
                { "birthdate", BirthDate },
                { "email", Email },
                { "phonenumber", PhoneNumber }
            };
        }
    }
}
