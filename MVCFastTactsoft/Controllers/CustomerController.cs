using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCFastTactsoft.DatabaseContext;
using MVCFastTactsoft.Models;

namespace MVCFastTactsoft.Controllers
{
    public class CustomerController : Controller
    {
      private readonly   ApplicationDbContext _dbContext;
        public CustomerController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task< IActionResult> Index()
        {
            try
            {
                var Result = await _dbContext.Customers.ToListAsync();
                return View(Result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            try
            {
                await _dbContext.Customers.AddAsync(customer);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(actionName: (nameof(Index)));
            }
            catch
            {
                return View(customer);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var Result= await _dbContext.Customers.FindAsync(id);
                return View(Result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,Customer customer)
        {
            try
            {
                if (id != customer.CustomerId)
                {
                    return NotFound();
                }
                _dbContext.Entry(customer).State = EntityState.Modified;
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
                var Result= await _dbContext.Customers.FindAsync(id);
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
                var Result = await _dbContext.Customers.FindAsync(id);
                return View(Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id,Customer customer)
        {
            try
            {
                if(id!= customer.CustomerId)
                {
                    return NotFound();
                }
                _dbContext.Entry(customer).State= EntityState.Deleted;
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
