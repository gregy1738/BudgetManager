using BudgetManager.DAL;
using BudgetManager.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BudgetManager.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly BudgetManagerDbContext _context;
        private readonly UserManager<User> _userManager;

        public AccountController(BudgetManagerDbContext context, UserManager<User> userManager)
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

            List<Account> accounts = await _context.Accounts
                 .Where(a => a.UserId == user.Id)
                 .Include(a => a.AccountType)
                 .ToListAsync();

            return View(accounts);
        }

        public async Task<IActionResult> Create()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Challenge();
            }

            this.FillDropdownValues();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Account model)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Challenge(); // Redirect to login if user is not authenticated
            }

            if (ModelState.IsValid)
            {
                model.UserId = user.Id;
                _context.Accounts.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            this.FillDropdownValues();
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

            var model = _context.Accounts
                .Include(a => a.AccountType)
                .FirstOrDefault(a => a.AccountId == id);

            this.FillDropdownValues();
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

            var accounts = _context.Accounts
                .Include(a => a.AccountType)
                .Single(a => a.AccountId == id);

            
            var ok = await this.TryUpdateModelAsync(accounts);

            if (ok && this.ModelState.IsValid)
            {
                await _context.SaveChangesAsync(); 
                return RedirectToAction(nameof(Index));
            }



            this.FillDropdownValues();
            return View();
        }


        public IActionResult Details(int? id)
        {
            var account = _context.Accounts
                .Include(a => a.AccountType)
                .Include(a => a.Transactions)
                .FirstOrDefault(a => a.AccountId == id);

            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        private void FillDropdownValues()
        {
            ViewBag.AccountTypes = _context.AccountTypes.ToList();
        }
    }
}
