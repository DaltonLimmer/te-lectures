using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingService.Interfaces;
using VendingService.Models;

namespace VendingService.Helpers
{
    public class TransactionManager
    {
        private IVendingService _db = null;
        private ILogService _log = null;
        private List<TransactionItem> _transactionItems = new List<TransactionItem>();
        private double _runningTotal = 0.0;

        public double RunningTotal
        {
            get
            {
                return _runningTotal;
            }
        }

        public TransactionManager(IVendingService db, ILogService log)
        {
            _db = db;
            _log = log;
        }

        public double AddPurchaseTransaction(int productId)
        {
            ProductItem product = _db.GetProductItem(productId);

            TransactionItem transactionItem = new TransactionItem();
            transactionItem.ProductId = productId;
            transactionItem.SalePrice = product.Price;
            _transactionItems.Add(transactionItem);

            VendingOperation operation = new VendingOperation();
            operation.OperationType = VendingOperation.eOperationType.PurchaseItem;
            operation.Price = product.Price;
            operation.RunningTotal = _runningTotal;
            operation.ProductName = product.Name;
            _log.LogOperation(operation);

            _runningTotal -= product.Price;

            return _runningTotal;
        }

        public double AddFeedMoneyOperation(double amountAdded)
        {
            VendingOperation operation = new VendingOperation();
            operation.OperationType = VendingOperation.eOperationType.FeedMoney;
            operation.Price = amountAdded;
            operation.RunningTotal = _runningTotal;
            _log.LogOperation(operation);

            _runningTotal += amountAdded;

            return _runningTotal;
        }

        public double AddGiveChangeOperation()
        {
            double result = _runningTotal;
            VendingOperation operation = new VendingOperation();
            operation.OperationType = VendingOperation.eOperationType.GiveChange;
            operation.RunningTotal = _runningTotal;
            _log.LogOperation(operation);

            _runningTotal = 0.0;

            return result;
        }

        public void CommitTransaction()
        {
            VendingTransaction vendTrans = new VendingTransaction();
            vendTrans.Date = DateTime.UtcNow;

            _db.AddTransactionSet(vendTrans, _transactionItems);
        }

        public static Change GetChange(double changeTotal)
        {
            Change result = new Change();

            int temp = (int) (changeTotal * 100.0);
            result.Quarters = temp / 25;
            temp -= result.Quarters * 25;

            result.Dimes = temp / 10;
            temp -= result.Dimes * 10;

            result.Nickels = temp / 5;

            return result;
        }
    }
}
