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

        private SqlConnection NewConMan()
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

            SqlCommand insertAntalB = new SqlCommand($"INSERT INTO Person_type_relation (Antal_personer) VALUES({antalB}) WHERE Person_type = 'Børn'", newCon);
            insertAntalB.ExecuteNonQuery();

            SqlCommand insertAntalH = new SqlCommand($"INSERT INTO Person_type_relation (Antal_personer) VALUES({antalH}) WHERE Person_type = 'Hund'", newCon);
            insertAntalH.ExecuteNonQuery();

            SqlCommand insertCPS = new SqlCommand($"INSERT INTO Plads_type_relation (Antal_pladser) VALUES({antalCPS}) WHERE Plads_type = 'Stor campingplads'", newCon);
            insertCPS.ExecuteNonQuery();

            SqlCommand insertCPL = new SqlCommand($"INSERT INTO Plads_type_relation (Antal_pladser) VALUES({antalCPL}) WHERE Plads_type = 'Stor campingplads'", newCon);
            insertCPL.ExecuteNonQuery();

            SqlCommand insertT = new SqlCommand($"INSERT INTO Plads_type_relation (Antal_pladser) VALUES({antalT}) WHERE Plads_type = 'Teltplads'", newCon);
            insertT.ExecuteNonQuery();

            SqlCommand insertLH = new SqlCommand($"INSERT INTO Plads_type_relation (Antal_pladser) VALUES({antalLH}) WHERE Plads_type = 'Luksus hytte'", newCon);
            insertLH.ExecuteNonQuery();

            SqlCommand insertSH = new SqlCommand($"INSERT INTO Plads_type_relation (Antal_pladser) VALUES({antalSH}) WHERE Plads_type = 'Standard hytte'", newCon);
            insertSH.ExecuteNonQuery();

            SqlCommand insertSF = new SqlCommand($"INSERT INTO Plads_type_relation (Antal_pladser) VALUES({antalSF}) WHERE Plads_type = 'Forår'", newCon);
            insertSF.ExecuteNonQuery();

            SqlCommand insertSS = new SqlCommand($"INSERT INTO Plads_type_relation (Antal_pladser) VALUES({antalSS}) WHERE Plads_type = 'Sommer'", newCon);
            insertSS.ExecuteNonQuery();

            SqlCommand insertSE = new SqlCommand($"INSERT INTO Plads_type_relation (Antal_pladser) VALUES({antalSE}) WHERE Plads_type = 'Efterår'", newCon);
            insertSE.ExecuteNonQuery();

            SqlCommand insertSV = new SqlCommand($"INSERT INTO Plads_type_relation (Antal_pladser) VALUES({antalSV}) WHERE Plads_type = 'Vinter'", newCon);
            insertSV.ExecuteNonQuery();

            SqlCommand insertBBV = new SqlCommand($"INSERT INTO Tillægs_type_relation (Antal_tillæg) VALUES({badeBilletV}) WHERE Tillægs_type = 'Badeland_voksen'", newCon);
            insertBBV.ExecuteNonQuery();

            SqlCommand insertBBB = new SqlCommand($"INSERT INTO Tillægs_type_relation (Antal_tillæg) VALUES({badeBilletB}) WHERE Tillægs_type = 'Badeland_børn'", newCon);
            insertBBB.ExecuteNonQuery();

            SqlCommand insertCL = new SqlCommand($"INSERT INTO Tillægs_type_relation (Antal_tillæg) VALUES({cykelL}) WHERE Tillægs_type = 'Cykelleje'", newCon);
            insertCL.ExecuteNonQuery();

            SqlCommand insertRen = new SqlCommand($"INSERT INTO Tillægs_type_relation (Antal_tillæg) VALUES({ren}) WHERE Tillægs_type = 'Rengøring'", newCon);
            insertRen.ExecuteNonQuery();

            SqlCommand insertSL = new SqlCommand($"INSERT INTO Tillægs_type_relation (Antal_tillæg) VALUES({sengeL}) WHERE Tillægs_type = 'Sengelinned'", newCon);
            insertSL.ExecuteNonQuery();

            newCon.Close();
        }


    }
}


// 