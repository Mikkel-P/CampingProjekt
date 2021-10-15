using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace CampingProjekt
{
    public class Calculation
    {
        public Calculation() { }

        SqlConnection newCon = new SqlConnection();

        List<string> rsvIdList = new List<string>();
        List<string> dateList = new List<string>();
        List<string> personPriceList = new List<string>();
        List<string> spotPriceList = new List<string>();
        List<string> additionalPriceList = new List<string>();
        List<string> personAmountList = new List<string>();
        List<string> spotAmountList = new List<string>();
        List<string> additionalAmountList = new List<string>();

        #region Static dates
        // Dates to seperate the season prices
        DateTime hSeason1 = new DateTime(2021, 6, 14);
        DateTime hSeason2 = new DateTime(2021, 8, 14);
        #endregion

        #region SQL Connection method
        /// <summary>
        /// Returns a connection to the database.
        /// </summary>
        /// <returns></returns>
        public SqlConnection NewConCalc()
        {
            // Creates a new SqlConnection object
            SqlConnection newCon = new SqlConnection();

            // Creates a SqlConnectionStringBuilder object which gets its connectionstring from the GetConString method.
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(GetConString());

            // Gets the connectionstring from the SqlConnectionStringBuilder object, and copies it to the SqlConnection object
            newCon.ConnectionString = builder.ConnectionString;

            return newCon;
        }

        /// <summary>
        /// Generates the connectionstring needed to establish a connection to the database.
        /// </summary>
        /// <returns></returns>
        private static string GetConString()
        {
            // Returns a string with the information needed to make a connectionstring
            return "Data Source=172.16.59.46;Initial Catalog=CampingDB;Persist Security Info=True;User ID=sa;Password=Password1234!";
        }
        #endregion

        #region Gets rsvID
        /// <summary>
        /// Gets the reservation_id associated with the date submission.
        /// </summary>
        public void GetRsvID()
        {
            newCon = NewConCalc();
            newCon.Open();

            string query = "SELECT * FROM RsvID-View";

            SqlCommand getRsvID = new SqlCommand(query, newCon);

            SqlDataReader reader = getRsvID.ExecuteReader();

            while (reader.Read())
            {
                rsvIdList.Add(reader.GetString(1));
            }
            newCon.Close();
        }

        /// <summary>
        /// Gets the newest reservation id 
        /// </summary>
        /// <returns></returns>
        public int RsvList()
        {
            GetRsvID();
            int rsvID = Convert.ToInt32(rsvIdList[0]);
            return rsvID;
        }
        #endregion

        #region Date data
        /// <summary>
        /// Gets the date data from the database
        /// </summary>
        public void GetDateData()
        {
            newCon = NewConCalc();
            newCon.Open();

            int rsvID = RsvList();

            string query = $"SELECT * FROM Reservations_tabel WHERE Reservations_id = {rsvID}";

            SqlCommand dateData = new SqlCommand(query, newCon);

            SqlDataReader reader = dateData.ExecuteReader();

            while (reader.Read())
            {
                dateList.Add(reader.GetString(2));
                dateList.Add(reader.GetString(3));
            }
            newCon.Close();
        }
        #endregion

        #region SQL View Methods
        private void GetPersonPrice()
        {
            newCon = NewConCalc();
            newCon.Open();

            // Læg mærke til rækkefølgen som dataen bliver extracted i
            string query1 = "SELECT * FROM BarnPrices-View";
            string query2 = "SELECT * FROM HundPrices-View";
            string query3 = "SELECT * FROM VoksenPrices-View";

            SqlCommand comm1 = new SqlCommand(query1, newCon);
            SqlCommand comm2 = new SqlCommand(query2, newCon);
            SqlCommand comm3 = new SqlCommand(query3, newCon);

            SqlDataReader getBarnPrice = comm1.ExecuteReader();
            SqlDataReader getHundPrice = comm2.ExecuteReader();
            SqlDataReader getVoksenPrice = comm3.ExecuteReader();

            while (getBarnPrice.Read())
            {
                personPriceList.Add(getBarnPrice.GetString(1));
                personPriceList.Add(getBarnPrice.GetString(2));
            }

            while (getHundPrice.Read())
            {
                personPriceList.Add(getHundPrice.GetString(1));
                personPriceList.Add(getHundPrice.GetString(2));
            }

            while (getVoksenPrice.Read())
            {
                personPriceList.Add(getVoksenPrice.GetString(1));
                personPriceList.Add(getVoksenPrice.GetString(2));
            }
            newCon.Close();
        }

        private void GetSpotPrice()
        {
            newCon = NewConCalc();
            newCon.Open();

            // SQL Commands saved as string variables
            string query1 = "SELECT * FROM FallView";
            string query2 = "SELECT * FROM SpringView";
            string query3 = "SELECT * FROM LilleCpView";
            string query4 = "SELECT * FROM LukHytView";
            string query5 = "SELECT * FROM SummerView";
            string query6 = "SELECT * FROM StandHytView";
            string query7 = "SELECT * FROM StorCpView";
            string query8 = "SELECT * FROM TeltView";
            string query9 = "SELECT * FROM WinterView";

            // Making SqlCommand objects from the strings above
            SqlCommand comm1 = new SqlCommand(query1, newCon);
            SqlCommand comm2 = new SqlCommand(query2, newCon);
            SqlCommand comm3 = new SqlCommand(query3, newCon);
            SqlCommand comm4 = new SqlCommand(query4, newCon);
            SqlCommand comm5 = new SqlCommand(query5, newCon);
            SqlCommand comm6 = new SqlCommand(query6, newCon);
            SqlCommand comm7 = new SqlCommand(query7, newCon);
            SqlCommand comm8 = new SqlCommand(query8, newCon);
            SqlCommand comm9 = new SqlCommand(query9, newCon);

            // Reads the data from the SQL commands
            SqlDataReader getFallPrice = comm1.ExecuteReader();
            SqlDataReader GetSpringPrice  = comm2.ExecuteReader();
            SqlDataReader getLilleCpPrice = comm3.ExecuteReader();
            SqlDataReader getLukHytPrice  = comm4.ExecuteReader();
            SqlDataReader getSummerPrice  = comm5.ExecuteReader();
            SqlDataReader getStandHytPrice = comm6.ExecuteReader();
            SqlDataReader getStorCpPrice  = comm7.ExecuteReader();
            SqlDataReader getTeltPrice = comm8.ExecuteReader();
            SqlDataReader getWinterPrice  = comm9.ExecuteReader();

            // Adds the contents of the views to a list
            while (getFallPrice.Read())
            {
                spotPriceList.Add(getFallPrice.GetString(1));
                spotPriceList.Add(getFallPrice.GetString(2));
            }
            while (GetSpringPrice.Read())
            {
                spotPriceList.Add(GetSpringPrice.GetString(1));
                spotPriceList.Add(GetSpringPrice.GetString(2));
            }
            while (getLilleCpPrice.Read())
            {
                spotPriceList.Add(getLilleCpPrice.GetString(1));
                spotPriceList.Add(getLilleCpPrice.GetString(2));
            }
            while (getLukHytPrice.Read())
            {
                spotPriceList.Add(getLukHytPrice.GetString(1));
                spotPriceList.Add(getLukHytPrice.GetString(2));
            }
            while (getSummerPrice.Read())
            {
                spotPriceList.Add(getSummerPrice.GetString(1));
                spotPriceList.Add(getSummerPrice.GetString(2));
            }
            while (getStandHytPrice.Read())
            {
                spotPriceList.Add(getStandHytPrice.GetString(1));
                spotPriceList.Add(getStandHytPrice.GetString(2));
            }
            while (getStorCpPrice.Read())
            {
                spotPriceList.Add(getStorCpPrice.GetString(1));
                spotPriceList.Add(getStorCpPrice.GetString(2));
            }
            while (getTeltPrice.Read())
            {
                spotPriceList.Add(getTeltPrice.GetString(1));
                spotPriceList.Add(getTeltPrice.GetString(2));
            }
            while (getWinterPrice.Read())
            {
                spotPriceList.Add(getWinterPrice.GetString(1));
                spotPriceList.Add(getWinterPrice.GetString(2));
            }
            newCon.Close();
        }

        private void GetAdditionalPrice()
        {
            newCon = NewConCalc();
            newCon.Open();

            // FIX THESE VIEWS
            string query1 = "SELECT * FROM AdditionalPrices-View";
            string query2 = "SELECT * FROM AdditionalPrices-View";
            string query3 = "SELECT * FROM AdditionalPrices-View";
            string query4 = "SELECT * FROM AdditionalPrices-View";
            string query5 = "SELECT * FROM AdditionalPrices-View";

            SqlCommand comm1 = new SqlCommand(query1, newCon);
            SqlCommand comm2 = new SqlCommand(query2, newCon);
            SqlCommand comm3 = new SqlCommand(query3, newCon);
            SqlCommand comm4 = new SqlCommand(query4, newCon);
            SqlCommand comm5 = new SqlCommand(query5, newCon);

            // Reads the data from the SQL commands
            SqlDataReader badeBilletV = comm1.ExecuteReader();
            SqlDataReader badeBilletB = comm2.ExecuteReader();
            SqlDataReader cykelLeje = comm3.ExecuteReader();
            SqlDataReader ren = comm4.ExecuteReader();
            SqlDataReader sengeLinned = comm5.ExecuteReader();


            // Adds the contents of the views to a list
            while (badeBilletV.Read())
            {
                additionalPriceList.Add(badeBilletV.GetString(1));
            }
            while (badeBilletB.Read())
            {
                additionalPriceList.Add(badeBilletB.GetString(1));
            }
            while (cykelLeje.Read())
            {
                additionalPriceList.Add(cykelLeje.GetString(1));
            }
            while (ren.Read())
            {
                additionalPriceList.Add(ren.GetString(1));
            }
            while (sengeLinned.Read())
            {
                additionalPriceList.Add(sengeLinned.GetString(1));
            }
            newCon.Close();
        }
        #endregion

        #region SQL Command Methods
        private void GetPersonAmount()
        {
            newCon = NewConCalc();
            newCon.Open();

            int rsvID = RsvList();

            // Check if this sql command is possible
            string query1 = $"SELECT * FROM Person_type_relation (Adntal_personer) WHERE (Reservations_id = {rsvID}) AND (Person_type='Voksen'";
            string query2 = $"SELECT * FROM Person_type_relation (Adntal_personer) WHERE (Reservations_id = {rsvID}) AND (Person_type='Børn'";
            string query3 = $"SELECT * FROM Person_type_relation (Adntal_personer) WHERE (Reservations_id = {rsvID}) AND (Person_type='Hund'";

            SqlCommand comm1 = new SqlCommand(query1, newCon);
            SqlCommand comm2 = new SqlCommand(query2, newCon);
            SqlCommand comm3 = new SqlCommand(query3, newCon);

            // Reads the data from the SQL commands
            SqlDataReader getVoksenAmount = comm1.ExecuteReader();
            SqlDataReader getBarnAmount = comm2.ExecuteReader();
            SqlDataReader getHundAmount = comm3.ExecuteReader();


            // Adds the contents of the views to a list
            while (getVoksenAmount.Read())
            {
                personAmountList.Add(getVoksenAmount.GetString(1));
            }
            while (getBarnAmount.Read())
            {
                personAmountList.Add(getBarnAmount.GetString(1));
            }
            while (getHundAmount.Read())
            {
                personAmountList.Add(getHundAmount.GetString(1));
            }

            newCon.Close();
        }

        private void GetSpotAmount()
        {
            newCon = NewConCalc();
            newCon.Open();

            int rsvID = RsvList();

            // Læg mærke til rækkefølgen som dataen bliver extracted i
            string query1 = $"SELECT * FROM Plads_type_relation WHERE (Reservations_id = {rsvID}) AND (Plads_type='Efterår')";
            string query2 = $"SELECT * FROM Plads_type_relation WHERE (Reservations_id = {rsvID}) AND (Plads_type='Forår')";
            string query3 = $"SELECT * FROM Plads_type_relation WHERE (Reservations_id = {rsvID}) AND (Plads_type='Lille campingplads')";
            string query4 = $"SELECT * FROM Plads_type_relation WHERE (Reservations_id = {rsvID}) AND (Plads_type='Luksus hytte')";
            string query5 = $"SELECT * FROM Plads_type_relation WHERE (Reservations_id = {rsvID}) AND (Plads_type='Sommer')";
            string query6 = $"SELECT * FROM Plads_type_relation WHERE (Reservations_id = {rsvID}) AND (Plads_type='Standard hytte')";
            string query7 = $"SELECT * FROM Plads_type_relation WHERE (Reservations_id = {rsvID}) AND (Plads_type='Stor campingplads')";
            string query8 = $"SELECT * FROM Plads_type_relation WHERE (Reservations_id = {rsvID}) AND (Plads_type='Teltplads')";
            string query9 = $"SELECT * FROM Plads_type_relation WHERE (Reservations_id = {rsvID}) AND (Plads_type='Vinter')";

            // Making SqlCommand objects from the strings above
            SqlCommand comm1 = new SqlCommand(query1, newCon);
            SqlCommand comm2 = new SqlCommand(query2, newCon);
            SqlCommand comm3 = new SqlCommand(query3, newCon);
            SqlCommand comm4 = new SqlCommand(query4, newCon);
            SqlCommand comm5 = new SqlCommand(query5, newCon);
            SqlCommand comm6 = new SqlCommand(query6, newCon);
            SqlCommand comm7 = new SqlCommand(query7, newCon);
            SqlCommand comm8 = new SqlCommand(query8, newCon);
            SqlCommand comm9 = new SqlCommand(query9, newCon);

            // Reads the data from the SQL commands
            SqlDataReader getFallAmount = comm1.ExecuteReader();
            SqlDataReader GetSpringAmount = comm2.ExecuteReader();
            SqlDataReader getLilleCpAmount = comm3.ExecuteReader();
            SqlDataReader getLukHytAmount = comm4.ExecuteReader();
            SqlDataReader getSummerAmount = comm5.ExecuteReader();
            SqlDataReader getStandHytAmount = comm6.ExecuteReader();
            SqlDataReader getStorCpAmount = comm7.ExecuteReader();
            SqlDataReader getTeltAmount = comm8.ExecuteReader();
            SqlDataReader getWinterAmount = comm9.ExecuteReader();

            // Adds the contents of the views to a list
            while (getFallAmount.Read())
            {
                spotAmountList.Add(getFallAmount.GetString(1));
            }
            while (GetSpringAmount.Read())
            {
                spotAmountList.Add(GetSpringAmount.GetString(1));
            }
            while (getLilleCpAmount.Read())
            {
                spotAmountList.Add(getLilleCpAmount.GetString(1));
            }
            while (getLukHytAmount.Read())
            {
                spotAmountList.Add(getLukHytAmount.GetString(1));
            }
            while (getSummerAmount.Read())
            {
                spotAmountList.Add(getSummerAmount.GetString(1));
            }
            while (getStandHytAmount.Read())
            {
                spotAmountList.Add(getStandHytAmount.GetString(1));
            }
            while (getStorCpAmount.Read())
            {
                spotAmountList.Add(getStorCpAmount.GetString(1));
            }
            while (getTeltAmount.Read())
            {
                spotAmountList.Add(getTeltAmount.GetString(1));
            }
            while (getWinterAmount.Read())
            {
                spotAmountList.Add(getWinterAmount.GetString(1));
            }
            newCon.Close();
        }

        private void GetAdditionalAmount()
        {
            newCon = NewConCalc();
            newCon.Open();

            int rsvID = RsvList();

            string query1 = $"SELECT * FROM Tillægs_type_relation WHERE (Reservations_id = {rsvID}) AND (Tillægs_type='Badeland_børn'";
            string query2 = $"SELECT * FROM Tillægs_type_relation WHERE (Reservations_id = {rsvID}) AND (Tillægs_type='Badeland_voksen'";
            string query3 = $"SELECT * FROM Tillægs_type_relation WHERE (Reservations_id = {rsvID}) AND (Tillægs_type='Cykelleje'";
            string query4 = $"SELECT * FROM Tillægs_type_relation WHERE (Reservations_id = {rsvID}) AND (Tillægs_type='Rengøring'";
            string query5 = $"SELECT * FROM Tillægs_type_relation WHERE (Reservations_id = {rsvID}) AND (Tillægs_type='Sengelinned'";

            // Making SqlCommand objects from the strings above
            SqlCommand comm1 = new SqlCommand(query1, newCon);
            SqlCommand comm2 = new SqlCommand(query2, newCon);
            SqlCommand comm3 = new SqlCommand(query3, newCon);
            SqlCommand comm4 = new SqlCommand(query4, newCon);
            SqlCommand comm5 = new SqlCommand(query5, newCon);

            // Reads the data from the SQL commands
            SqlDataReader getBBVAmount = comm1.ExecuteReader();
            SqlDataReader GetBBBAmount = comm2.ExecuteReader();
            SqlDataReader getCykelAmount = comm3.ExecuteReader();
            SqlDataReader getRenAmount = comm4.ExecuteReader();
            SqlDataReader getSengeAmount = comm5.ExecuteReader();

            // Adds the contents of the views to a list
            while (getBBVAmount.Read())
            {
                additionalAmountList.Add(getBBVAmount.GetString(1));
            }
            while (GetBBBAmount.Read())
            {
                additionalAmountList.Add(GetBBBAmount.GetString(1));
            }
            while (getCykelAmount.Read())
            {
                additionalAmountList.Add(getCykelAmount.GetString(1));
            }
            while (getRenAmount.Read())
            {
                additionalAmountList.Add(getRenAmount.GetString(1));
            }
            while (getSengeAmount.Read())
            {
                additionalAmountList.Add(getSengeAmount.GetString(1));
            };

            newCon.Close();
        }
        #endregion

        #region Price calculation
        /// <summary>
        /// Collects all the user input that is relevant for the price calculation, then gets the total price associated with the reservation.
        /// </summary>
        /// <returns></returns>
        public int PriceCalc()
        {
            #region Date extraction
            // Gets the arrival and exit date for the reservation so we can calculate price depending on season
            GetDateData();
            string aDate = dateList[0];
            string eDate = dateList[1];

            DateTime arrivalDate = DateTime.Parse(aDate);
            DateTime exitDate = DateTime.Parse(eDate);
            TimeSpan tempHolder = arrivalDate.Subtract(exitDate);
            int amountOfDays = tempHolder.Days;

            Convert.ToDateTime(hSeason1);
            Convert.ToDateTime(hSeason2);
            #endregion

            #region Person prices
            GetPersonPrice();
            List<int> personPrice = personPriceList.ConvertAll(int.Parse);

            int barnPriceH = personPrice[0];
            int barnPriceL = personPrice[1];
            int hundPriceH = personPrice[2];
            int hundPriceL = personPrice[3];
            int voksenPriceH = personPrice[4];
            int voksenPriceL = personPrice[5];
            #endregion

            #region Spot prices
            GetSpotPrice();
            List<int> spotPrice = personPriceList.ConvertAll(int.Parse);

            int fall = spotPrice[0];
            int spring = spotPrice[2];
            int cpLilleH = spotPrice[4];
            int cpLilleL = spotPrice[5];
            int lukHytteH = spotPrice[6];
            int lukHytteL = spotPrice[7];
            int summer = spotPrice[8];
            int standHytteH = spotPrice[10];
            int standHytteL = spotPrice[11];
            int cpStorH = spotPrice[12];
            int cpStorL = spotPrice[13];
            int teltH = spotPrice[14];
            int teltL = spotPrice[15];
            int winter = spotPrice[16];
            #endregion

            #region Additional prices
            GetAdditionalPrice();
            List<int> additionalPrice = personPriceList.ConvertAll(int.Parse);

            int badeBarn = additionalPrice[0];
            int badeVoksen = additionalPrice[1];
            int cykelLeje = additionalPrice[2];
            int ren = additionalPrice[3];
            int sengeLinned = additionalPrice[4];
            #endregion

            #region Person amount
            GetPersonAmount();
            List<int> personAmount = personPriceList.ConvertAll(int.Parse);

            int barnAmount = personAmount[0];
            int hundeAmount = personAmount[1];
            int voksenAmount = personAmount[2];
            #endregion

            #region Spot amount
            GetSpotAmount();
            List<int> spotAmount = personPriceList.ConvertAll(int.Parse);

            int fallAmount = spotAmount[0];
            int springAmount = spotAmount[1];
            int cpLilleAmount = spotAmount[2];
            int lukHytteAmount = spotAmount[3];
            int summerAmount = spotAmount[4];
            int standHytteAmount = spotAmount[5];
            int cpStorAmount = spotAmount[6];
            int teltAmount = spotAmount[7];
            int winterAmount = spotAmount[8];
            #endregion

            #region Additional amount
            GetAdditionalAmount();
            List<int> additionalAmount = personPriceList.ConvertAll(int.Parse);

            int badeBarnAmount = additionalAmount[0];
            int badeVoksenAmount = additionalAmount[1];
            int cykelLejeAmount = additionalAmount[2];
            int renAmount = additionalAmount[3];
            int sengeLinnedAmount = additionalAmount[4];
            #endregion

            #region Actual price calculation
            if (arrivalDate > hSeason1 && arrivalDate < hSeason2)
            {   // High season price calculation

                // Persons total
                int barnTotal = barnPriceH * barnAmount;
                int hundTotal = hundPriceH * hundeAmount;
                int voksenTotal = voksenPriceH * voksenAmount;

                // Season spots total
                int springTotal = spring * springAmount;
                int summerTotal = summer * summerAmount;
                int fallTotal = fall * fallAmount;
                int winterTotal = winter * winterAmount;

                // Spot types total
                int cpLilleHTotal = cpLilleH * cpLilleAmount;
                int cpStorHTotal = cpStorH * cpStorAmount;
                int standHytteHTotal = standHytteH * standHytteAmount;
                int lukHytteHTotal = lukHytteH * lukHytteAmount;
                int teltHTotal = teltH * teltAmount;

                // Additional types total
                int badeBarnTotal = badeBarn * badeBarnAmount;
                int badeVoksenTotal = badeVoksen * badeVoksenAmount;
                int cykelLejeTotal = cykelLeje * cykelLejeAmount;
                int renTotal = ren * renAmount;
                int sengeLinnedTotal = sengeLinned * sengeLinnedAmount;



                int highSeasonTemp = (barnTotal + hundTotal + voksenTotal + cpLilleHTotal + cpStorHTotal +
                    standHytteHTotal + lukHytteHTotal + teltHTotal + badeBarnTotal +
                    badeVoksenTotal + cykelLejeTotal + renTotal + sengeLinnedTotal) * amountOfDays;

                int highSeasonTotal = springTotal + summerTotal + fallTotal + winterTotal + highSeasonTemp;

                return highSeasonTotal;
            }
            else 
            {
                // Low season price calculation
                // Persons total
                int barnTotal = barnPriceL * barnAmount;
                int hundTotal = hundPriceL * hundeAmount;
                int voksenTotal = voksenPriceL * voksenAmount;

                // Season spots total
                int springTotal = spring * springAmount;
                int summerTotal = summer * summerAmount;
                int fallTotal = fall * fallAmount;
                int winterTotal = winter * winterAmount;

                // Spot types total
                int cpLilleHTotal = cpLilleL * cpLilleAmount;
                int cpStorHTotal = cpStorL * cpStorAmount;
                int standHytteHTotal = standHytteL * standHytteAmount;
                int lukHytteHTotal = lukHytteL * lukHytteAmount;
                int teltHTotal = teltL * teltAmount;

                // Additional types total
                int badeBarnTotal = badeBarn * badeBarnAmount;
                int badeVoksenTotal = badeVoksen * badeVoksenAmount;
                int cykelLejeTotal = cykelLeje * cykelLejeAmount;
                int renTotal = ren * renAmount;
                int sengeLinnedTotal = sengeLinned * sengeLinnedAmount;

                int lowSeasonTemp = (barnTotal + hundTotal + voksenTotal + cpLilleHTotal + cpStorHTotal +
                    standHytteHTotal + lukHytteHTotal + teltHTotal + badeBarnTotal + badeVoksenTotal + 
                    cykelLejeTotal + renTotal + sengeLinnedTotal) * amountOfDays;

                int lowSeasonTotal = springTotal + summerTotal + fallTotal + winterTotal + lowSeasonTemp;

                return lowSeasonTotal;
            }
            #endregion
        }
        #endregion
    }
}