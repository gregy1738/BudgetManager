using BudgetManager.DAL;
using BudgetManager.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BudgetManager.Web.Controllers
{

    [Route("api/account")]
    [ApiController]
    public class AccountApiController : Controller
    {
        private readonly BudgetManagerDbContext _context;
        private readonly UserManager<User> _userManager;

        public AccountApiController(BudgetManagerDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int? id = null)
        {
            var account = _context.Accounts
                .Include(a => a.AccountType)
                .Include(a => a.User)
                .Where(a => a.AccountId == id)
                .FirstOrDefault();

            var accountDTO = new AccountDTO
            {
                AccountId = account.AccountId,
                Balance = account.Balance,
                AccountType = account.AccountType?.AccountName,
                UserId = account.User?.Id
              
            };

            return Ok(accountDTO);
        }

    }
}
