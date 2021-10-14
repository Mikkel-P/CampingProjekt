using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace CampingProjekt
{
    public class Calculation
    {
        public Calculation() { }

        Manager manager = new Manager();

        SqlConnection newCon = new SqlConnection();

        #region Tables
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

        // Gets the newest reservation id 
        public int RsvID ()
        {
            string temp = manager.GetTableData(manager.dataTable);
            int rsvID = Convert.ToInt32(temp);
            return rsvID;
        }

        public void GetDateData()
        {
            newCon = manager.NewConMan();
            newCon.Open();

            int rsvID = RsvID();

            // Læg mærke til rækkefølgen som dataen bliver extracted i
            string query = $"SELECT * FROM Reservations_tabel WHERE Reservations_id = {rsvID}";

            SqlCommand getRsvID = new SqlCommand(query, newCon);

            SqlDataAdapter dataAdapt = new SqlDataAdapter(getRsvID);

            dataAdapt.Fill(dateTableData);

            dataAdapt.Dispose();

            newCon.Close();
        }

        #region SQL View Methods
        private string FillDateData(DataTable dateTable)
        {
            string data = string.Empty;

            StringBuilder holder = new StringBuilder();

            // Commences if the table exists and has atleast 1 row in it
            if (null != dateTable && null != dateTable.Rows)
            {
                // Loops through the rows belonging to the given table
                foreach (DataRow dataRow in dateTable.Rows)
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

        private void GetPersonPrice()
        {
            newCon = manager.NewConMan();
            newCon.Open();

            // Læg mærke til rækkefølgen som dataen bliver extracted i
            string query = "SELECT * FROM PersonPrices-View";

            SqlCommand getPersonPrice = new SqlCommand(query, newCon);

            SqlDataAdapter dataAdapt = new SqlDataAdapter(getPersonPrice);

            dataAdapt.Fill(personPriceTableData);

            dataAdapt.Dispose();

            newCon.Close();
        }

        private string FillPersonPriceData(DataTable priceTable)
        {
            string data = string.Empty;

            StringBuilder holder = new StringBuilder();

            // Commences if the table exists and has atleast 1 row in it
            if (null != priceTable && null != priceTable.Rows)
            {
                // Loops through the rows belonging to the given table
                foreach (DataRow dataRow in priceTable.Rows)
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

        private void GetSpotPrice()
        {
            newCon = manager.NewConMan();
            newCon.Open();

            // Læg mærke til rækkefølgen som dataen bliver extracted i
            string query = "SELECT * FROM SpotPrices-View";

            SqlCommand getSpotPrice = new SqlCommand(query, newCon);

            SqlDataAdapter dataAdapt = new SqlDataAdapter(getSpotPrice);

            dataAdapt.Fill(spotPriceTableData);

            dataAdapt.Dispose();

            newCon.Close();
        }

        private string FillSpotData(DataTable spotTable)
        {
            string data = string.Empty;

            StringBuilder holder = new StringBuilder();

            // Commences if the table exists and has atleast 1 row in it
            if (null != spotTable && null != spotTable.Rows)
            {
                // Loops through the rows belonging to the given table
                foreach (DataRow dataRow in spotTable.Rows)
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

        private void GetAdditionalPrice()
        {
            newCon = manager.NewConMan();
            newCon.Open();

            // Læg mærke til rækkefølgen som dataen bliver extracted i
            string query = "SELECT * FROM AdditionalPrices-View";

            SqlCommand getAdditionalPrice = new SqlCommand(query, newCon);

            SqlDataAdapter dataAdapt = new SqlDataAdapter(getAdditionalPrice);

            dataAdapt.Fill(additionalPriceTableData);

            dataAdapt.Dispose();

            newCon.Close();
        }

        private string FillAdditionalPrice(DataTable additionalTable)
        {
            string data = string.Empty;

            StringBuilder holder = new StringBuilder();

            // Commences if the table exists and has atleast 1 row in it
            if (null != additionalTable && null != additionalTable.Rows)
            {
                // Loops through the rows belonging to the given table
                foreach (DataRow dataRow in additionalTable.Rows)
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
        #endregion

        #region SQL Command Methods
        private void GetPersonAmount()
        {
            newCon = manager.NewConMan();
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

        private string FillPersonAmount(DataTable personAmountTable)
        {
            string data = string.Empty;

            StringBuilder holder = new StringBuilder();

            // Commences if the table exists and has atleast 1 row in it
            if (null != personAmountTable && null != personAmountTable.Rows)
            {
                // Loops through the rows belonging to the given table
                foreach (DataRow dataRow in personAmountTable.Rows)
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

        private void GetSpotAmount()
        {
            newCon = manager.NewConMan();
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

        private string FillSpotAmount(DataTable spotAmountTable)
        {
            string data = string.Empty;

            StringBuilder holder = new StringBuilder();

            // Commences if the table exists and has atleast 1 row in it
            if (null != spotAmountTable && null != spotAmountTable.Rows)
            {
                // Loops through the rows belonging to the given table
                foreach (DataRow dataRow in spotAmountTable.Rows)
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

        private void GetAdditionalAmount()
        {
            newCon = manager.NewConMan();
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

        private string FillAdditionalAmount(DataTable additionalAmountTable)
        {
            string data = string.Empty;

            StringBuilder holder = new StringBuilder();

            // Commences if the table exists and has atleast 1 row in it
            if (null != additionalAmountTable && null != additionalAmountTable.Rows)
            {
                // Loops through the rows belonging to the given table
                foreach (DataRow dataRow in additionalAmountTable.Rows)
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
        #endregion

        private int StringToInt(string temp)
        {
            return Convert.ToInt32(temp);
        }

        public int PriceCalc()
        {
            #region Date extraction
            // Gets the arrival date for the reservation so we can calculate price depending on season
            string temp = FillDateData(dateTableData);
            string[] dateHolder = temp.Split(',');
            string aDate = dateHolder[1];

            DateTime arrivalDate = DateTime.Parse(aDate);

            Convert.ToDateTime(hSeason1);
            Convert.ToDateTime(hSeason2);
            #endregion

            #region Person prices
            GetPersonPrice();

            // Læg mærke til rækkefølgen som dataen bliver extracted i
            string personPrice = FillPersonPriceData(personPriceTableData);
            string[] personPriceHolder = personPrice.Split(',');

            // Converting the string object(array) to an integer object(array) so we can calculate prices
            int[] personPriceInfo = Array.ConvertAll(personPriceHolder, new Converter<string, int>(StringToInt));

            int barnPriceH = personPriceInfo[0];
            int barnPriceL = personPriceInfo[1];
            int hundPriceH = personPriceInfo[2];
            int hundPriceL = personPriceInfo[3];
            int voksenPriceH = personPriceInfo[4];
            int voksenPriceL = personPriceInfo[5];
            #endregion

            #region Spot prices
            GetSpotPrice();

            // Spot type prices extracted from array and then converted 
            string spotPrice = FillSpotData(spotPriceTableData);
            string[] spotPriceHolder = spotPrice.Split(',');

            // Converting the string object(array) to an integer object(array) so we can calculate prices
            int[] spotPriceInfo = Array.ConvertAll(spotPriceHolder, new Converter<string, int>(StringToInt));

            // Copies the given index and from the spotPriceInfo array to an integer variable
            int fall = spotPriceInfo[0];
            int spring = spotPriceInfo[2];
            int cpLilleH = spotPriceInfo[4];
            int cpLilleL = spotPriceInfo[5];
            int lukHytteH = spotPriceInfo[6];
            int lukHytteL = spotPriceInfo[7];
            int summer = spotPriceInfo[8];
            int standHytteH = spotPriceInfo[10];
            int standHytteL = spotPriceInfo[11];
            int cpStorH = spotPriceInfo[12];
            int cpStorL = spotPriceInfo[13];
            int teltH = spotPriceInfo[14];
            int teltL = spotPriceInfo[15];
            int winter = spotPriceInfo[16];
            #endregion

            #region Additional prices
            GetAdditionalPrice();

            string additionalPrices = FillAdditionalPrice(additionalPriceTableData);
            string[] additionalPricesHolder = additionalPrices.Split(',');

            // Converting the string object(array) to an integer object(array) so we can calculate prices
            int[] additionalPriceInfo = Array.ConvertAll(additionalPricesHolder, new Converter<string, int>(StringToInt));

            int badeBarn = additionalPriceInfo[0];
            int badeVoksen = additionalPriceInfo[1];
            int cykelLeje = additionalPriceInfo[2];
            int ren = additionalPriceInfo[3];
            int sengeLinned = additionalPriceInfo[4];
            #endregion

            #region Person amount
            GetPersonAmount();

            string pAmount = FillPersonAmount(spotPriceTableData);
            string[] pAmountHolder = pAmount.Split(',');

            // Converting the string object(array) to an integer object(array) so we can calculate prices
            int[] pAmountInfo = Array.ConvertAll(pAmountHolder, new Converter<string, int>(StringToInt));

            int barnAmount = pAmountInfo[2];
            int hundeAmount = pAmountInfo[5];
            int voksenAmount = pAmountInfo[8];
            #endregion

            #region Spot amount
            GetSpotAmount();

            string sAmount = FillSpotAmount(spotPriceTableData);
            string[] sAmountHolder = sAmount.Split(',');

            // Converting the string object(array) to an integer object(array) so we can calculate prices
            int[] sAmountInfo = Array.ConvertAll(sAmountHolder, new Converter<string, int>(StringToInt));

            int fallAmount = sAmountInfo[2];
            int springAmount = sAmountInfo[5];
            int cpLilleAmount = sAmountInfo[8];
            int lukHytteAmount = sAmountInfo[11];
            int summerAmount = sAmountInfo[14];
            int standHytteAmount = sAmountInfo[17];
            int cpStorAmount = sAmountInfo[20];
            int teltAmount = sAmountInfo[23];
            int winterAmount = sAmountInfo[26];
            #endregion

            #region Additional amount
            GetAdditionalAmount();

            string aAmount = FillAdditionalAmount(spotPriceTableData);
            string[] aAmountHolder = pAmount.Split(',');

            // Converting the string object(array) to an integer object(array) so we can calculate prices
            int[] aAmountInfo = Array.ConvertAll(aAmountHolder, new Converter<string, int>(StringToInt));

            int badeBarnAmount = additionalPriceInfo[2];
            int badeVoksenAmount = additionalPriceInfo[5];
            int cykelLejeAmount = additionalPriceInfo[8];
            int renAmount = additionalPriceInfo[11];
            int sengeLinnedAmount = additionalPriceInfo[14];
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

                int highSeasonTotal = barnTotal + hundTotal + voksenTotal + springTotal +
                    summerTotal + fallTotal + winterTotal + cpLilleHTotal + cpStorHTotal +
                    standHytteHTotal + lukHytteHTotal + teltHTotal + badeBarnTotal +
                    badeVoksenTotal + cykelLejeTotal + renTotal + sengeLinnedTotal;

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

                int lowSeasonTotal = barnTotal + hundTotal + voksenTotal + springTotal +
                    summerTotal + fallTotal + winterTotal + cpLilleHTotal + cpStorHTotal +
                    standHytteHTotal + lukHytteHTotal + teltHTotal + badeBarnTotal +
                    badeVoksenTotal + cykelLejeTotal + renTotal + sengeLinnedTotal;

                return lowSeasonTotal;
            }
            #endregion
        }
    }
}