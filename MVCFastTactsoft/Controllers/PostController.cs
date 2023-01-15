using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCFastTactsoft.DatabaseContext;
using MVCFastTactsoft.Models;

namespace MVCFastTactsoft.Controllers
{
    public class PostController : Controller
    {
      private readonly   ApplicationDbContext _dbContext;
        public PostController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task< IActionResult> Index()
        {
            return View(await _dbContext.Posts.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Post post)
        {
            try
            {
                await _dbContext.AddAsync(post);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(actionName: nameof(Index));

            }
            catch
            {
                return View(post);
            }
             
        }
        public async Task<IActionResult> Edit(int id)
        {
            var Result = await _dbContext.Posts.FindAsync(id);
            return View(Result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id ,Post post)
        {
            try
            {
                if (id != post.Id)
                {
                    return NotFound();
                }
                _dbContext.Entry(post).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(actionName: nameof(Index));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public async Task<IActionResult> Details(int id)
        {
            var Result = await _dbContext.Posts.FindAsync(id);
            return View(Result);

        }
        public async Task<IActionResult> Delete(int id)
        {
            var Result = await _dbContext.Posts.FindAsync(id);
            return View(Result);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Post post)
        {
            _dbContext.Entry(post).State = EntityState.Deleted;
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
