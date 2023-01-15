using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCFastTactsoft.DatabaseContext;
using MVCFastTactsoft.Models;

namespace MVCFastTactsoft.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public CategoryController(ApplicationDbContext dbContext)
        {
            _dbContext=dbContext;
        }
        public async Task< IActionResult> Index()
        {
            return View(await _dbContext.Categories.ToListAsync());
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            try
            {
                await _dbContext.Categories.AddAsync(category);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(actionName: (nameof(Index)));
            }
            catch
            {
                return View(category);
            }

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var Result=await _dbContext.Categories.FindAsync(id);
            return View(Result);    
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,Category category)
        {
            try
            {
                if (id != category.CategoryId)
                {
                    return NotFound();

                }
                _dbContext.Entry(category).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(actionName: (nameof(Index)));


            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
        }
        public async Task<IActionResult> Details( int id)
        {
            var Result = await _dbContext.Categories.FindAsync(id);
            return View(Result);

        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var Result = await _dbContext.Categories.FindAsync(id);
            return View(Result);
        }
        public async Task<IActionResult> Delete(int id,Category category)
        {
            try
            {
                if(id != category.CategoryId)
                {
                    return NotFound();

                }
                _dbContext.Entry(category).State=EntityState.Deleted;
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(actionName: (nameof(Index)));


            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
