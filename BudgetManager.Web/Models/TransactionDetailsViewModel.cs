using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManager.Model
{
    public class TransactionDetailsViewModel
    {
        public Transaction Transaction { get; set; }
        public string FormattedTransactionDate { get; set; }
    }
}
