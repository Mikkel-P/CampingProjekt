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

        public SqlConnection NewConMan()
        {
            return dal.NewConDal();
        }

        public void DateSubmit(string aDate, string eDate)
        {
            newCon = NewConMan();
            newCon.Open();

            // The right way
            SqlCommand insertArrival = new SqlCommand("StoredProcedure", newCon);
            SqlCommand insertExit = new SqlCommand("StoredProcedure", newCon);

            insertArrival.Parameters.AddWithValue("@Calendar1", aDate);
            insertExit.Parameters.AddWithValue("@Calendar2", eDate);

            insertArrival.ExecuteNonQuery();
            insertExit.ExecuteNonQuery();

            newCon.Close();
        }

        // Make view for this method
        public void GetRsvID()
        {
            newCon = NewConMan();
            newCon.Open();

            string query = "SELECT * FROM ViewName";

            SqlCommand getRsvID = new SqlCommand(query, newCon);

            SqlDataAdapter dataAdapt = new SqlDataAdapter(getRsvID);

            dataAdapt.Fill(dataTable);

            dataAdapt.Dispose();

            newCon.Close();
        }

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

        // Could easily be optimized with an array
        public void InputSubmit
            (int antalV, int antalB, int antalH, int antalCPS, int antalCPL, int antalT, int antalLH, int antalSH, int antalSF,
            int antalSS, int antalSE, int antalSV, int badeBilletV, int badeBilletB, int cykelL, int ren, int sengeL)
        {
            newCon = NewConMan();
            newCon.Open();

            string temp = GetTableData(dataTable);

            int rsvID = Convert.ToInt32(temp);

            // The right way
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

        // Make a stored procedure for this
        // Could be optimized with an array for each data type
        public void PersonalInfoSubmit(int cpr, string fornavn, string efternavn, string vejnavn, int husNr, int postNr, string email, string password)
        {
            // The right way
            SqlCommand insertCpr = new SqlCommand("StoredProcedure", newCon);
            insertCpr.Parameters.AddWithValue("@CprInput", cpr);
            insertCpr.ExecuteNonQuery();

            SqlCommand insertfornavn = new SqlCommand("StoredProcedure", newCon);
            insertfornavn.Parameters.AddWithValue("@fornavnInput", fornavn);
            insertfornavn.ExecuteNonQuery();

            SqlCommand insertEfternavn = new SqlCommand("StoredProcedure", newCon);
            insertEfternavn.Parameters.AddWithValue("@EfternavnInput", efternavn);
            insertEfternavn.ExecuteNonQuery();

            SqlCommand insertVejnavn = new SqlCommand("StoredProcedure", newCon);
            insertVejnavn.Parameters.AddWithValue("@VejnavnInput", vejnavn);
            insertVejnavn.ExecuteNonQuery();

            SqlCommand insertHusNr = new SqlCommand("StoredProcedure", newCon);
            insertHusNr.Parameters.AddWithValue("@HusNrInput", husNr);
            insertHusNr.ExecuteNonQuery();

            SqlCommand insertPostNr = new SqlCommand("StoredProcedure", newCon);
            insertPostNr.Parameters.AddWithValue("@PostNrInput", postNr);
            insertPostNr.ExecuteNonQuery();

            SqlCommand insertEmail = new SqlCommand("StoredProcedure", newCon);
            insertEmail.Parameters.AddWithValue("@EmailInput", email);
            insertEmail.ExecuteNonQuery();

            SqlCommand insertPassword = new SqlCommand("StoredProcedure", newCon);
            insertPassword.Parameters.AddWithValue("@PasswordInput", password);
            insertPassword.ExecuteNonQuery();
        }

        // Call on this from the ui that should display total price
        public int PriceMover()
        {
            return calc.PriceCalc();
        }
    }
}