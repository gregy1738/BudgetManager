using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace BudgetManager.Model
{
    public class Report
    {
        [Key]
        public int ReportId { get; set; }
        public DateTime GeneratedDate { get; set; }

        [NotMapped]
        public Category CategoryMostSpent { get; private set; }
        [NotMapped]
        public Category CategoryLeastSpent { get; private set; }
        [NotMapped]
        public decimal CategoryAmountMostSpent { get; private set; }
        [NotMapped]
        public decimal CategoryAmountLeastSpent { get; private set; }
        [NotMapped]
        public decimal TotalExpenses { get; private set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public User User { get; set; }

        public ICollection<ReportCategory>? ReportCategories { get; set; } = new List<ReportCategory>();

        public void CalculatingExtremeValues()
        {
            if (ReportCategories != null && ReportCategories.Any())
            {
                var mostSpent = ReportCategories.OrderByDescending(rc => rc.AmountSpent).FirstOrDefault();
                var leastSpent = ReportCategories.OrderBy(rc => rc.AmountSpent).FirstOrDefault();

                CategoryMostSpent = mostSpent?.Category;
                CategoryLeastSpent = leastSpent?.Category;
                CategoryAmountMostSpent = mostSpent?.AmountSpent ?? 0;
                CategoryAmountLeastSpent = leastSpent?.AmountSpent ?? 0;
                TotalExpenses = ReportCategories.Sum(rc => rc.AmountSpent);
            }
        }
    }
}
