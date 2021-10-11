using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;

namespace CampingProjekt.Pages
{
    public partial class Booking : System.Web.UI.Page
    {

        Manager manager = new Manager();

        SqlConnection tester = new SqlConnection();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public SqlConnection TestCon2()
        {
            return manager.TestCon();
        }
        
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            con.Open();

            // Saves the selected date as a DateTime variable
            DateTime arrivalDate = Calendar1.SelectedDate;

            // Converts the DateTime variable to a string
            string aDate = Convert.ToString(arrivalDate);

            tester = TestCon2();

            // Inserts the selected arrival date into the Reservations_tabel in the CampingDB
            SqlCommand insertArrival = new SqlCommand($"INSERT INTO Reservations_tabel (Start_dato) VALUES({aDate})", tester);

            // Executes the insertArrival date as a NonQuery
            insertArrival.ExecuteNonQuery();

            // Gives feedback if the insertion of data into the table was succesful
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Succesfully inserted');", true);

            con.Close();
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            con.Open();

            // Saves the selected date as a DateTime variable
            DateTime exitDate = Calendar2.SelectedDate;

            // Converts the DateTime variable to a string
            string eDate = Convert.ToString(exitDate);

            // Inserts the selected exit date into the Reservations_tabel in the CampingDB
            SqlCommand insertExit = new SqlCommand($"INSERT INTO Reservations_tabel (Slut_dato) VALUES({eDate})", con);

            // Executes the insertExit date variable as a NonQuery and returns the number of rows affected
            insertExit.ExecuteNonQuery();

            // Gives feedback if the insertion of data into the table was succesful
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Succesfully inserted');", true);

            con.Close();
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            con.Open();

            // Saves the textbox input as a string
            string antalVoksne = TextBox1.Text;

            // Converts the string variable to an integer
            int antalV = Convert.ToInt32(antalVoksne);

            // Inserts the selected number of adults into the Person_type_relation table, where person_type equals voksne
            SqlCommand insertAntalV = new SqlCommand($"INSERT INTO Person_type_relation (Antal_personer) VALUES({antalV}) WHERE Person_type = 'Voksne'", con);

            // Executes the insertAntalV variable date as a NonQuery and returns the number of rows affected
            insertAntalV.ExecuteNonQuery();

            // Gives feedback if the insertion of data into the table was succesful
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Succesfully inserted');", true);

            con.Close();
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
            con.Open();

            // Saves the textbox input as a string
            string antalBørn = TextBox2.Text;

            // Converts the string variable to an integer
            int antalB = Convert.ToInt32(antalBørn);

            // Inserts the selected number of kids into the Person_type_relation table, where person_type equals børn
            SqlCommand insertAntalB = new SqlCommand($"INSERT INTO Person_type_relation (Antal_personer) VALUES({antalB}) WHERE Person_type = 'Børn'", con);

            // Executes the insertAntalB variable date as a NonQuery and returns the number of rows affected
            insertAntalB.ExecuteNonQuery();

            // Gives feedback if the insertion of data into the table was succesful
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Succesfully inserted');", true);

            con.Close();
        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {
            con.Open();

            // Saves the textbox input as a string
            string antalHunde = TextBox3.Text;

            // Converts the string variable to an integer
            int antalH = Convert.ToInt32(antalHunde);

            // Inserts the selected number of dogs into the Person_type_relation table, where person_type equals hund
            SqlCommand insertAntalH = new SqlCommand($"INSERT INTO Person_type_relation (Antal_personer) VALUES({antalH}) WHERE Person_type = 'Hund'", con);

            // Executes the insertAntalH variable as a NonQuery and returns the number of rows affected
            insertAntalH.ExecuteNonQuery();

            // Gives feedback if the insertion of data into the table was succesful
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Succesfully inserted');", true);

            con.Close();
        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {
            con.Open();

            // Saves the textbox input as a string
            string antalCPstor = TextBox4.Text;

            // Converts the string variable to an integer
            int antalCPS = Convert.ToInt32(antalCPstor);

            // Inserts the selected number of Stor campingplads into the Plads_type_relation table, where plads_type equals Stor campingplads
            SqlCommand insertCPS = new SqlCommand($"INSERT INTO Plads_type_relation (Antal_pladser) VALUES({antalCPS}) WHERE Plads_type = 'Stor campingplads'", con);

            // Executes the insertCPS variable date as a NonQuery and returns the number of rows affected
            insertCPS.ExecuteNonQuery();

            // Gives feedback if the insertion of data into the table was succesful
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Succesfully inserted');", true);

            con.Close();
        }

        protected void TextBox5_TextChanged(object sender, EventArgs e)
        {
            con.Open();

            // Saves the textbox input as a string
            string antalCPlille = TextBox5.Text;

            // Converts the string variable to an integer
            int antalCPL = Convert.ToInt32(antalCPlille);

            // Inserts the selected number of dogs into the Person_type_relation table, where person_type equals hund
            SqlCommand insertCPL = new SqlCommand($"INSERT INTO Plads_type_relation (Antal_pladser) VALUES({antalCPL}) WHERE Plads_type = 'Stor campingplads'", con);

            // Executes the insertCPL variable date as a NonQuery and returns the number of rows affected
            insertCPL.ExecuteNonQuery();

            // Gives feedback if the insertion of data into the table was succesful
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Succesfully inserted');", true);

            con.Close();
        }

        protected void TextBox6_TextChanged(object sender, EventArgs e)
        {
            con.Open();

            // Saves the textbox input as a string
            string antalTelte = TextBox6.Text;

            // Converts the string variable to an integer
            int antalT = Convert.ToInt32(antalTelte);

            // Inserts the selected number of "Teltpladser" into the Plads_type_relation table, where plads_type equals Teltplads
            SqlCommand insertT = new SqlCommand($"INSERT INTO Plads_type_relation (Antal_pladser) VALUES({antalT}) WHERE Plads_type = 'Teltplads'", con);

            // Executes the insertT variable date as a NonQuery and returns the number of rows affected
            insertT.ExecuteNonQuery();

            // Gives feedback if the insertion of data into the table was succesful
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Succesfully inserted');", true);

            con.Close();
        }

        protected void TextBox7_TextChanged(object sender, EventArgs e)
        {
            con.Open();

            // Saves the textbox input as a string
            string antalLHytte = TextBox7.Text;

            // Converts the string variable to an integer
            int antalLH = Convert.ToInt32(antalLHytte);

            // Inserts the selected number of "Luksus hytter" into the Plads_type_relation table, where plads_type equals "Luksus hytte"
            SqlCommand insertLH = new SqlCommand($"INSERT INTO Plads_type_relation (Antal_pladser) VALUES({antalLH}) WHERE Plads_type = 'Luksus hytte'", con);

            // Executes the insertLH variable date as a NonQuery and returns the number of rows affected
            insertLH.ExecuteNonQuery();

            // Gives feedback if the insertion of data into the table was succesful
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Succesfully inserted');", true);

            con.Close();
        }

        protected void TextBox8_TextChanged(object sender, EventArgs e)
        {
            con.Open();

            // Saves the textbox input as a string
            string antalSHytte = TextBox8.Text;

            // Converts the string variable to an integer
            int antalSH = Convert.ToInt32(antalSHytte);

            // Inserts the selected number of "Standard hytter" into the Plads_type_relation table, where plads_type equals "Standard hytte"
            SqlCommand insertSH = new SqlCommand($"INSERT INTO Plads_type_relation (Antal_pladser) VALUES({antalSH}) WHERE Plads_type = 'Standard hytte'", con);

            // Executes the insertSH variable date as a NonQuery and returns the number of rows affected
            insertSH.ExecuteNonQuery();

            // Gives feedback if the insertion of data into the table was succesful
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Succesfully inserted');", true);

            con.Close();
        }

        protected void TextBox9_TextChanged(object sender, EventArgs e)
        {
            con.Open();

            // Saves the textbox input as a string
            string sæsonF = TextBox9.Text;

            // Converts the string variable to an integer
            int antalSF = Convert.ToInt32(sæsonF);

            // Inserts the selected number of "Forårs sæsonpladser" into the Plads_type_relation table, where plads_type equals "Forår"
            SqlCommand insertSF = new SqlCommand($"INSERT INTO Plads_type_relation (Antal_pladser) VALUES({antalSF}) WHERE Plads_type = 'Forår'", con);

            // Executes the insertSF variable date as a NonQuery and returns the number of rows affected
            insertSF.ExecuteNonQuery();

            // Gives feedback if the insertion of data into the table was succesful
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Succesfully inserted');", true);

            con.Close();
        }

        protected void TextBox10_TextChanged(object sender, EventArgs e)
        {
            con.Open();

            // Saves the textbox input as a string
            string sæsonS = TextBox10.Text;

            // Converts the string variable to an integer
            int antalSS = Convert.ToInt32(sæsonS);

            // Inserts the selected number of "Sommer sæsonpladser" into the Plads_type_relation table, where plads_type equals "Sommer"
            SqlCommand insertSS = new SqlCommand($"INSERT INTO Plads_type_relation (Antal_pladser) VALUES({antalSS}) WHERE Plads_type = 'Sommer'", con);

            // Executes the insertSS variable date as a NonQuery and returns the number of rows affected
            insertSS.ExecuteNonQuery();

            // Gives feedback if the insertion of data into the table was succesful
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Succesfully inserted');", true);

            con.Close();
        }

        protected void TextBox11_TextChanged(object sender, EventArgs e)
        {
            con.Open();

            // Saves the textbox input as a string
            string sæsonE = TextBox11.Text;

            // Converts the string variable to an integer
            int antalSE = Convert.ToInt32(sæsonE);

            // Inserts the selected number of "Efterårs sæsonpladser" into the Plads_type_relation table, where plads_type equals "Efterår"
            SqlCommand insertSE = new SqlCommand($"INSERT INTO Plads_type_relation (Antal_pladser) VALUES({antalSE}) WHERE Plads_type = 'Efterår'", con);

            // Executes the insertSE variable date as a NonQuery and returns the number of rows affected
            insertSE.ExecuteNonQuery();

            // Gives feedback if the insertion of data into the table was succesful
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Succesfully inserted');", true);

            con.Close();
        }

        protected void TextBox12_TextChanged(object sender, EventArgs e)
        {
            con.Open();

            // Saves the textbox input as a string
            string sæsonV = TextBox12.Text;

            // Converts the string variable to an integer
            int antalSV = Convert.ToInt32(sæsonV);

            // Inserts the selected number of "Vinter sæsonpladser" into the Plads_type_relation table, where plads_type equals "Vinter"
            SqlCommand insertSV = new SqlCommand($"INSERT INTO Plads_type_relation (Antal_pladser) VALUES({antalSV}) WHERE Plads_type = 'Vinter'", con);

            // Executes the insertSV variable date as a NonQuery and returns the number of rows affected
            insertSV.ExecuteNonQuery();

            // Gives feedback if the insertion of data into the table was succesful
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Succesfully inserted');", true);

            con.Close();
        }

        protected void TextBox13_TextChanged(object sender, EventArgs e)
        {
            con.Open();

            // Saves the textbox input as a string
            string badeBilletVoksen = TextBox13.Text;

            // Converts the string variable to an integer
            int badeBilletV = Convert.ToInt32(badeBilletVoksen);

            // Inserts the selected number of "Voksne badebilletter" into the Tillægs_type_relation table, where Tillægs_type equals "Badeland_voksen"
            SqlCommand insertBBV = new SqlCommand($"INSERT INTO Tillægs_type_relation (Antal_tillæg) VALUES({badeBilletV}) WHERE Tillægs_type = 'Badeland_voksen'", con);

            // Executes the insertBBV variable date as a NonQuery and returns the number of rows affected
            insertBBV.ExecuteNonQuery();

            // Gives feedback if the insertion of data into the table was succesful
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Succesfully inserted');", true);

            con.Close();
        }

        protected void TextBox14_TextChanged(object sender, EventArgs e)
        {
            con.Open();

            // Saves the textbox input as a string
            string badeBilletBarn = TextBox14.Text;

            // Converts the string variable to an integer
            int badeBilletB = Convert.ToInt32(badeBilletBarn);

            // Inserts the selected number of "Børne badebilletter" into the Tillægs_type_relation table, where Tillægs_type equals "Badeland_børn"
            SqlCommand insertBBB = new SqlCommand($"INSERT INTO Tillægs_type_relation (Antal_tillæg) VALUES({badeBilletB}) WHERE Tillægs_type = 'Badeland_børn'", con);

            // Executes the insertBBB variable date as a NonQuery and returns the number of rows affected
            insertBBB.ExecuteNonQuery();

            // Gives feedback if the insertion of data into the table was succesful
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Succesfully inserted');", true);

            con.Close();
        }

        protected void TextBox15_TextChanged(object sender, EventArgs e)
        {
            con.Open();

            // Saves the textbox input as a string
            string cykelleje = TextBox15.Text;

            // Converts the string variable to an integer
            int cykelL = Convert.ToInt32(cykelleje);

            // Inserts the selected number of "Cykelleje" into the Tillægs_type_relation table, where Tillægs_type equals "Cykelleje"
            SqlCommand insertCL = new SqlCommand($"INSERT INTO Tillægs_type_relation (Antal_tillæg) VALUES({cykelL}) WHERE Tillægs_type = 'Cykelleje'", con);

            // Executes the insertCL variable date as a NonQuery and returns the number of rows affected
            insertCL.ExecuteNonQuery();

            // Gives feedback if the insertion of data into the table was succesful
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Succesfully inserted');", true);

            con.Close();
        }

        protected void TextBox16_TextChanged(object sender, EventArgs e)
        {
            con.Open();

            // Saves the textbox input as a string
            string rengøring = TextBox16.Text;

            // Converts the string variable to an integer
            int ren = Convert.ToInt32(rengøring);

            // Inserts the selected number of "Rengøring" into the Tillægs_type_relation table, where Tillægs_type equals "Rengøring"
            SqlCommand insertRen = new SqlCommand($"INSERT INTO Tillægs_type_relation (Antal_tillæg) VALUES({ren}) WHERE Tillægs_type = 'Rengøring'", con);

            // Executes the insertRen variable date as a NonQuery and returns the number of rows affected
            insertRen.ExecuteNonQuery();

            // Gives feedback if the insertion of data into the table was succesful
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Succesfully inserted');", true);

            con.Close();
        }

        protected void TextBox17_TextChanged(object sender, EventArgs e)
        {
            con.Open();

            // Saves the textbox input as a string
            string sengelinned = TextBox17.Text;

            // Converts the string variable to an integer
            int sengeL = Convert.ToInt32(sengelinned);

            // Inserts the selected number of "Sengelinneder" into the Tillægs_type_relation table, where Tillægs_type equals "Sengelinned"
            SqlCommand insertSL = new SqlCommand($"INSERT INTO Tillægs_type_relation (Antal_tillæg) VALUES({sengeL}) WHERE Tillægs_type = 'Sengelinned'", con);

            // Executes the insertSL variable date as a NonQuery and returns the number of rows affected
            insertSL.ExecuteNonQuery();

            // Gives feedback if the insertion of data into the table was succesful
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Succesfully inserted');", true);

            con.Close();
        }
    }
}