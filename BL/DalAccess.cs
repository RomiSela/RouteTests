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
