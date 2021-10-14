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

        #region Tables
        // Table to hold the reservation_id
        private DataTable rsvIdTable = new DataTable();

        // Table to hold the start date of the reservation to determine season which affects prices
        private DataTable dateTableData = new DataTable();

        // Price info tables
        private DataTable additionalPriceTableData = new DataTable();
        private DataTable personPriceTableData = new DataTable();
        private DataTable spotPriceTableData = new DataTable();

        // Amount info tables
        private DataTable additionalAmountTableData = new DataTable();
        private DataTable personAmountTableData = new DataTable();
        private DataTable spotAmountTableData = new DataTable();
        #endregion

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
        /// Gets the newest reservation id 
        /// </summary>
        /// <returns></returns>
        public int RsvID ()
        {
            int rsvID = Convert.ToInt32(rsvIdList[0]);
            return rsvID;
        }

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
        #endregion

        #region Date data
        /// <summary>
        /// Gets the date data from the database
        /// </summary>
        public void GetDateData()
        {
            newCon = NewConCalc();
            newCon.Open();

            int rsvID = RsvID();

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
                personPriceList.Add(getFallPrice.GetString(1));
                personPriceList.Add(getFallPrice.GetString(2));
            }
            while (GetSpringPrice.Read())
            {
                personPriceList.Add(GetSpringPrice.GetString(1));
                personPriceList.Add(GetSpringPrice.GetString(2));
            }
            while (getLilleCpPrice.Read())
            {
                personPriceList.Add(getLilleCpPrice.GetString(1));
                personPriceList.Add(getLilleCpPrice.GetString(2));
            }
            while (getLukHytPrice.Read())
            {
                personPriceList.Add(getLukHytPrice.GetString(1));
                personPriceList.Add(getLukHytPrice.GetString(2));
            }
            while (getSummerPrice.Read())
            {
                personPriceList.Add(getSummerPrice.GetString(1));
                personPriceList.Add(getSummerPrice.GetString(2));
            }
            while (getStandHytPrice.Read())
            {
                personPriceList.Add(getStandHytPrice.GetString(1));
                personPriceList.Add(getStandHytPrice.GetString(2));
            }
            while (getStorCpPrice.Read())
            {
                personPriceList.Add(getStorCpPrice.GetString(1));
                personPriceList.Add(getStorCpPrice.GetString(2));
            }
            while (getTeltPrice.Read())
            {
                personPriceList.Add(getTeltPrice.GetString(1));
                personPriceList.Add(getTeltPrice.GetString(2));
            }
            while (getWinterPrice.Read())
            {
                personPriceList.Add(getWinterPrice.GetString(1));
                personPriceList.Add(getWinterPrice.GetString(2));
            }
            newCon.Close();
        }

        private void GetAdditionalPrice()
        {
            newCon = NewConCalc();
            newCon.Open();

            // Læg mærke til rækkefølgen som dataen bliver extracted i
            string query = "SELECT * FROM AdditionalPrices-View";

            SqlCommand getAdditionalPrice = new SqlCommand(query, newCon);

            SqlDataAdapter dataAdapt = new SqlDataAdapter(getAdditionalPrice);

            dataAdapt.Fill(additionalPriceTableData);

            dataAdapt.Dispose();

            newCon.Close();
        }
        #endregion

        #region SQL Command Methods
        private void GetPersonAmount()
        {
            newCon = NewConCalc();
            newCon.Open();

            int rsvID = RsvID();

            // Læg mærke til rækkefølgen som dataen bliver extracted i
            string query = $"SELECT * FROM Person_type_relation WHERE Reservations_id = {rsvID}";

            SqlCommand getAmounts = new SqlCommand(query, newCon);

            SqlDataAdapter dataAdapt = new SqlDataAdapter(getAmounts);

            dataAdapt.Fill(personAmountTableData);

            dataAdapt.Dispose();

            newCon.Close();
        }

        private void GetSpotAmount()
        {
            newCon = NewConCalc();
            newCon.Open();

            int rsvID = RsvID();

            // Læg mærke til rækkefølgen som dataen bliver extracted i
            string query = $"SELECT * FROM Plads_type_relation WHERE Reservations_id = {rsvID}";

            SqlCommand getAmounts = new SqlCommand(query, newCon);

            SqlDataAdapter dataAdapt = new SqlDataAdapter(getAmounts);

            dataAdapt.Fill(spotAmountTableData);

            dataAdapt.Dispose();

            newCon.Close();
        }

        private void GetAdditionalAmount()
        {
            newCon = NewConCalc();
            newCon.Open();

            int rsvID = RsvID();

            // Læg mærke til rækkefølgen som dataen bliver extracted i
            string query = $"SELECT * FROM Tillægs_type_relation WHERE Reservations_id = {rsvID}";

            SqlCommand getAmounts = new SqlCommand(query, newCon);

            SqlDataAdapter dataAdapt = new SqlDataAdapter(getAmounts);

            dataAdapt.Fill(additionalAmountTableData);

            dataAdapt.Dispose();

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
            string aDate = dateList[1];
            string eDate = dateList[2];

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

            int barnAmount = personAmount[2];
            int hundeAmount = personAmount[5];
            int voksenAmount = personAmount[8];
            #endregion

            #region Spot amount
            GetSpotAmount();
            List<int> spotAmount = personPriceList.ConvertAll(int.Parse);

            int fallAmount = spotAmount[2];
            int springAmount = spotAmount[5];
            int cpLilleAmount = spotAmount[8];
            int lukHytteAmount = spotAmount[11];
            int summerAmount = spotAmount[14];
            int standHytteAmount = spotAmount[17];
            int cpStorAmount = spotAmount[20];
            int teltAmount = spotAmount[23];
            int winterAmount = spotAmount[26];
            #endregion

            #region Additional amount
            GetAdditionalAmount();
            List<int> additionalAmount = personPriceList.ConvertAll(int.Parse);

            int badeBarnAmount = additionalAmount[2];
            int badeVoksenAmount = additionalAmount[5];
            int cykelLejeAmount = additionalAmount[8];
            int renAmount = additionalAmount[11];
            int sengeLinnedAmount = additionalAmount[14];
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