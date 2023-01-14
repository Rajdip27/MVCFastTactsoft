using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCFastTactsoft.DatabaseContext;
using MVCFastTactsoft.Models;

namespace MVCFastTactsoft.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public UserController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
                
        }
        [HttpGet]
       
        public async Task< IActionResult> Index()
        {
            var Result= await _dbContext.Users.ToListAsync();
            return View(Result);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                await _dbContext.Users.AddAsync(user);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(actionName: (nameof(Index)));
            }
            return View(user);

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result=await _dbContext.Users.FindAsync(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            _dbContext.Entry(user).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(actionName: (nameof(Index)));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var Result = await _dbContext.Users.FindAsync(id);
            return View(Result);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(User user)
        {
            _dbContext.Entry(user).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(actionName: (nameof(Index)));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {

            var result = await _dbContext.Users.FindAsync(id);
            return View(result);
        }
    }
}
