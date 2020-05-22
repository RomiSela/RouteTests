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

        public void DeleteAllRow()
        {
            var query = "DELETE FROM purchases";
            var cmd = new MySqlCommand(query, Connection);
            Connection.Open();
            cmd.ExecuteNonQuery();
            Connection.Close();
        }

        public MySqlCommand CreateQueryForReadAllRows()
        {
            string query = $"{ConfigManager.DbPullAllQuery}";
            return new MySqlCommand(query, Connection);
        }

        public List<PurchaseDataOutput> ReadAllRows(MySqlCommand cmd)
        {
            List<PurchaseDataOutput> purchasesDatasOutput = new List<PurchaseDataOutput>();
            Task.Delay(TimeSpan.FromSeconds(10)).Wait();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                PurchaseDataOutput purchaseDataOutput = new PurchaseDataOutput();
                purchaseDataOutput.PurchaseId = reader[ConfigManager.PurchaseIdDb].ToString();
                purchaseDataOutput.StoreType = char.Parse(reader[ConfigManager.StoreTypeDb].ToString());
                purchaseDataOutput.StoreId = reader[ConfigManager.StoreIdDb].ToString();
                purchaseDataOutput.ActivityDays = char.Parse(reader[ConfigManager.ActivityDaysDb].ToString());
                purchaseDataOutput.CreditCardNumber = reader[ConfigManager.CreditCardDb].ToString();
                purchaseDataOutput.PurchaseDate = reader[ConfigManager.PurchaseDateDb].ToString();
                purchaseDataOutput.InsertionDate = DateTime.Parse(reader[ConfigManager.AddedToDb].ToString());
                purchaseDataOutput.PurchasePrice = reader[ConfigManager.PurchasePriceDb].ToString();
                purchaseDataOutput.NumberOfPayments = reader[ConfigManager.NumberOfPaymentsDb].ToString();
                purchaseDataOutput.PricePerPayment = double.Parse(reader[ConfigManager.PricePerPaymentDb].ToString());
                purchaseDataOutput.IsValid = reader[ConfigManager.IsValidDb].ToString();
                purchaseDataOutput.WhyInvalid = reader[ConfigManager.WhyInvalidDb].ToString();
                purchasesDatasOutput.Add(purchaseDataOutput);
            }
            reader.Close();
            return purchasesDatasOutput;
        }

        public List<PurchaseDataOutput> PullAllRows()
        {
            var cmd = CreateQueryForReadAllRows();
            Connection.Open();
            var purchaseDatasOutput = ReadAllRows(cmd);
            Connection.Close();
            return purchaseDatasOutput;
        }
    }
}
