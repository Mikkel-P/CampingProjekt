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

        private DataTable dateTable = new DataTable();

        private DataTable personPriceTable = new DataTable();

        private DataTable spotPriceTable = new DataTable();

        private DataTable additionalPriceData = new DataTable();

        DateTime hSeason1 = new DateTime(2021, 6, 14);

        DateTime hSeason2 = new DateTime(2021, 8, 14);

        // Make views to extract price information

        private void DateExtract()
        {
            newCon = manager.NewConMan();
            newCon.Open();

            string query = "SELECT * FROM ViewName";

            SqlCommand getDates = new SqlCommand(query, newCon);

            SqlDataAdapter dataAdapt = new SqlDataAdapter(getDates);

            dataAdapt.Fill(dateTable);

            dataAdapt.Dispose();

            newCon.Close();
        }

        public void GetDateData()
        {
            newCon = manager.NewConMan();
            newCon.Open();

            string query = "SELECT * FROM ViewName";

            SqlCommand getRsvID = new SqlCommand(query, newCon);

            SqlDataAdapter dataAdapt = new SqlDataAdapter(getRsvID);

            dataAdapt.Fill(dateTable);

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

            string query = "SELECT * FROM ViewName";

            SqlCommand getPersonPrice = new SqlCommand(query, newCon);

            SqlDataAdapter dataAdapt = new SqlDataAdapter(getPersonPrice);

            dataAdapt.Fill(dateTable);

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

            string query = "SELECT * FROM ViewName";

            SqlCommand getSpotPrice = new SqlCommand(query, newCon);

            SqlDataAdapter dataAdapt = new SqlDataAdapter(getSpotPrice);

            dataAdapt.Fill(dateTable);

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

            string query = "SELECT * FROM ViewName";

            SqlCommand getAdditionalPrice = new SqlCommand(query, newCon);

            SqlDataAdapter dataAdapt = new SqlDataAdapter(getAdditionalPrice);

            dataAdapt.Fill(dateTable);

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

        private void GetAmounts()
        {

        }

        public void PriceCalc()
        {
            string temp = FillDateData(dateTable);
            string[] dateHolder = temp.Split(',');
            string aDate = dateHolder[0];

            DateTime arrivalDate = DateTime.Parse(aDate);

            Convert.ToDateTime(hSeason1);
            Convert.ToDateTime(hSeason2);

            string price = FillPersonPriceData(personPriceTable);
            string[] priceHolder = price.Split(',');



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