using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class MySqlDb : IDbCommunication
    {
        public MySqlConnection Connection;

        public void ConnectToDb()
        {
            string connectionString = $"SERVER={ConfigManager.DbServer};DATABASE={ConfigManager.DbName};UID={ConfigManager.DbUid};PASSWORD={ConfigManager.DbPassword};";

            Connection = new MySqlConnection(connectionString);
        }

        public void OpenConnection()
        {
            Connection.Open();
        }

        //TODO: this is only ever used once and in this class. maybe it's unneccery?
        public void CloseConnection()
        {
            Connection.Close();
        }


        // TODO: this should not be a part of the DAL. you have a lot of logic here.
        // TODO: split into functions. You are doing many different things in one function.
        public List<PurchaseDataRecieve> PullAllPurchasesData()
        {
            Task.Delay(TimeSpan.FromSeconds(10)).Wait();
            List<PurchaseDataRecieve> purchasesDataRecieve = new List<PurchaseDataRecieve>();
            string query = $"{ConfigManager.DbPullAllQuery}";
            MySqlCommand cmd = new MySqlCommand(query, Connection);
            OpenConnection();

            MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PurchaseDataRecieve purchaseDataRecieve = new PurchaseDataRecieve();
                    purchaseDataRecieve.PurchaseId = reader[ConfigManager.PurchaseIdDb].ToString();
                    purchaseDataRecieve.StoreType = char.Parse(reader[ConfigManager.StoreTypeDb].ToString());
                    purchaseDataRecieve.StoreId = reader[ConfigManager.StoreIdDb].ToString();
                    purchaseDataRecieve.ActivityDays = char.Parse(reader[ConfigManager.ActivityDaysDb].ToString());
                    purchaseDataRecieve.CreditCardNumber = reader[ConfigManager.CreditCardDb].ToString();
                    purchaseDataRecieve.PurchaseDate = reader[ConfigManager.PurchaseDateDb].ToString();
                    purchaseDataRecieve.DbAddDate = DateTime.Parse(reader[ConfigManager.AddedToDb].ToString());
                    purchaseDataRecieve.PurchasePrice = double.Parse(reader[ConfigManager.PurchasePriceDb].ToString());
                    purchaseDataRecieve.NumberOfPayments = reader[ConfigManager.NumberOfPaymentsDb].ToString();
                    purchaseDataRecieve.PricePerPayment = double.Parse(reader[ConfigManager.PricePerPaymentDb].ToString());
                    purchaseDataRecieve.IsValid = reader[ConfigManager.IsValidDb].ToString();
                    purchaseDataRecieve.WhyInvalid = reader[ConfigManager.WhyInvalidDb].ToString();
                    purchasesDataRecieve.Add(purchaseDataRecieve);
                }

            reader.Close();
            CloseConnection();
            return purchasesDataRecieve;
        }
    }
}
