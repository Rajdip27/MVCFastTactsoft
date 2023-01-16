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
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var Result=await _dbContext.EmployeeSalaryTbs.FindAsync(id);
                return View(Result);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EmployeeSalaryTb salaryTb)
        {
            try
            {
                if(id!= salaryTb.Id)
                {
                    return NotFound();
                }
                _dbContext.Entry(salaryTb).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(actionName: (nameof(Index)));


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var Result = await _dbContext.EmployeeSalaryTbs.FindAsync(id);
                return View(Result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var Result = await _dbContext.EmployeeSalaryTbs.FindAsync(id);
                return View(Result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id, EmployeeSalaryTb salaryTb)
        {
            try
            {
                if(id != salaryTb.Id)
                {
                    return NotFound();
                }
                _dbContext.Entry(salaryTb).State = EntityState.Deleted;
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(actionName: (nameof(Index)));


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
