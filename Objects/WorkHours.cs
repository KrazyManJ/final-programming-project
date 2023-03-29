using final_programming_project.Source;
using System.Data.SqlClient;

namespace final_programming_project.Objects
{
    public class WorkHours : IListViewable, ISQLSerializable
    {
        public int ID { get; set; }
        public Employee Employee { get; set; }
        public Contract Contract { get; set; }
        public WorkType WorkType { get; set; }
        public int Hours { get; set; }
        public DateTime InsertDate { get; set; }
        public User InsertUser { get; set; }

        public WorkHours(Employee employee, Contract contract, WorkType workType, int hours, User insertUser)
        {
            Employee = employee;
            Contract = contract;
            WorkType = workType;
            Hours = hours;
            InsertDate = DateTime.Now;
            InsertUser = insertUser;
        }

        public WorkHours(SqlDataReader reader)
        {
            ID = reader.GetInt32(0);
            Employee = SQLManager.SelectById<Employee>(TableName.employees,reader.GetInt32(1));
            Contract = SQLManager.SelectById<Contract>(TableName.contracts,reader.GetInt32(2));
            WorkType = SQLManager.SelectById<WorkType>(TableName.worktypes, reader.GetInt32(3));
            Hours = reader.GetInt32(4);
            InsertDate = reader.GetDateTime(5);
            InsertUser = SQLManager.SelectById<User>(TableName.users, reader.GetInt32(6));
        }

        public ListViewItem ToListViewItem()
        {
            return new ListViewItem(new string[] {
                ID.ToString(),
                InsertDate.ToString("yyyy-MM-dd"),
                $"{Employee.FirstName} {Employee.LastName}",
                Hours.ToString(),
                WorkType.Name,
                WorkType.Description
            });
        }

        public Dictionary<string, object> ToSQLParams()
        {
            return new Dictionary<string, object>()
            {
                { "id", ID },
                { "employee", Employee.ID },
                { "contract", Contract.ID },
                { "worktype", WorkType.ID },
                { "hours", Hours },
                { "insertdate", InsertDate },
                { "insertuser", InsertUser.ID }
            };
        }
    }
}
