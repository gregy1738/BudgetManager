using BudgetManager.DAL;
using BudgetManager.DAL.Migrations;
using BudgetManager.Model;
using BudgetManager.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetManager.Web.Controllers
{
    public class TransactionController : Controller
    {
        private readonly BudgetManagerDbContext _context;
        private readonly UserManager<User> _userManager;

        public TransactionController(BudgetManagerDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return Challenge();
            }

            List<Transaction> transactions = await _context.Transactions
                 .Where(t => t.UserId == user.Id)
                 .Include(t => t.Account)
                 .Include(t => t.Category)
                 .ToListAsync();

            return View(transactions);
        }

        public async Task<IActionResult> Create()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Challenge();
            }

            await FillDropdownValuesAsync(user);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Transaction model)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return Challenge(); // Redirect to login if user is not authenticated
            }

            if (ModelState.IsValid)
            {

                var account = _context.Accounts.SingleOrDefault(a => a.AccountId == model.AccountId);

                if(account != null)
                {

                    account.Balance -= model.Amount;

                    _context.Update(account);
                }

                model.UserId = user.Id;

                _context.Transactions.Add(model);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            await FillDropdownValuesAsync(user);
            return View(model); 
        }

        [ActionName(nameof(Edit))]
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return Challenge(); // Redirect to login if user is not authenticated
            }

            var model = _context.Transactions
                .Include(t => t.Category)
                .Include(t => t.PaymentMethod)
                .Include(t => t.Account)
                .FirstOrDefault(t =>  t.TransactionId == id);

            await FillDropdownValuesAsync(user);
            return View(model);
        }

        [HttpPost]
        [ActionName(nameof(Edit))]
        public async Task<IActionResult> EditPost(int id)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return Challenge(); // Redirect to login if user is not authenticated
            }

            var transaction = _context.Transactions
                .Include(t => t.Category)
                .Include(t => t.PaymentMethod)
                .Include(t => t.Account)
                .Single(t => t.TransactionId == id);

            var ok = await this.TryUpdateModelAsync(transaction);

            if (ok && this.ModelState.IsValid)
            {
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            await FillDropdownValuesAsync(user);
            return View();
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = _context.Transactions
                .Include(t => t.Account)
                .ThenInclude(t => t.AccountType)
                .Include(t => t.Category)
                .Include(t => t.PaymentMethod)
                .FirstOrDefault(t => t.TransactionId == id);

            if (transaction == null)
            {
                return NotFound();
            }

            var viewModel = new TransactionDetailsViewModel
            {
                Transaction = transaction,
                FormattedTransactionDate = transaction.TransactionDate.ToString("dd-MM-yyyy")
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);


            if (transaction == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts.SingleOrDefaultAsync(a => a.AccountId == transaction.AccountId);

            if (account != null)
            {
                account.Balance += transaction.Amount;
                _context.Update(account);
            }

            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();

            return Ok(); // Return a success response
        }


        private async Task FillDropdownValuesAsync(User user)
        {

            var paymentMethods = await _context.PaymentMethods.ToListAsync();
            var categories = await _context.Categories.ToListAsync();
            var accounts = await _context.Accounts
                .Where(a => a.UserId == user.Id)
                .Include(a => a.AccountType)
                .ToListAsync();

            ViewBag.PossiblePaymentMethods = new SelectList(paymentMethods, "PaymentMethodId", "PaymentMethodName");
            ViewBag.PossibleAccounts = new SelectList(accounts, "AccountId", "AccountType.AccountName");
            ViewBag.PossibleCategories = new SelectList(categories, "CategoryId", "CategoryName");
        }
    }
}
