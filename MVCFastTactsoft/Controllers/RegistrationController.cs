using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCFastTactsoft.DatabaseContext;
using MVCFastTactsoft.Models;

namespace MVCFastTactsoft.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public RegistrationController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        public async Task<IActionResult> Index()
        {
            var Result = await _dbContext.Registrations.ToListAsync();
            return View(Result);
        }
    }
}
