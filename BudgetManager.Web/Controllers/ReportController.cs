using BudgetManager.DAL;
using BudgetManager.Model;
using BudgetManager.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BudgetManager.Web.Controllers
{
    public class ReportController : Controller
    {
        private readonly BudgetManagerDbContext _context;
        private readonly UserManager<User> _userManager;

        public ReportController(BudgetManagerDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public  async Task<IActionResult> Create()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return Challenge();
            }

            var transactions = _context.Transactions
                           .Include(t => t.Category) // Uključivanje povezanih kategorija
                           .Where(t => t.UserId == user.Id)
                           .ToList();

            var reportCategories = transactions
                                      .GroupBy(t => t.Category)
                                      .Select(g => new ReportCategory
                                      {
                                          Category = g.Key,
                                          AmountSpent = g.Sum(t => t.Amount)
                                      }).ToList();

            var report = new Report
            {
                GeneratedDate = DateTime.Now,
                User = user,
                ReportCategories = reportCategories
            };

            report.CalculatingExtremeValues();

            var viewModel = new ReportViewModel
            {
                GeneratedDate = report.GeneratedDate,
                UserName = report.User.UserName,
                CategorySpendings = report.ReportCategories.Select(rc => new CategorySpendingViewModel
                {
                    CategoryName = rc.Category?.CategoryName,
                    AmountSpent = rc.AmountSpent  
                }).ToList(),
                TotalExpenses = report.TotalExpenses,
                CategoryMostSpent = report.CategoryMostSpent?.CategoryName,
                CategoryLeastSpent = report.CategoryLeastSpent?.CategoryName,
                CategoryAmountMostSpent = report.CategoryAmountMostSpent,
                CategoryAmountLeastSpent = report.CategoryAmountLeastSpent
            };

            return View(viewModel);
        }
    }
}
