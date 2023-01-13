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
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Registration registration)
        {
            if (ModelState.IsValid)
            {
                await _dbContext.Registrations.AddAsync(registration);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(actionName: (nameof(Index)));
            }
            return View(registration);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var rs=await _dbContext.Registrations.FindAsync(id);
            return View(rs);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Registration registration)
        {
                _dbContext.Entry(registration).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(actionName: (nameof(Index)));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var rs=await _dbContext.Registrations.FindAsync(id);
            return View(rs);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var rs = await _dbContext.Registrations.FindAsync(id);
            return View(rs);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Registration registration)
        {
                _dbContext.Entry(registration).State = EntityState.Deleted;
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(actionName: (nameof(Index)));
        }

    }
}
