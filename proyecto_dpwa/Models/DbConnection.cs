using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace proyecto_dpwa.Models
{
    public class DbConnection
    {
        public SqlConnection connection = new SqlConnection();
        public SqlCommand command = new SqlCommand();

        public DbConnection()
        {
            //this.connection.ConnectionString = @"Data Source=SUSERVIDOR; Initial Catalog=; Integrated Security=true";
            this.connection.ConnectionString = @"Data Source=DESKTOP-A07QJG6;Initial Catalog=proyecto_dpwa;Integrated Security=True";
            command.Connection = this.connection;
        }
    }
}