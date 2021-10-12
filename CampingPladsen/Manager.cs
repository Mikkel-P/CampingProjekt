using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace CampingProjekt
{
    public class Manager
    {
        // Gemme alle værdier inden de sendes til DB, lav reservation først, så vi får et reservations_id, og tilføj så værdier til tabellerne

        public Manager() { }

        Dal dal = new Dal();

        Calculation calc = new Calculation();

        SqlConnection newCon = new SqlConnection();

        private SqlConnection NewConMan()
        {
            return dal.NewConDal();
        }

        public void InputSubmit
            (string aDate, string eDate, int antalV, int antalB, int antalH, int antalCPS, int antalCPL, int antalT, int antalLH, int antalSH, int antalSF, 
            int antalSS, int antalSE, int antalSV, int badeBilletV, int badeBilletB, int cykelL, int ren, int sengeL)
        {
            newCon = NewConMan();
            newCon.Open();

            // Inserts the selected arrival date into the Reservations_tabel in the CampingDB
            SqlCommand insertArrival = new SqlCommand($"INSERT INTO Reservations_tabel (Start_dato) VALUES({aDate})", newCon);
            // Executes the insertArrival date as a NonQuery
            insertArrival.ExecuteNonQuery();

            SqlCommand insertExit = new SqlCommand($"INSERT INTO Reservations_tabel (Slut_dato) VALUES({eDate})", newCon);
            insertExit.ExecuteNonQuery();



            int id = 0; // Stored procedure der returnerer det højeste Reservation_id

            //SqlCommand insertAntalV = new SqlCommand($"INSERT INTO Person_type_relation (Reservations_id, Person_type, Antal_personer) VALUES({Reservations_id}, Person_type, {antalV})", newCon);


            SqlCommand insertAntalV2 = new SqlCommand("SP_Reservation", newCon);
            insertAntalV2.Parameters.AddWithValue("@VoksenInput", antalV);
            insertAntalV2.ExecuteNonQuery();

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
        }


    }
}