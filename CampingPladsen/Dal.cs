using System.Data.SqlClient;

namespace CampingProjekt
{
    public class Dal
    {
        // ctor
        public Dal() { }

        /// <summary>
        /// Returns a connection to the database.
        /// </summary>
        /// <returns></returns>
        public SqlConnection NewConDal()
        {
            // Creates a new SqlConnection object
            SqlConnection newCon = new SqlConnection();

            // Creates a SqlConnectionStringBuilder object which gets its connectionstring from the GetConString method.
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(GetConString());

            // Gets the connectionstring from the SqlConnectionStringBuilder object, and copies it to the SqlConnection object
            newCon.ConnectionString = builder.ConnectionString;

            return newCon;
        }

        /// <summary>
        /// Generates the connectionstring needed to establish a connection to the database.
        /// </summary>
        /// <returns></returns>
        private static string GetConString()
        {
            // Returns a string with the information needed to make a connectionstring
            return "Data Source=172.16.59.46;Initial Catalog=CampingDB;Persist Security Info=True;User ID=sa;Password=Password1234!";
        }
    }
}