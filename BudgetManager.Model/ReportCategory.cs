using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetManager.Model
{
    public class ReportCategory
    {
        [Key]
        public int ReportCategoryId { get; set; }

        [ForeignKey(nameof(Report))]
        public int? ReportId { get; set; }
        public Report? Report { get; set; }

        [ForeignKey(nameof(Category))]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public decimal AmountSpent { get; set; }
    }
}
