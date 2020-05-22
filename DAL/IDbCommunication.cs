using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DAL
{
    public interface IDbCommunication
    {
        void ConnectToDb();
        void DeleteAllRow();
        List<PurchaseDataOutput> PullAllRows();
    }
}
