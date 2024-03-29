﻿using final_programming_project.Source;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_programming_project.Objects
{
    public class Contract : IListViewable, ISQLNameDescObject<Contract>
    {
        public int ID { get; set; }
        public string Customer { get; set; }
        public string Description { get; set; }

        public string Name { get { return Customer; } set { Customer = value; } }

        public Contract(string customer, string description)
        {
            Customer = customer;
            Description = description;
        }

        public Contract(SqlDataReader reader)
        {
            ID = reader.GetInt32(0);
            Customer = reader.GetString(1);
            Description = reader.GetString(2);
        }

        public ListViewItem ToListViewItem()
        {
            return new ListViewItem(new string[] { ID.ToString(), Customer, Description });
        }

        public Dictionary<string, object> ToSQLParams()
        {
            return new Dictionary<string, object>() { { "customer", Customer }, { "description", Description } };
        }
    }
}
