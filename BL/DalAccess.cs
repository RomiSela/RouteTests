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

        public void DeleteAllRows()
        {
            DbCommunication.DeleteAllRow();
        }

        public List<PurchaseDataOutput> PullAllPurchasesData()
        {
            return DbCommunication.PullAllRows();
        }

        public PurchaseDataOutput PullPurchasesDataByStoreId(string storeId)
        {
            List<PurchaseDataOutput> purchasesDataRecieve = PullAllPurchasesData();
            PurchaseDataOutput relevantPurchase = new PurchaseDataOutput();
            foreach (var purchase in purchasesDataRecieve)
            {
                if (purchase.StoreId.Equals(storeId))
                    relevantPurchase = purchase;
            }
            return relevantPurchase;
        }
    }
}
