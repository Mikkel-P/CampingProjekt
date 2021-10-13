using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Text;

namespace CampingProjekt
{
    public class Manager
    {
        // Gemme alle værdier inden de sendes til DB, lav reservation først, så vi får et reservations_id, og tilføj så værdier til tabellerne

        public Manager() { }

        Dal dal = new Dal();

        Calculation calc = new Calculation();

        SqlConnection newCon = new SqlConnection();

        private DataTable dataTable = new DataTable();

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
    }
}