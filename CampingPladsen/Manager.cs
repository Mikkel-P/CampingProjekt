using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CampingProjekt
{
    public class Manager
    {
        public Manager() { }

        Dal dal = new Dal();

        Calculation calc = new Calculation();

        SqlConnection newCon = new SqlConnection();

        public DataTable dataTable = new DataTable();

        /// <summary>
        /// Calls on the dal method to open a connection to the database.
        /// </summary>
        /// <returns></returns>
        public SqlConnection NewConMan()
        {
            return dal.NewConDal();
        }

        /// <summary>
        /// Submits the date input to the database.
        /// </summary>
        /// <param name="aDate"></param>
        /// <param name="eDate"></param>
        public void DateSubmit(string aDate, string eDate)
        {
            newCon = NewConMan();
            newCon.Open();

            SqlCommand insertArrival = new SqlCommand("StoredProcedure", newCon);
            SqlCommand insertExit = new SqlCommand("StoredProcedure", newCon);

            insertArrival.Parameters.AddWithValue("@Calendar1", aDate);
            insertExit.Parameters.AddWithValue("@Calendar2", eDate);

            insertArrival.ExecuteNonQuery();
            insertExit.ExecuteNonQuery();

            newCon.Close();
        }

        /// <summary>
        /// Gets the reservation_id associated with the date submission.
        /// </summary>
        public void GetRsvID()
        {
            newCon = NewConMan();
            newCon.Open();

            string query = "SELECT * FROM RsvID-View";

            SqlCommand getRsvID = new SqlCommand(query, newCon);

            SqlDataAdapter dataAdapt = new SqlDataAdapter(getRsvID);

            dataAdapt.Fill(dataTable);

            dataAdapt.Dispose();

            newCon.Close();
        }

        /// <summary>
        /// Inserts the reservation_id into a table which we can extract the value from.
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public string GetTableData(DataTable table)
        {
            string data = string.Empty;

            StringBuilder holder = new StringBuilder();

            // Commences if the table exists and has atleast 1 row in it
            if (null != table && null != table.Rows)
            {
                // Loops through the rows belonging to the given table
                foreach (DataRow dataRow in table.Rows)
                {
                    // Gets and sets all of the values in the datatable to an array
                    foreach (var item in dataRow.ItemArray)
                    {
                        // Adds values to the array, seperates each value by a comma
                        holder.Append(item);
                        holder.Append(',');
                    }
                    // Terminates the append operation
                    holder.AppendLine();
                }
                // Converts the array to a string
                data = holder.ToString();
            }
            return data;
        }

        #region Stored Procedure Methods
        // Could easily be optimized with an array
        /// <summary>
        /// Sends the amount user input to the database.
        /// </summary>
        /// <param name="antalV"></param>
        /// <param name="antalB"></param>
        /// <param name="antalH"></param>
        /// <param name="antalCPS"></param>
        /// <param name="antalCPL"></param>
        /// <param name="antalT"></param>
        /// <param name="antalLH"></param>
        /// <param name="antalSH"></param>
        /// <param name="antalSF"></param>
        /// <param name="antalSS"></param>
        /// <param name="antalSE"></param>
        /// <param name="antalSV"></param>
        /// <param name="badeBilletV"></param>
        /// <param name="badeBilletB"></param>
        /// <param name="cykelL"></param>
        /// <param name="ren"></param>
        /// <param name="sengeL"></param>
        public void InputSubmit
            (int antalV, int antalB, int antalH, int antalCPS, int antalCPL, int antalT, int antalLH, int antalSH, int antalSF,
            int antalSS, int antalSE, int antalSV, int badeBilletV, int badeBilletB, int cykelL, int ren, int sengeL)
        {
            newCon = NewConMan();
            newCon.Open();

            string temp = GetTableData(dataTable);

            int rsvID = Convert.ToInt32(temp);

            SqlCommand insertRsvID = new SqlCommand("InputInsertion", newCon);
            insertRsvID.Parameters.AddWithValue("@RsvID", rsvID);

            SqlCommand insertAntalV = new SqlCommand("InputInsertion", newCon);
            insertAntalV.Parameters.AddWithValue("@VoksenInput", antalV);
            insertAntalV.ExecuteNonQuery();

            SqlCommand insertAntalB = new SqlCommand("InputInsertion", newCon);
            insertAntalB.Parameters.AddWithValue("@BarnInput", antalB);
            insertAntalB.ExecuteNonQuery();

            SqlCommand insertAntalH = new SqlCommand("InputInsertion", newCon);
            insertAntalH.Parameters.AddWithValue("@HundeInput", antalH);
            insertAntalH.ExecuteNonQuery();

            SqlCommand insertCPS = new SqlCommand("InputInsertion", newCon);
            insertCPS.Parameters.AddWithValue("@StorCpInput", antalCPS);
            insertCPS.ExecuteNonQuery();

            SqlCommand insertCPL = new SqlCommand("InputInsertion", newCon);
            insertCPL.Parameters.AddWithValue("@LilleCpInput", antalCPL);
            insertCPL.ExecuteNonQuery();

            SqlCommand insertT = new SqlCommand("InputInsertion", newCon);
            insertT.Parameters.AddWithValue("@TeltInput", antalT);
            insertT.ExecuteNonQuery();

            SqlCommand insertLH = new SqlCommand("InputInsertion", newCon);
            insertLH.Parameters.AddWithValue("@LukHytInput", antalLH);
            insertLH.ExecuteNonQuery();

            SqlCommand insertSH = new SqlCommand("InputInsertion", newCon);
            insertSH.Parameters.AddWithValue("@StandHytInput", antalSH);
            insertSH.ExecuteNonQuery();

            SqlCommand insertSF = new SqlCommand("InputInsertion", newCon);
            insertSF.Parameters.AddWithValue("@ForInput", antalSF);
            insertSF.ExecuteNonQuery();

            SqlCommand insertSS = new SqlCommand("InputInsertion", newCon);
            insertSS.Parameters.AddWithValue("@SommerInput", antalSS);
            insertSS.ExecuteNonQuery();

            SqlCommand insertSE = new SqlCommand("InputInsertion", newCon);
            insertSE.Parameters.AddWithValue("@EfterInput", antalSE);
            insertSE.ExecuteNonQuery();

            SqlCommand insertSV = new SqlCommand("InputInsertion", newCon);
            insertSV.Parameters.AddWithValue("@VinterInput", antalSV);
            insertSV.ExecuteNonQuery();

            SqlCommand insertBBV = new SqlCommand("InputInsertion", newCon);
            insertBBV.Parameters.AddWithValue("@BadeVoksenInput", badeBilletV);
            insertBBV.ExecuteNonQuery();

            SqlCommand insertBBB = new SqlCommand("InputInsertion", newCon);
            insertBBB.Parameters.AddWithValue("@BadeBarnInput", badeBilletB);
            insertBBB.ExecuteNonQuery();

            SqlCommand insertCL = new SqlCommand("InputInsertion", newCon);
            insertCL.Parameters.AddWithValue("@CykelInput", cykelL);
            insertCL.ExecuteNonQuery();

            SqlCommand insertRen = new SqlCommand("InputInsertion", newCon);
            insertRen.Parameters.AddWithValue("@RenInput", ren);
            insertRen.ExecuteNonQuery();

            SqlCommand insertSL = new SqlCommand("InputInsertion", newCon);
            insertSL.Parameters.AddWithValue("@SengeInput", sengeL);
            insertSL.ExecuteNonQuery();

            newCon.Close();
        }

        // Could be optimized with an array for each data type
        /// <summary>
        /// Sends the personal information user input to the database.
        /// </summary>
        /// <param name="cpr"></param>
        /// <param name="fornavn"></param>
        /// <param name="efternavn"></param>
        /// <param name="vejnavn"></param>
        /// <param name="husNr"></param>
        /// <param name="postNr"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public void PersonalInfoSubmit(string cpr, string fornavn, string efternavn, string vejnavn, int husNr, int postNr, string email, string password)
        {
            SqlCommand insertCpr = new SqlCommand("PersonalInfoInsertion", newCon);
            insertCpr.Parameters.AddWithValue("@CprInput", cpr);
            insertCpr.ExecuteNonQuery();

            SqlCommand insertfornavn = new SqlCommand("PersonalInfoInsertion", newCon);
            insertfornavn.Parameters.AddWithValue("@FornavnInput", fornavn);
            insertfornavn.ExecuteNonQuery();

            SqlCommand insertEfternavn = new SqlCommand("PersonalInfoInsertion", newCon);
            insertEfternavn.Parameters.AddWithValue("@EfternavnInput", efternavn);
            insertEfternavn.ExecuteNonQuery();

            SqlCommand insertVejnavn = new SqlCommand("PersonalInfoInsertion", newCon);
            insertVejnavn.Parameters.AddWithValue("@VejnavnInput", vejnavn);
            insertVejnavn.ExecuteNonQuery();

            SqlCommand insertHusNr = new SqlCommand("PersonalInfoInsertion", newCon);
            insertHusNr.Parameters.AddWithValue("@HusNrInput", husNr);
            insertHusNr.ExecuteNonQuery();

            SqlCommand insertPostNr = new SqlCommand("PersonalInfoInsertion", newCon);
            insertPostNr.Parameters.AddWithValue("@PostNrInput", postNr);
            insertPostNr.ExecuteNonQuery();

            SqlCommand insertEmail = new SqlCommand("PersonalInfoInsertion", newCon);
            insertEmail.Parameters.AddWithValue("@EmailInput", email);
            insertEmail.ExecuteNonQuery();

            SqlCommand insertPassword = new SqlCommand("PersonalInfoInsertion", newCon);
            insertPassword.Parameters.AddWithValue("@PasswordInput", password);
            insertPassword.ExecuteNonQuery();
        }
        #endregion

        /// <summary>
        /// Inserts the total price into a table in the database, which we can extract with a view later on.
        /// </summary>
        public void PriceInsertion()
        {
            int totalPris =  calc.PriceCalc();

            SqlCommand insertTotalPris = new SqlCommand("TotalPriceInput", newCon);
            insertTotalPris.Parameters.AddWithValue("@TotalPrice", totalPris);
            insertTotalPris.ExecuteNonQuery();
        }
    }
}