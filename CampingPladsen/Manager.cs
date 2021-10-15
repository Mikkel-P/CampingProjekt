using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace CampingProjekt
{
    public class Manager
    {
        public Manager() { }

        Calculation calc = new Calculation();

        SqlConnection newCon = new SqlConnection();

        #region SQL Connection
        /// <summary>
        /// Calls on the calculation method to open a connection to the database.
        /// </summary>
        /// <returns></returns>
        public SqlConnection NewConMan()
        {
            return calc.NewConCalc();
        }
        #endregion

        #region Stored Procedure Methods
        /// <summary>
        /// Submits the date input to the database.
        /// </summary>
        /// <param name="aDate"></param>
        /// <param name="eDate"></param>
        public void DateSubmit(string aDate, string eDate)
        {
            newCon = NewConMan();
            newCon.Open();

            SqlCommand insertArrival = new SqlCommand("DateInsertion", newCon);
            insertArrival.Parameters.Add("@Calendar1", SqlDbType.Text);
            insertArrival.Parameters["@Calendar1"].Value = aDate;
            //insertArrival.Parameters.AddWithValue("@Calendar1", aDate);
            //insertArrival.ExecuteNonQuery();
            //insertArrival.ExecuteReader();

            SqlCommand insertExit = new SqlCommand("DateInsertion", newCon);
            insertArrival.Parameters.Add("@Calendar2", SqlDbType.Text);
            insertArrival.Parameters["@Calendar2"].Value = eDate;
            //insertExit.ExecuteNonQuery();

            newCon.Close();
        }

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

            int rsvID = calc.RsvList();

            SqlCommand insertRsvID = new SqlCommand("InputInsertion", newCon);
            insertRsvID.Parameters.Add("@RsvID", SqlDbType.Int);
            insertRsvID.Parameters["@RsvID"].Value = rsvID;

            SqlCommand insertAntalV = new SqlCommand("InputInsertion", newCon);
            insertAntalV.Parameters.Add("@VoksenInput", SqlDbType.TinyInt);
            insertAntalV.Parameters["@VoksenInput"].Value = antalV;

            SqlCommand insertAntalB = new SqlCommand("InputInsertion", newCon);
            insertAntalB.Parameters.Add("@BarnInput", SqlDbType.Text);
            insertAntalB.Parameters["@BarnInput"].Value = antalB;

            SqlCommand insertAntalH = new SqlCommand("InputInsertion", newCon);
            insertAntalH.Parameters.Add("@HundeInput", SqlDbType.TinyInt);
            insertAntalH.Parameters["@HundeInput"].Value = antalH;

            SqlCommand insertCPS = new SqlCommand("InputInsertion", newCon);
            insertCPS.Parameters.Add("@StorCpInput", SqlDbType.TinyInt);
            insertCPS.Parameters["@StorCpInput"].Value = antalCPS;

            SqlCommand insertCPL = new SqlCommand("InputInsertion", newCon);
            insertCPL.Parameters.Add("@LilleCpInput", SqlDbType.TinyInt);
            insertCPL.Parameters["@LilleCpInput"].Value = antalCPL;

            SqlCommand insertT = new SqlCommand("InputInsertion", newCon);
            insertT.Parameters.Add("@TeltInput", SqlDbType.TinyInt);
            insertT.Parameters["@TeltInput"].Value = antalT;

            SqlCommand insertLH = new SqlCommand("InputInsertion", newCon);
            insertLH.Parameters.Add("@LukHytInput", SqlDbType.TinyInt);
            insertLH.Parameters["@LukHytInput"].Value = antalLH;

            SqlCommand insertSH = new SqlCommand("InputInsertion", newCon);
            insertSH.Parameters.Add("@StandHytInput", SqlDbType.TinyInt);
            insertSH.Parameters["@StandHytInput"].Value = antalSH;

            SqlCommand insertSF = new SqlCommand("InputInsertion", newCon);
            insertSF.Parameters.Add("@ForInput", SqlDbType.TinyInt);
            insertSF.Parameters["@ForInput"].Value = antalSF;

            SqlCommand insertSS = new SqlCommand("InputInsertion", newCon);
            insertSS.Parameters.Add("@SommerInput", SqlDbType.TinyInt);
            insertSS.Parameters["@SommerInput"].Value = antalSS;

            SqlCommand insertSE = new SqlCommand("InputInsertion", newCon);
            insertSE.Parameters.Add("@Calendar2", SqlDbType.TinyInt);
            insertSE.Parameters["@Calendar2"].Value = antalSE;

            SqlCommand insertSV = new SqlCommand("InputInsertion", newCon);
            insertSV.Parameters.Add("@VinterInput", SqlDbType.TinyInt);
            insertSV.Parameters["@VinterInput"].Value = antalSV;

            SqlCommand insertBBV = new SqlCommand("InputInsertion", newCon);
            insertBBV.Parameters.Add("@BadeVoksenInput", SqlDbType.TinyInt);
            insertBBV.Parameters["@BadeVoksenInput"].Value = badeBilletV;

            SqlCommand insertBBB = new SqlCommand("InputInsertion", newCon);
            insertBBB.Parameters.Add("@BadeBarnInput", SqlDbType.TinyInt);
            insertBBB.Parameters["@BadeBarnInput"].Value = badeBilletB;

            SqlCommand insertCL = new SqlCommand("InputInsertion", newCon);
            insertCL.Parameters.Add("@CykelInput", SqlDbType.TinyInt);
            insertCL.Parameters["@CykelInput"].Value = cykelL;

            SqlCommand insertRen = new SqlCommand("InputInsertion", newCon);
            insertRen.Parameters.Add("@RenInput", SqlDbType.TinyInt);
            insertRen.Parameters["@RenInput"].Value = ren;

            SqlCommand insertSL = new SqlCommand("InputInsertion", newCon);
            insertSL.Parameters.Add("@SengeInput", SqlDbType.TinyInt);
            insertSL.Parameters["@SengeInput"].Value = sengeL;

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
            newCon = NewConMan();
            newCon.Open();

            SqlCommand insertCpr = new SqlCommand("PersonalInfoInsertion", newCon);
            insertCpr.Parameters.Add("@CprInput", SqlDbType.Text);
            insertCpr.Parameters["@CprInput"].Value = cpr;

            SqlCommand insertfornavn = new SqlCommand("PersonalInfoInsertion", newCon);
            insertfornavn.Parameters.Add("@FornavnInput", SqlDbType.Text);
            insertfornavn.Parameters["@FornavnInput"].Value = fornavn;

            SqlCommand insertEfternavn = new SqlCommand("PersonalInfoInsertion", newCon);
            insertEfternavn.Parameters.Add("@EfternavnInput", SqlDbType.Text);
            insertEfternavn.Parameters["@EfternavnInput"].Value = efternavn;

            SqlCommand insertVejnavn = new SqlCommand("PersonalInfoInsertion", newCon);
            insertVejnavn.Parameters.Add("@VejnavnInput", SqlDbType.Text);
            insertVejnavn.Parameters["@VejnavnInput"].Value = vejnavn;

            SqlCommand insertHusNr = new SqlCommand("PersonalInfoInsertion", newCon);
            insertHusNr.Parameters.Add("@HusNrInput", SqlDbType.Text);
            insertHusNr.Parameters["@HusNrInput"].Value = husNr;

            SqlCommand insertPostNr = new SqlCommand("PersonalInfoInsertion", newCon);
            insertPostNr.Parameters.Add("@PostNrInput", SqlDbType.Text);
            insertPostNr.Parameters["@PostNrInput"].Value = postNr;

            SqlCommand insertEmail = new SqlCommand("PersonalInfoInsertion", newCon);
            insertEmail.Parameters.Add("@EmailInput", SqlDbType.Text);
            insertEmail.Parameters["@EmailInput"].Value = email;

            SqlCommand insertPassword = new SqlCommand("PersonalInfoInsertion", newCon);
            insertPassword.Parameters.Add("@PasswordInput", SqlDbType.Text);
            insertPassword.Parameters["@PasswordInput"].Value = password;

            newCon.Close();
        }

        /// <summary>
        /// Inserts the total price into a table in the database, which we can extract with a view later on.
        /// </summary>
        public void PriceInsertion()
        {
            newCon = NewConMan();
            newCon.Open();

            int totalPris =  calc.PriceCalc();

            SqlCommand insertTotalPris = new SqlCommand("TotalPriceInput", newCon);
            insertTotalPris.Parameters.Add("@TotalPrice", SqlDbType.Int);
            insertTotalPris.Parameters["@TotalPrice"].Value = totalPris;

            newCon.Close();
        }
        #endregion
    }
}