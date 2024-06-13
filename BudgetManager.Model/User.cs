using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BudgetManager.Model
{
    public class User : IdentityUser
    {
        public virtual ICollection<Account>? Accounts { get; set; }
        public virtual ICollection<Transaction>? Transactions { get; set; }
        public virtual ICollection<Report>? Reports { get; set; }

    }
} 
