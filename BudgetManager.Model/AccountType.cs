using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManager.Model
{
    public class AccountType
    {
        [Key]
        public int AccountTypeId { get; set; }
        public string AccountName { get; set; }
        public virtual ICollection<Account>? Accounts { get; set; }
    }
}
