using System;

namespace CampingProjekt.Pages
{
    public partial class Booking : System.Web.UI.Page
    {
        Manager manager = new Manager();

        protected void DateInput()
        {
            DateTime arrivalDate = Calendar1.SelectedDate;
            string aDate = Convert.ToString(arrivalDate);

            DateTime exitDate = Calendar2.SelectedDate;
            string eDate = Convert.ToString(exitDate);

            manager.DateSubmit(aDate, eDate);
        }

        protected void TextBoxAmountInput()
        {
            int antalV = Convert.ToInt32(VoksenInput.Text);

            int antalB = Convert.ToInt32(BarnInput.Text);

            int antalH = Convert.ToInt32(HundeInput.Text);

            int antalCPS = Convert.ToInt32(StorCpInput.Text);

            int antalCPL = Convert.ToInt32(LilleCpInput.Text);

            int antalT = Convert.ToInt32(TeltInput.Text);

            int antalLH = Convert.ToInt32(LukHytInput.Text);

            int antalSH = Convert.ToInt32(StandHytInput.Text);

            int antalSF = Convert.ToInt32(ForInput.Text);

            int antalSS = Convert.ToInt32(SommerInput.Text);

            int antalSE = Convert.ToInt32(EfterInput.Text);

            int antalSV = Convert.ToInt32(VinterInput.Text);

            int badeBilletV = Convert.ToInt32(BadeVoksenInput.Text);

            int badeBilletB = Convert.ToInt32(BadeBarnInput.Text);

            int cykelL = Convert.ToInt32(CykelInput.Text);

            int ren = Convert.ToInt32(RenInput.Text);

            int sengeL = Convert.ToInt32(SengeInput.Text);

            // Could easily be optimized with an array
            manager.InputSubmit
                (antalV, antalB, antalH, antalCPS, antalCPL, antalT, antalLH, antalSH, 
                antalSF, antalSS, antalSE, antalSV, badeBilletV, badeBilletB, cykelL, ren, sengeL);
        }

        protected void PersonalInfoInput()
        {
            string cpr = cprInput.Text;

            string fornavn = fornavnInput.Text;

            string efternavn = efternavnInput.Text;

            string vejnavn = vejnavnInput.Text;

            int husNr = Convert.ToInt32(husNrInput.Text);

            int postNr = Convert.ToInt32(postNrInput);

            string email = emailInput.Text;

            string password = passwordInput.Text;

            manager.PersonalInfoSubmit(cpr, fornavn, efternavn, vejnavn, husNr, postNr, email, password);
        }
    }
}