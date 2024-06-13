using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManager.Model
{
    public class AccountDTO
    {
        public int AccountId { get; set; }
        public decimal Balance { get; set; }
        public string? AccountType { get; set; }
        public string? UserId { get; set; }

    }
}
