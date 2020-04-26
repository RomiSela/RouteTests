using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BL
{
    public class DalAccess
    {
        public IDbCommunication DbCommunication { get; private set; }

        public DalAccess()
        {
            DbCommunication = new MySqlDb();
        }

        public void ConnectToDb()
        {
            DbCommunication.ConnectToDb();
        }

        public List<PurchaseDataRecieve> PullAllPurchasesData()
        {
            return DbCommunication.PullAllPurchasesData();
        }

        // TODO: what if you wanted to pull the last two purchases?
        // you are generating random numbers. but only from 1-10,000. a 1/10,000 chance for a test to fail is still too high
        // especially because you do not clear the DB before each test. eventually you'll get duplicates.
        // TODO: name is not correct. you are not pulling the last row. you are searching for a storeId.
        public PurchaseDataRecieve PullLastPurchasesData(string storeId)
        {
            List<PurchaseDataRecieve> purchasesDataRecieve = PullAllPurchasesData();
            PurchaseDataRecieve relevantPurchase = new PurchaseDataRecieve();
            foreach (var purchase in purchasesDataRecieve)
            {
                if (purchase.StoreId.Equals(storeId))
                    relevantPurchase = purchase;
            }
            return relevantPurchase;
        }
    }
}
