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

        public SqlConnection NewConUI()
        {
            return manager.NewConMan();
        }

        protected void InputMethod()
        {
            DateTime arrivalDate = Calendar1.SelectedDate;
            string aDate = Convert.ToString(arrivalDate);

            DateTime exitDate = Calendar2.SelectedDate;
            string eDate = Convert.ToString(exitDate);

            string antalVoksne = TextBox1.Text;
            int antalV = Convert.ToInt32(antalVoksne);

            string antalBørn = TextBox2.Text;
            int antalB = Convert.ToInt32(antalBørn);

            string antalHunde = TextBox3.Text;
            int antalH = Convert.ToInt32(antalHunde);

            string antalCPstor = TextBox4.Text;
            int antalCPS = Convert.ToInt32(antalCPstor);

            string antalCPlille = TextBox5.Text;
            int antalCPL = Convert.ToInt32(antalCPlille);

            string antalTelte = TextBox6.Text;
            int antalT = Convert.ToInt32(antalTelte);

            string antalLHytte = TextBox7.Text;
            int antalLH = Convert.ToInt32(antalLHytte);

            string antalSHytte = TextBox8.Text;
            int antalSH = Convert.ToInt32(antalSHytte);

            string sæsonF = TextBox9.Text;
            int antalSF = Convert.ToInt32(sæsonF);

            string sæsonS = TextBox10.Text;
            int antalSS = Convert.ToInt32(sæsonS);

            string sæsonE = TextBox11.Text;
            int antalSE = Convert.ToInt32(sæsonE);

            string sæsonV = TextBox12.Text;
            int antalSV = Convert.ToInt32(sæsonV);

            string badeBilletVoksen = TextBox13.Text;
            int badeBilletV = Convert.ToInt32(badeBilletVoksen);

            string badeBilletBarn = TextBox14.Text;
            int badeBilletB = Convert.ToInt32(badeBilletBarn);

            string cykelleje = TextBox15.Text;
            int cykelL = Convert.ToInt32(cykelleje);

            string rengøring = TextBox16.Text;
            int ren = Convert.ToInt32(rengøring);

            string sengelinned = TextBox17.Text;
            int sengeL = Convert.ToInt32(sengelinned);

            manager.InputSubmit
                (aDate, eDate, antalV, antalB, antalH, antalCPS, antalCPL, antalT, antalLH, antalSH, antalSF, 
                antalSS, antalSE, antalSV, badeBilletV, badeBilletB, cykelL, ren, sengeL);
        }
    }
}