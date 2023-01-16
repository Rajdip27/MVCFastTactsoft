using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCFastTactsoft.DatabaseContext;
using MVCFastTactsoft.Models;

namespace MVCFastTactsoft.Controllers
{
    public class EmployeeSalaryTbController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public EmployeeSalaryTbController(ApplicationDbContext dbContext)
        {
            _dbContext=dbContext;
        }
        public async Task< IActionResult> Index()
        {
            return View(await _dbContext.EmployeeSalaryTbs.ToListAsync());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeSalaryTb salaryTb)
        {
            try
            {
                await _dbContext.AddAsync(salaryTb);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(actionName:(nameof(Index)));

            }
            catch
            {
                return View(salaryTb);
            }
        }
    }
}
