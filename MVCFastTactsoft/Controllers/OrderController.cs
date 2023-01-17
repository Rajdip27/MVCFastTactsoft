using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCFastTactsoft.DatabaseContext;
using MVCFastTactsoft.Models;

namespace MVCFastTactsoft.Controllers
{
    public class OrderController : Controller
    {
       private readonly ApplicationDbContext _dbContext;
        public OrderController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public  async Task< IActionResult> Index()
        {
            return View(await _dbContext.Orders.ToListAsync());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Order order)
        {
            try
            {
                await _dbContext.Orders.AddAsync(order);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(actionName:(nameof(Index)));
            }
            catch
            {
                return View(order);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var order = await _dbContext.Orders.FindAsync(id);
                return View(order);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Order order)
        {
            try
            {
                if (id != order.Id)
                {
                    return NotFound();
                }
                _dbContext.Entry(order).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(actionName: (nameof(Index)));


            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var order = await _dbContext.Orders.FindAsync(id);
                return View(order);

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
                var order = await _dbContext.Orders.FindAsync(id);
                return View(order);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id, Order order)
        {
            try
            {
                if (id != order.Id)
                {
                    return NotFound();
                }
                _dbContext.Entry(order).State = EntityState.Deleted;
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
