using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManager.Model
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        public string TransactionName { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }

        [ForeignKey(nameof(User))]
        public string? UserId { get; set; }
        public User? User { get; set; }

        [ForeignKey(nameof(Account))]
        public int? AccountId { get; set; }
        public Account? Account { get; set; }

        [ForeignKey(nameof(Category))]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        [ForeignKey(nameof(PaymentMethod))]
        public int? PaymentMethodId { get; set; }
        public PaymentMethod? PaymentMethod { get; set; }
    }
}
