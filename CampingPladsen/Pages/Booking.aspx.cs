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

        protected void TextBoxInput()
        {
            DateTime arrivalDate = Calendar1.SelectedDate;
            string aDate = Convert.ToString(arrivalDate);

            DateTime exitDate = Calendar2.SelectedDate;
            string eDate = Convert.ToString(exitDate);

            string antalVoksne = VoksenInput.Text;
            int antalV = Convert.ToInt32(antalVoksne);

            string antalBørn = BarnInput.Text;
            int antalB = Convert.ToInt32(antalBørn);

            string antalHunde = HundeInput.Text;
            int antalH = Convert.ToInt32(antalHunde);

            string antalCPstor = StorCpInput.Text;
            int antalCPS = Convert.ToInt32(antalCPstor);

            string antalCPlille = LilleCpInput.Text;
            int antalCPL = Convert.ToInt32(antalCPlille);

            string antalTelte = TeltInput.Text;
            int antalT = Convert.ToInt32(antalTelte);

            string antalLHytte = LukHytInput.Text;
            int antalLH = Convert.ToInt32(antalLHytte);

            string antalSHytte = StandHytInput.Text;
            int antalSH = Convert.ToInt32(antalSHytte);

            string sæsonF = ForInput.Text;
            int antalSF = Convert.ToInt32(sæsonF);

            string sæsonS = SommerInput.Text;
            int antalSS = Convert.ToInt32(sæsonS);

            string sæsonE = EfterInput.Text;
            int antalSE = Convert.ToInt32(sæsonE);

            string sæsonV = VinterInput.Text;
            int antalSV = Convert.ToInt32(sæsonV);

            string badeBilletVoksen = BadeVoksenInput.Text;
            int badeBilletV = Convert.ToInt32(badeBilletVoksen);

            string badeBilletBarn = BadeBarnInput.Text;
            int badeBilletB = Convert.ToInt32(badeBilletBarn);

            string cykelleje = CykelInput.Text;
            int cykelL = Convert.ToInt32(cykelleje);

            string rengøring = RenInput.Text;
            int ren = Convert.ToInt32(rengøring);

            string sengelinned = SengeInput.Text;
            int sengeL = Convert.ToInt32(sengelinned);

            manager.InputSubmit
                (aDate, eDate, antalV, antalB, antalH, antalCPS, antalCPL, antalT, antalLH, antalSH, 
                antalSF, antalSS, antalSE, antalSV, badeBilletV, badeBilletB, cykelL, ren, sengeL);
        }
    }
}