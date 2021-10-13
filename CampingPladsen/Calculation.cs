using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace CampingProjekt
{
    public class Calculation
    {
        public Calculation() { }

        Manager manager = new Manager();

        SqlConnection newCon = new SqlConnection();

        private DataTable dateTableData = new DataTable();

        private DataTable personPriceTableData = new DataTable();

        private DataTable spotPriceTableData = new DataTable();

        private DataTable additionalPriceTableData = new DataTable();

        private DataTable personAmountTableData = new DataTable();

        private DataTable spotAmountTableData = new DataTable();

        private DataTable additionalAmountTableData = new DataTable();

        DateTime hSeason1 = new DateTime(2021, 6, 14);

        DateTime hSeason2 = new DateTime(2021, 8, 14);

        // Make views to extract price information

        public void GetDateData()
        {
            newCon = manager.NewConMan();
            newCon.Open();

            // Læg mærke til rækkefølgen som dataen bliver extracted i
            string query = "SELECT * FROM ViewName";

            SqlCommand getRsvID = new SqlCommand(query, newCon);

            SqlDataAdapter dataAdapt = new SqlDataAdapter(getRsvID);

            dataAdapt.Fill(dateTableData);

            dataAdapt.Dispose();

            newCon.Close();
        }

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
            string query = "SELECT * FROM ViewName";

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
            string query = "SELECT * FROM ViewName";

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
            string query = "SELECT * FROM ViewName";

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

        private void GetPersonAmount()
        {
            newCon = manager.NewConMan();
            newCon.Open();

            // Læg mærke til rækkefølgen som dataen bliver extracted i
            string query = "SELECT * FROM ViewName";

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

            // Læg mærke til rækkefølgen som dataen bliver extracted i
            string query = "SELECT * FROM ViewName";

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

            // Læg mærke til rækkefølgen som dataen bliver extracted i
            string query = "SELECT * FROM ViewName";

            SqlCommand getAmounts = new SqlCommand(query, newCon);

            SqlDataAdapter dataAdapt = new SqlDataAdapter(getAmounts);

            dataAdapt.Fill(additionalAmountTableData);

            dataAdapt.Dispose();

            newCon.Close();
        }

        public void PriceCalc()
        {
            string temp = FillDateData(dateTableData);
            string[] dateHolder = temp.Split(',');
            string aDate = dateHolder[0];

            DateTime arrivalDate = DateTime.Parse(aDate);

            Convert.ToDateTime(hSeason1);
            Convert.ToDateTime(hSeason2);

            // Læg mærke til rækkefølgen som dataen bliver extracted i
            string personPrice = FillPersonPriceData(personPriceTableData);
            string[] personPriceHolder = personPrice.Split(',');
            string barnPrice = personPriceHolder[0];
            string hundPrice = personPriceHolder[1];
            string voksenPrice = personPriceHolder[2];

            string spotPrice = FillSpotData(spotPriceTableData);
            string[] spotPriceHolder = spotPrice.Split(',');
            string fall = spotPriceHolder[0];
            string spring = spotPriceHolder[1];
            string cpLille = spotPriceHolder[2];
            string lukHytte = spotPriceHolder[3];
            string summer = spotPriceHolder[4];
            string standHytte = spotPriceHolder[5];
            string cpStor = spotPriceHolder[6];
            string telt = spotPriceHolder[7];
            string winter = spotPriceHolder[8];

            string additionalPrices = FillAdditionalPrice(additionalPriceTableData);
            string[] additionalPricesHolder = additionalPrices.Split(',');
            string badeBarn = additionalPricesHolder[0];
            string badeVoksen = additionalPricesHolder[1];
            string cykelLeje = additionalPricesHolder[3];
            string ren = additionalPricesHolder[4];
            string sengeLinned = additionalPricesHolder[5];



            if (arrivalDate > hSeason1 && arrivalDate < hSeason2)
            {
                // Højsæsons pris udregning
            }
            else 
            {
                // Lavsæsons pris udregning
            }
        }
    }
}