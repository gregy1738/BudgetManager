namespace BudgetManager.Web.Models
{
    public class ReportViewModel
    {
        public DateTime GeneratedDate { get; set; }
        public string UserName { get; set; }
        public List<CategorySpendingViewModel> CategorySpendings { get; set; }
        public decimal TotalExpenses { get; set; }
        public string CategoryMostSpent { get; set; }
        public string CategoryLeastSpent { get; set; }
        public decimal CategoryAmountMostSpent { get; set; }
        public decimal CategoryAmountLeastSpent { get; set; }
    }
}
