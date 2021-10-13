using System.Data.SqlClient;

namespace CampingProjekt
{
    public class Dal
    {
        // ctor
        public Dal() { }

        public SqlConnection NewConDal()
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