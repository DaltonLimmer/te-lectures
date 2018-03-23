using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingService.Interfaces
{
    public interface ITransactionManager
    {
        double RunningTotal { get; }
        double AddPurchaseTransaction(int productId);
        void CommitTransaction();
        double AddFeedMoneyOperation(double amountAdded);
        double AddGiveChangeOperation();
    }
}
