using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Sql;

namespace CampingProjekt
{
    public class Dal
    {
        // ctor
        public Dal() { }

        public void TestCon()
        {

        }

        public SqlConnection NewCon()
        {
            SqlConnection newCon = new SqlConnection();

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(GetConString());

            newCon.ConnectionString = builder.ConnectionString;

            return newCon;
        }

        private static string GetConString()
        {
            return "Data Source=172.16.59.46;Initial Catalog=CampingDB;Persist Security Info=True;User ID=sa;Password=Password1234!";
        }
    }
}